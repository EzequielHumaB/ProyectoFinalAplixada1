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
                usuarioFormulario.MdiParent = this;
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
            consulta.MdiParent = this;
            consulta.Show();
        }

       

        private void HorarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Permisolabel.Text == "Administrador" | Permisolabel.Text == "Solo Usuario")
            {
                EmpleadosFormulario empleadosFormulario = new EmpleadosFormulario();
                empleadosFormulario.MdiParent = this;
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
                TipoVacanteStrip.Enabled = true;
            }

        }
            

        private void UsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Permisolabel.Text == "Administrador" | Permisolabel.Text == "Solo Usuario")
            {
                UsuarioConsultas usuarioConsultas = new UsuarioConsultas();
                usuarioConsultas.MdiParent = this;
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
                consultaEmpleadoFormulario.MdiParent = this;
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
                consultaDeContratos.MdiParent = this;
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
                departamentoConsultas.MdiParent = this;
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
                tipoVacanteFormulario.MdiParent = this;
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
                contratoFormulario.MdiParent = this;
                contratoFormulario.Show();
            }
        }

        private void VacantesStrio_Click(object sender, EventArgs e)
        {
            FoTipoVacantermulario foTipoVacantermulario = new FoTipoVacantermulario();
            foTipoVacantermulario.MdiParent = this;
            foTipoVacantermulario.Show();
        }

        private void UsuarioToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UsuarioConsultas usuarioConsultas = new UsuarioConsultas();
            usuarioConsultas.MdiParent = this;
            usuarioConsultas.Show();
        }
    }
}