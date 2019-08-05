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
using RecursosHumanosBLL;
using Entidades;
using TrabajoFinalRecursosHumanos.UI.Registros;

namespace TrabajoFinalRecursosHumanos
{
    public partial class Form1 : Form
    {
        public int UsuarioIdentificacion;
        public Form1(int UsuarioIdentificacion)
        {
            InitializeComponent();
            this.UsuarioIdentificacion = UsuarioIdentificacion;
            MostrarPermisoUsuarioValidacion(UsuarioIdentificacion);
            ControlUsuario();
        }

     

        private void EmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Permisolabel.Text == "Administrador" | Permisolabel.Text == "Solo Usuario")
            {
                UsuarioFormulario usuarioFormulario = new UsuarioFormulario();
                usuarioFormulario.StartPosition = FormStartPosition.CenterScreen;
                usuarioFormulario.Show();
            }
            else
            {
                MessageBox.Show("No tienes permiso para acceder");
            }
        }

        private void EmpleadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConsultaEmpleadoFormulario consulta = new ConsultaEmpleadoFormulario();
            consulta.StartPosition = FormStartPosition.CenterScreen;
            consulta.Show();
        }

        private void ContratosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Permisolabel.Text == "Administrador")
            {
                ConsultaDeContratos consultaDeContratos = new ConsultaDeContratos();
                consultaDeContratos.StartPosition = FormStartPosition.CenterParent;
                consultaDeContratos.Show();
            }
            else
            {
                MessageBox.Show("No tienes permiso para entrar");
            }
           
        }

        private void HorarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Permisolabel.Text == "Administrador" | Permisolabel.Text == "Solo Usuario")
            {
                EmpleadosFormulario empleadosFormulario = new EmpleadosFormulario();
                empleadosFormulario.StartPosition = FormStartPosition.CenterScreen;
                empleadosFormulario.Show();
            }
            else
            {
                MessageBox.Show("No tienes permiso");
            }
        }


      

        private void MostrarPermisoUsuarioValidacion(int id)
        {
            if(id>0)
            {
                RepositorioBase<Usuarios> repositorioBase = new RepositorioBase<Usuarios>();
                Usuarios usuarios = repositorioBase.Buscar(id);
                Permisolabel.Text = usuarios.NivelUsuario.ToString();
            }
            else
            {
                Permisolabel.Text = ("Solo Usuario");
            }
        }

        private void ControlUsuario()
        {
            if(Permisolabel.Text == "Solo Usuario")
            {
                ContratosStrip.Enabled = false;
                EmpleadosStrio.Enabled = false;
                ConsultaStrio.Enabled = false;
                LogOutStrip.Enabled = false;
            }
            if(Permisolabel.Text == "Administrador")
            {
                ContratosStrip.Enabled = true;
                EmpleadosStrio.Enabled = true;
                ConsultaStrio.Enabled = true;
                LogOutStrip.Enabled = true;
            }

        }
            

        private void UsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Permisolabel.Text == "Administrador" | Permisolabel.Text == "Solo Usuario")
            {
                UsuarioConsultas usuarioConsultas = new UsuarioConsultas();
                usuarioConsultas.StartPosition = FormStartPosition.CenterScreen;
                usuarioConsultas.Show();
            }
             else
            {
                MessageBox.Show("No tienes permiso");
            }
        }

        private void EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Permisolabel.Text == "Administrador" | Permisolabel.Text == "Solo Usuario")
            {
                ConsultaEmpleadoFormulario consultaEmpleadoFormulario = new ConsultaEmpleadoFormulario();
                consultaEmpleadoFormulario.StartPosition = FormStartPosition.CenterScreen;
                consultaEmpleadoFormulario.Show();
            }
            else
            {
                MessageBox.Show("No tienes permiso");
            }
           
        }

        private void ContratosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if(Permisolabel.Text == "Administrador" | Permisolabel.Text == "Solo Usuario")
            {
                ConsultaDeContratos consultaDeContratos = new ConsultaDeContratos();
                consultaDeContratos.StartPosition = FormStartPosition.CenterScreen;
                consultaDeContratos.Show();
            }
            else
            {
                MessageBox.Show("No tienes permiso");
            }
           
        }

        private void DepartamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Permisolabel.Text == "Administrador" | Permisolabel.Text == "Solo Usuario")
            {
                DepartamentosConsultas departamentoConsultas = new DepartamentosConsultas();
                departamentoConsultas.StartPosition = FormStartPosition.CenterScreen;
                departamentoConsultas.Show();
            }
            else
            {
                MessageBox.Show("No tienes permiso");
            }
         
        }

        private void TipoDeVacanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Permisolabel.Text == "Administradpr" | Permisolabel.Text == "Solo Usuario")
            {
                TipoVacanteFormulario tipoVacanteFormulario = new TipoVacanteFormulario();
                tipoVacanteFormulario.StartPosition = FormStartPosition.CenterScreen;
                tipoVacanteFormulario.Show();
            }
            else
            {
                MessageBox.Show("No tienes permiso");
            }
           
        }

        private void LogOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IniciarSesionFormulario iniciarSesionFormulario = new IniciarSesionFormulario();
            Dispose();
            iniciarSesionFormulario.ShowDialog();

        }

        private void ContratosStrip_Click(object sender, EventArgs e)
        {
            if(Permisolabel.Text == "Administrador" | Permisolabel.Text == "Solo Usuario")
            {
                ContratoFormulario contratoFormulario = new ContratoFormulario();
                contratoFormulario.StartPosition = FormStartPosition.CenterScreen;
                contratoFormulario.Show();
            }
        }

      
    }
}