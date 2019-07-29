using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabajoFinalRecursosHumanos.UI.Reportes
{
    public partial class ListaEmpleados : Form
    {
        private List<Empleados> Lista;
        public ListaEmpleados(List<Empleados> empleados)
        {
            this.Lista = empleados;
            InitializeComponent();
        }

        private void ListaEmpleados_Load(object sender, EventArgs e)
        {
            EmpleadoReporte empleadoReporte = new EmpleadoReporte();
            empleadoReporte.SetDataSource(Lista);
            crystalReportViewer1.ReportSource = empleadoReporte;
            crystalReportViewer1.Refresh();
        }
    }
}

