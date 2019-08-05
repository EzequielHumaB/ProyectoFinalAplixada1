using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;


namespace TrabajoFinalRecursosHumanos.UI.Reportes
{
    public partial class ListaDepartamentos : Form
    {
        private List<Departamentos> lista;
        public ListaDepartamentos(List<Departamentos> departamentos)
        {
            this.lista = departamentos;
            InitializeComponent();
        }

     

        private void ListaDepartamentos_Load(object sender, EventArgs e)
        {
            DepartamentoReporte departamentoReporte = new DepartamentoReporte();
            departamentoReporte.SetDataSource(lista);
            crystalReportViewer1.ReportSource = departamentoReporte;
            crystalReportViewer1.Refresh();
        }
    }
}
