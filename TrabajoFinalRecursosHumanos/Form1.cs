using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabajoFinalRecursosHumanos.UI.Consultas;
using TrabajoFinalRecursosHumanos.UI.Registros;

namespace TrabajoFinalRecursosHumanos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void EmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmpleadosFormulario empleadosFormulario = new EmpleadosFormulario();
            empleadosFormulario.StartPosition = FormStartPosition.CenterScreen;
            empleadosFormulario.Show();
        }

        private void EmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuarioFormulario usuarioFormulario = new UsuarioFormulario();
            usuarioFormulario.StartPosition = FormStartPosition.CenterScreen;
            usuarioFormulario.Show();
        }

        private void EmpleadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConsultaEmpleadoFormulario consulta = new ConsultaEmpleadoFormulario();
            consulta.StartPosition = FormStartPosition.CenterScreen;
            consulta.Show();
        }

        private void ContratosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaDeContratos consultaDeContratos = new ConsultaDeContratos();
            consultaDeContratos.StartPosition = FormStartPosition.CenterParent;
            consultaDeContratos.Show();
        }

        private void HorarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmpleadosFormulario empleadosFormulario = new EmpleadosFormulario();
            empleadosFormulario.StartPosition = FormStartPosition.CenterScreen;
            empleadosFormulario.Show();
        }

        private void IniciarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContratoFormulario contratoFormulario = new ContratoFormulario();
            contratoFormulario.StartPosition = FormStartPosition.CenterScreen;
            contratoFormulario.Show();
        }

        private void IniciarSesionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            IniciarSesionFormulario iniciarSesionFormulario = new IniciarSesionFormulario();
            iniciarSesionFormulario.StartPosition = FormStartPosition.CenterScreen;
            iniciarSesionFormulario.Show();
        }

        private void UsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuarioConsultas usuarioConsultas = new UsuarioConsultas();
            usuarioConsultas.StartPosition = FormStartPosition.CenterScreen;
            usuarioConsultas.Show();
        }

        private void EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaEmpleadoFormulario consultaEmpleadoFormulario = new ConsultaEmpleadoFormulario();
            consultaEmpleadoFormulario.StartPosition = FormStartPosition.CenterScreen;
            consultaEmpleadoFormulario.Show();
        }

        private void ContratosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ConsultaDeContratos consultaDeContratos = new ConsultaDeContratos();
            consultaDeContratos.StartPosition = FormStartPosition.CenterScreen;
            consultaDeContratos.Show();
        }

        private void DepartamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DepartamentoConsultas departamentoConsultas = new DepartamentoConsultas();
            departamentoConsultas.StartPosition = FormStartPosition.CenterScreen;
            departamentoConsultas.Show();
        }

        private void TipoDeVacanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TipoVacanteFormulario tipoVacanteFormulario = new TipoVacanteFormulario();
            tipoVacanteFormulario.StartPosition = FormStartPosition.CenterScreen;
            tipoVacanteFormulario.Show();
        }
    }
}