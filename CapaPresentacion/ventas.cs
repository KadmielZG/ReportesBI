using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;

namespace CapaPresentacion
{
    public partial class ventas : Form
    {
        public ventas()
        {
            InitializeComponent();
        }

        private void ventas_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
        private void CP_obtenerProductosMasVendidos(DateTime startDate, DateTime endDate)
        {
            CN_ReporteVentas reportModel = new CN_ReporteVentas();
            reportModel.CN_obtenerProductosMasVendidos(startDate, endDate);
            //Asignando datos al enlace de datos
            CN_ReporteVentasBindingSource.DataSource = reportModel;
            CN_ProductosMasVendidosBindingSource.DataSource = reportModel.productosMasVendidos;
            this.reportViewer1.RefreshReport();

        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            var fromDate = dateTimePicker1.Value;
            var toDate = dateTimePicker2.Value;
            CP_obtenerProductosMasVendidos(fromDate, new DateTime(toDate.Year, toDate.Month, toDate.Day, 23, 59, 59));
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inicio frm = new Inicio();
            frm.Show();
        }
    }
}
