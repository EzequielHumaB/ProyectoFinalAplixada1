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
            LlenarCombox();
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
            FechadateTimePicker.Value = DateTime.Now;
            ContraseñatextBox.Text = string.Empty;
            ConfirmarContraseñatextBox.Text = string.Empty;
            NivelcUsuarioomboBox.Text = string.Empty;
        }
        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private Usuarios LlenarClase()
        {
            Usuarios usuarios = new Usuarios();
            GenerarLlave();
            byte[] encriptado = Encriptar(Encoding.UTF8.GetBytes(ContraseñatextBox.ToString()));
            byte[] desencriptado = DesEncriptar(encriptado);
            usuarios.UsuarioId = (int)IdnumericUpDown.Value;
            usuarios.Usuario = NombretextBox.Text;
            usuarios.ClaveUsuario = BitConverter.ToString(encriptado).Replace("-", " ");
            usuarios.ConfirmarClaveUsuario = ConfirmarContraseñatextBox.Text;
            usuarios.NivelUsuario = NivelcUsuarioomboBox.Text;
            return usuarios;
        }

        //Llenar campos
        private void LlenarCampo(Usuarios usuarios)
        {
            IdnumericUpDown.Value = usuarios.UsuarioId;
            NombretextBox.Text = usuarios.Usuario;
            NivelcUsuarioomboBox.Text = usuarios.NivelUsuario;
            ContraseñatextBox.Text = usuarios.ConfirmarClaveUsuario;
            ConfirmarContraseñatextBox.Text = usuarios.ConfirmarClaveUsuario;
        }

        //Validar
        private bool Validar()
        {
            bool paso = true;
            if(string.IsNullOrEmpty(NombretextBox.Text))
            {
                MyerrorProvider.SetError(NombretextBox, "El usuario no puede estar vacio");
                NombretextBox.Focus();
                paso = false;
            }

            if(FechadateTimePicker.Value > DateTime.Now)
            {
                MyerrorProvider.SetError(FechadateTimePicker,"Fecha invalida");
                FechadateTimePicker.Focus();
                paso = false;
            }
            if (NombretextBox.Text.Length <2)
            {
                MyerrorProvider.SetError(NombretextBox, "El nombre debe tener al menos 2 caracteres'");
                NombretextBox.Focus();
                paso = false;
            }

            if(NivelcUsuarioomboBox.Text == string.Empty)
            {
                MyerrorProvider.SetError(NivelcUsuarioomboBox, "El nivel de usaurio no puede estar vacio");
                NivelcUsuarioomboBox.Focus();
                paso = false;
            }

            if (ContraseñatextBox.Text.Trim().Length <=7)
            {
                MyerrorProvider.SetError(ContraseñatextBox,"La contraseña debe tener al menos 8 caracteres");
                ContraseñatextBox.Focus();
                paso = false;
            }

            if(ConfirmarContraseñatextBox.Text != ContraseñatextBox.Text)
            {
                MyerrorProvider.SetError(ConfirmarContraseñatextBox,"Confirmacion incorrecta");
                ConfirmarContraseñatextBox.Focus();
                paso = false;
            }

            if(string.IsNullOrEmpty(ContraseñatextBox.Text))
            {
                MyerrorProvider.SetError(ContraseñatextBox, "La contraseña no puede estar vacia");
                ContraseñatextBox.Focus();
                paso = false;
            }

            if(string.IsNullOrEmpty(ConfirmarContraseñatextBox.Text))
            {

                MyerrorProvider.SetError(ConfirmarContraseñatextBox, "La confirmacion no puede estar vacia");
                ConfirmarContraseñatextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private bool NoRepetidos()
        {
            bool paso = true;
            if (Validaciones.PalabrasNoIguales(NombretextBox.Text))
            {
                MyerrorProvider.SetError(NombretextBox, "Los nombres de Usuarios no pueden ser iguales");
                NombretextBox.Focus();
                paso = false;
            }

            if(Validaciones.ContraseñasNoIguales(ConfirmarContraseñatextBox.Text))
            {
                MyerrorProvider.SetError(ConfirmarContraseñatextBox, "Esta contraseña ya existe");
                ConfirmarContraseñatextBox.Focus();
                paso = false;               
            }

            return paso;
        }

        private void NombreSoloLetrasValidacion(KeyPressEventArgs e)
        {
            try
            {
                if(char.IsLetter(e.KeyChar))
                   e.Handled = false;
                else if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if(char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }

            }catch
            {

            }
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            bool paso = false;

            if (!Validar())
                return;

            Usuarios usuario = LlenarClase();

            if (IdnumericUpDown.Value == 0)
            {
                if (!NoRepetidos())
                    return;
                paso = repositorio.Guardar(usuario);
            }
            else
            {
                paso = repositorio.Modificar(usuario);
            }
            if (paso)
            {
                MessageBox.Show("Guardado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void LlenarCombox()
        {
            NivelcUsuarioomboBox.Items.Add("Administrador");
            NivelcUsuarioomboBox.Items.Add("Secretario");
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id;
            RepositorioBase<Usuarios> repositorioBase = new RepositorioBase<Usuarios>();
            Usuarios usuarios = new Usuarios();
      //      int.TryParse(IdnumericUpDown.Text, out id);
            id = (int)IdnumericUpDown.Value;
            Limpiar();
            try
            {
                usuarios = repositorioBase.Buscar(id);
                if (usuarios != null)
                {
                    MessageBox.Show("Usuario encontrado");
                    LlenarCampo(usuarios);
                }
                else
                {
                    MessageBox.Show("Usuari no encontrado");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No existe el usuario");
            }
        }

        private void NombretextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            NombreSoloLetrasValidacion(e);
        }
    }
}
