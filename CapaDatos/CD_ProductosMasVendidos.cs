using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_ProductosMasVendidos:ConexionBD
    {
        //Metodo para obtener los productos mas vendidos por rango de fecha
        public DataTable mostSoldItems(DateTime fromDate, DateTime toDate)
        {
            //Obteniendo la conexion
            using (SqlConnection connection = new SqlConnection(ConexionBD.cadena))
            {
                //Abriendo la conexion
                {
                    connection.Open();
                    //Comando SQL
                    using (var command = new SqlCommand())
                    {
                        //Indicar la conexion del comando
                        command.Connection = connection;
                        //Aqui va la consulta
                        command.CommandText = @"SELECT TOP 10
                                            P.IdProducto,
                                            P.Nombre,
                                            SUM(DV.Cantidad) AS TotalVendidos,
                                            SUM(DV.Cantidad*P.PrecioVenta) AS VENTA_TOTAL,
                                            SUM(DV.Cantidad*P.PrecioVenta - DV.Cantidad*P.PrecioCompra) AS UTILIDAD
                                            FROM 
                                            VENTA V
                                            INNER JOIN DETALLE_VENTA DV ON DV.IdVenta= V.IdVenta
                                            INNER JOIN PRODUCTO P ON P.IdProducto=DV.IdProducto
                                            WHERE V.FechaRegistro BETWEEN @fromDate AND @toDate
                                            GROUP BY 
                                            P.IdProducto,
                                            P.Nombre,
                                            P.PrecioVenta,
                                            P.PrecioCompra
                                            ORDER BY TotalVendidos DESC";
                        //Añadiendo los parámetros
                        command.Parameters.Add("@fromDate", SqlDbType.Date).Value = fromDate;
                        command.Parameters.Add("@toDate", SqlDbType.Date).Value = toDate;
                        //Indicando que el comando es de tipo texto
                        command.CommandType = CommandType.Text;
                        //Creando el lector SQL
                        var reader = command.ExecuteReader();
                        //Instancia tipo tabla de datos
                        var table = new DataTable();
                        table.Load(reader);
                        reader.Dispose();
                        return table;
                    }
                }

            }
        }
    }
}
