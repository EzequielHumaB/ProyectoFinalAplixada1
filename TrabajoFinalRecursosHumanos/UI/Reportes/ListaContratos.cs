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
    public partial class ListaContratos : Form
    {
        private List<Contratos> lista;
        public ListaContratos(List<Contratos> contratos)
        {
            this.lista = contratos;
            InitializeComponent();
        }

        private void ListaContratos_Load(object sender, EventArgs e)
        {
            ContratoReporte contratoReporte = new ContratoReporte();
            contratoReporte.SetDataSource(lista);
            crystalReportViewer1.ReportSource = contratoReporte;
            crystalReportViewer1.Refresh();
        }
    }
}
