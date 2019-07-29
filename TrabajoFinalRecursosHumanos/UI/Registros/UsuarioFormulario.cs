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
using RecursosHumanosBLL;
using System.Security.Cryptography;

namespace TrabajoFinalRecursosHumanos.UI.Registros
{
    public partial class UsuarioFormulario : Form
    {
        private static RSAParameters ClavePrivada;
        private static RSAParameters ClavePublica;    
        public UsuarioFormulario()
        {
            InitializeComponent();
        }

        static byte[] Encriptar(byte[] imput)
        {
            byte[] encriptado;
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(ClavePublica);
                encriptado = rsa.Encrypt(imput, true);
            }
            return encriptado;
        }
        static byte[] DesEncriptar(byte[] imput)
        {
            byte[] encriptado;
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(ClavePrivada);
                encriptado = rsa.Decrypt(imput, true);
            }
            return encriptado;
        }


        static void GenerarLlave()
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                ClavePublica = rsa.ExportParameters(false);
                ClavePrivada = rsa.ExportParameters(true);
            }

        }

       
        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            NombretextBox.Text = string.Empty;
            NiveltextBox.Text = string.Empty;
            FechadateTimePicker.Value = DateTime.Now;
        }
        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private Usuarios LlenarClase()
        {
            Usuarios usuarios = new Usuarios();
            GenerarLlave();
            byte[] encriptado = Encriptar(Encoding.UTF8.GetBytes(IdnumericUpDown.ToString()));
            byte[] desencriptado = DesEncriptar(encriptado);
            // BitConverter.ToInt32(encriptado.Length);
         //   string resultado = Encriptar(IdnumericUpDown.Value);
            usuarios.UsuarioId = Convert.ToInt32(encriptado.Length);
            usuarios.Usuario = NombretextBox.Text;
            usuarios.NivelUsuario = NiveltextBox.Text;
            return usuarios;
        }

        private void LlenarCampo(Usuarios usuarios)
        {
            IdnumericUpDown.Value = usuarios.UsuarioId;
            NombretextBox.Text = usuarios.Usuario;
            NiveltextBox.Text = usuarios.NivelUsuario;
        }

        private bool Validar()
        {
            bool paso = true;
            if(string.IsNullOrEmpty(NombretextBox.Text))
            {
                MyerrorProvider.SetError(NombretextBox, "El usuario no puede estar vacio");
                NombretextBox.Focus();
                paso = false;
            }

            if(string.IsNullOrEmpty(NiveltextBox.Text))
            {
                MyerrorProvider.SetError(NiveltextBox,"El nivel de usuario no puede estar vacio");
                NiveltextBox.Focus();
                paso = false;
            }

            if(FechadateTimePicker.Value > DateTime.Now)
            {
                MyerrorProvider.SetError(FechadateTimePicker,"Fecha invalida");
                FechadateTimePicker.Focus();
                paso = false;
            }
            return paso;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            bool paso = false;

            if (!Validar())
                return;

            Usuarios usuarios = LlenarClase();

            if (IdnumericUpDown.Value == 0)
            {
                paso = repositorio.Guardar(usuarios);
            }
            else
            {
                paso = repositorio.Modificar(usuarios);
            }
            if (paso)
            {
                MessageBox.Show("Guardado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                byte[] encriptado = Encriptar(Encoding.UTF8.GetBytes(IdnumericUpDown.ToString()));
                Pruebalabel.Text = BitConverter.ToString(encriptado).Replace("-", " ");
            }
            else
            {
                MessageBox.Show("No se pudo guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Limpiar();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id;
            RepositorioBase<Usuarios> repositorioBase = new RepositorioBase<Usuarios>();
            id = (int)IdnumericUpDown.Value;
            Limpiar();
            try
            {
                if (repositorioBase.Eliminar(id))
                {
                    MessageBox.Show("Eliminado correctamente");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo eliminar");
            }
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id;
            RepositorioBase<Usuarios> repositorioBase = new RepositorioBase<Usuarios>();
            Usuarios usuarios = new Usuarios();
            int.TryParse(IdnumericUpDown.Text, out id);
            Limpiar();
            try
            {
                usuarios = repositorioBase.Buscar(id);
                if (usuarios != null)
                {
                    MessageBox.Show("Dia encontrado");
                    LlenarCampo(usuarios);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("No existe el horario");
            }
        }
    }
}
