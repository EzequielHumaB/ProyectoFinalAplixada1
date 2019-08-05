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
        public UsuarioFormulario()
        {
            InitializeComponent();
            LlenarCombox();
        }

        public string Encriptar(string cadenaEncriptada)
        {
            string resultado = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(cadenaEncriptada);
            resultado = Convert.ToBase64String(encryted);

            return resultado;
        }

        public string DesEncriptar(string cadenaDesencriptada)
        {
            string resultado = string.Empty;
            byte[] decryted = Convert.FromBase64String(cadenaDesencriptada);
            resultado = System.Text.Encoding.Unicode.GetString(decryted);

            return resultado;
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
            usuarios.UsuarioId = (int)IdnumericUpDown.Value;
            usuarios.Usuario = NombretextBox.Text;
            usuarios.ClaveUsuario = Encriptar(ContraseñatextBox.Text.Trim());
            usuarios.NivelUsuario = NivelcUsuarioomboBox.Text;
            return usuarios;
        }

        //Llenar campos
        private void LlenarCampo(Usuarios usuarios)
        {
            IdnumericUpDown.Value = usuarios.UsuarioId;
            NombretextBox.Text = usuarios.Usuario;
            NivelcUsuarioomboBox.Text = usuarios.NivelUsuario;
            ContraseñatextBox.Text = DesEncriptar(usuarios.ClaveUsuario);
            ConfirmarContraseñatextBox.Text = DesEncriptar(usuarios.ClaveUsuario);
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
            if(NivelcUsuarioomboBox.Text != "Administrador" & NivelcUsuarioomboBox.Text != "Solo Usuario")
            {
                MyerrorProvider.SetError(NivelcUsuarioomboBox, "Tienes que elegir una de las opciones");
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
                MyerrorProvider.SetError(ConfirmarContraseñatextBox,"la contraseña no es igual a la confirmacion de la contraseña");
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
            NivelcUsuarioomboBox.Items.Add("Solo Usuario");
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
