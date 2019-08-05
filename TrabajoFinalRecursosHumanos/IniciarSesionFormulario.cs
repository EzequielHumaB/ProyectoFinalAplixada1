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
using RecursosHumanosBLL;
using TrabajoFinalRecursosHumanos.UI.Registros;

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
            RepositorioBase<Usuarios> repositorioBase = new RepositorioBase<Usuarios>();
            List<Usuarios> lista = new List<Usuarios>();
            lista = repositorioBase.GetList(p => true);

            foreach(var item in lista)
            {
                if(item.Usuario == UsuariotextBox.Text & item.ClaveUsuario == ClaveUsuarioTextBox.Text & item.NivelUsuario == "Administrador")
                {
                    resultado = 1;
                }
                if(item.Usuario == UsuariotextBox.Text & item.ClaveUsuario == ClaveUsuarioTextBox.Text & item.NivelUsuario == "Secretario")
                {
                    resultado = 2;
                }
            }

            return resultado;
        }

        //Funcion que valida los campos
        private bool ValidarCampos()
        {
            bool paso = true; ;
            if(string.IsNullOrEmpty(UsuariotextBox.Text))
            {
                MessageBox.Show("El nombre de usuario no puede estar vacio");
                UsuariotextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrEmpty(ClaveUsuarioTextBox.Text))
            {
                MessageBox.Show("La contraseña de usuario no puede estar vacia");
                ClaveUsuarioTextBox.Focus();
                paso = false;
            }
            return paso;
        }

        //Descencriptar clave
        public string DesEncriptar(string cadenaDesencriptada)
        {
            string resultado = string.Empty;
            byte[] decryted = Convert.FromBase64String(cadenaDesencriptada);
            resultado = System.Text.Encoding.Unicode.GetString(decryted);

            return resultado;
        }

        int entero;
        private bool ValidarUsuario()
        {
            bool paso = false;
            if(UsuariotextBox.Text == "Root" & ClaveUsuarioTextBox.Text == "mariamaria")
            {
                paso = true;
            }
            else
            {
                RepositorioBase<Usuarios> repositorioBase = new RepositorioBase<Usuarios>();
                var lista = new List<Usuarios>();
                lista = repositorioBase.GetList(p => true);
                foreach(var item in lista)
                {
                    if(UsuariotextBox.Text == item.Usuario & ClaveUsuarioTextBox.Text == DesEncriptar(item.ClaveUsuario))
                    {
                        paso = true;
                        entero = item.UsuarioId;
                        break;
                    }
                }
            }
            return paso;
        }

        private void IniciarSesionbutton_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;


            if (!ValidarUsuario())
            {
                MessageBox.Show("Usuario no valido o usuario y contraseña incorrectos");
                return;
            }


            Form1 form1 = new Form1(entero);
            Hide();
            form1.ShowDialog();
            Dispose();    
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
