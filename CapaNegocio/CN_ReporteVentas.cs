using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CapaDatos;

namespace CapaNegocio
{
    public class CN_ReporteVentas
    {
        //Atributos
        public DateTime starDate { get; set; }
        public DateTime endDate { get; set; }
        public List <CN_ProductosMasVendidos> productosMasVendidos { get; set; }

        //Metodo para crear el reporte de ventas
        public void CN_obtenerProductosMasVendidos(DateTime fromDate, DateTime toDate)
        {
            //Implementando fechas
            starDate = fromDate;
            endDate = toDate;
            //Instanciando la lista
            productosMasVendidos = new List<CN_ProductosMasVendidos>();
            //Llamando al metodo de acceso a datos
            var ProductosVendidos = new CD_ProductosMasVendidos();
            var result = ProductosVendidos.mostSoldItems(fromDate, toDate);
            

            //Recorriendo la lista
            foreach (System.Data.DataRow rows in result.Rows)
            {
                var salesModel = new CN_ProductosMasVendidos()
                {
                    idProducto = Convert.ToInt32(rows[0]),
                    Nombre = Convert.ToString(rows[1]),
                    TotalVendidos = Convert.ToInt32(rows[2]),
                    VENTA_TOTAL = Convert.ToDouble(rows[3]),
                    UTILIDAD = Convert.ToDouble(rows[4])
                };
                //Agregando el objeto modelo de los productos mas vendidos
                productosMasVendidos.Add(salesModel);
            }

        }

    }
}
