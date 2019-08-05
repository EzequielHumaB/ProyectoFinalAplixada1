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
    public partial class ListaContrato : Form
    {
        private List<Contratos> Lista;
        public ListaContrato()
        {
            InitializeComponent();
        }

        private void CrystalReportViewer1_Load(object sender, EventArgs e)
        {
            ContratosReporte contratosreporte = new ContratosReporte();
            contratosreporte.SetDataSource(Lista);
            crystalReportViewer1.ReportSource = contratosreporte;
            crystalReportViewer1.Refresh();
        }
    }
}
