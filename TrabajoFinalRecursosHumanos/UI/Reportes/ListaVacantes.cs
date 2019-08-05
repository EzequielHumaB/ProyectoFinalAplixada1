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
    public partial class ListaVacantes : Form
    {
        private List<TipoVacante> lista;
        public ListaVacantes(List<TipoVacante> tipoVacantes)
        {
            this.lista = tipoVacantes;
            InitializeComponent();
        }

     
        private void ListaVacantes_Load(object sender, EventArgs e)
        {
            TipoVacanteReporte tipoVacanteReporte = new TipoVacanteReporte();
            tipoVacanteReporte.SetDataSource(lista);
            crystalReportViewer1.ReportSource = tipoVacanteReporte;
            crystalReportViewer1.Refresh();
        }
    }
}
