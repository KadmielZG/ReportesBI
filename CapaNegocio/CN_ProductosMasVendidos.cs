using System;
namespace CapaNegocio
{
    public class CN_ProductosMasVendidos
    {
        public int idProducto { get; set; }
        public string Nombre { get; set; }
        public int TotalVendidos { get; set; }
        public double VENTA_TOTAL { get; set; }
        public double UTILIDAD { get; set; }
    }
}