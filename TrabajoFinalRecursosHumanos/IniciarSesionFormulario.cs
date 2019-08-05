using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Entidades;

namespace TrabajoFinalRecursosHumanos
{
    public partial class IniciarSesionFormulario : Form
    {    
        public IniciarSesionFormulario()
        {
            InitializeComponent();
        }
        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            UsuariotextBox.Text = string.Empty;
            ClaveUsuarioTextBox.Text = string.Empty;
        }

        public int ValidarIniciarSesion()
        {
            int resultado=0;
            List<Usuarios> lista = new List<Usuarios>();

                foreach(var item in lista)
                {
                    if(item.Usuario == UsuariotextBox.Text & item.ConfirmarClaveUsuario == ClaveUsuarioTextBox.Text & item.NivelUsuario == "Administrador" )
                    {
                        resultado = 1;
                    }
                    else if(item.Usuario == UsuariotextBox.Text & item.ConfirmarClaveUsuario == ClaveUsuarioTextBox.Text & item.NivelUsuario == "Secretario")
                    {
                        resultado = 2;
                    }
                    else
                    {
                        resultado = 0;
                    }
                }

            return resultado;
        }

        private void IniciarSesionbutton_Click(object sender, EventArgs e)
        {
            if (ValidarIniciarSesion() == 0)
            {
                MessageBox.Show("Contraseña o usuario incorrectos");
            }
            else
            {
                new Form1().Show();
            }


                
        }

        private void IniciarSesionFormulario_FormClosing(object sender, FormClosingEventArgs e)
        {
            IniciarSesionFormulario iniciarSesionFormulario = new IniciarSesionFormulario();        
        }

        private void IniciarSesionFormulario_Load(object sender, EventArgs e)
        {
           
        }

        private void IniciarSesionFormulario_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
