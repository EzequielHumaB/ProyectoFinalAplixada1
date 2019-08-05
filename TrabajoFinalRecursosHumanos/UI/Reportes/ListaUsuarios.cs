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
    public partial class ListaUsuarios : Form
    {
        private List<Usuarios> lista;
        public ListaUsuarios(List<Usuarios> usuarios)
        {
            this.lista = usuarios;
            InitializeComponent();
        }

        private void ListaUsuarios_Load(object sender, EventArgs e)
        {
            UsuarioReporte usuarioReporte = new UsuarioReporte();
            usuarioReporte.SetDataSource(lista);
            crystalReportViewer1.ReportSource = usuarioReporte;
            crystalReportViewer1.Refresh();
        }
    }
}
