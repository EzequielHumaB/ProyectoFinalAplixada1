using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RecursosHumanosBLL;
using Entidades;

namespace TrabajoFinalRecursosHumanos.UI.Registros
{
    public partial class FoTipoVacantermulario : Form
    {
        int controla;
        public FoTipoVacantermulario()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            NombreVacantetextBox.Text = string.Empty;
            FechaCreaciondateTimePicker.Value = DateTime.Now;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<TipoVacante> repositorio = new RepositorioBase<TipoVacante>();
            bool paso = false;

            if (!Validar())
                return;

            TipoVacante tipoVacante = LlenarClase();

            if (IdnumericUpDown.Value == 0)
            {
                if (!NoRepetidos())
                    return;
                paso = repositorio.Guardar(tipoVacante);
            }
            else if(IdnumericUpDown.Value!=controla)
            {
                MessageBox.Show("Se ha cambiado el id");
                return;
            }                       
            else
            {    
                paso = repositorio.Modificar(tipoVacante);
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
        public TipoVacante LlenarClase()
        {
            TipoVacante tipoVacante = new TipoVacante();
            tipoVacante.TipoVacanteId = (int)IdnumericUpDown.Value;
            tipoVacante.NombreTipoVacante = NombreVacantetextBox.Text;
            tipoVacante.FechaCreacion = FechaCreaciondateTimePicker.Value;
            return tipoVacante;
        }

        private void LlenarCampo(TipoVacante tipovacante)
        {
            IdnumericUpDown.Value = tipovacante.TipoVacanteId;
            NombreVacantetextBox.Text = tipovacante.NombreTipoVacante;
            FechaCreaciondateTimePicker.Value = tipovacante.FechaCreacion;
        }

        private bool Validar()
        {
            bool paso = true;
            if (string.IsNullOrEmpty(NombreVacantetextBox.Text))
            {
                MyerrorProvider.SetError(NombreVacantetextBox, "El nombre no puede estar vacio");
                NombreVacantetextBox.Focus();
                paso = false;
            }

            if(NombreVacantetextBox.Text.Length<5)
            {
                MyerrorProvider.SetError(NombreVacantetextBox,"Vacante invalida");
                NombreVacantetextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private bool NoRepetidos()
        {
            bool paso = true;
            if(Validaciones.VacantesNoIguales(NombreVacantetextBox.Text))
            {
                MyerrorProvider.SetError(NombreVacantetextBox, "La vacante ya existe");
                NombreVacantetextBox.Focus();
                paso = false;
            }
            return paso;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Eliminarbutton_Click_1(object sender, EventArgs e)
        {
            int id;
            id = (int)IdnumericUpDown.Value;
            RepositorioBase<TipoVacante> repositorioBase = new RepositorioBase<TipoVacante>();
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

        private void Buscarbutton_Click_1(object sender, EventArgs e)
        {
            int id;
            RepositorioBase<TipoVacante> repositorioBase = new RepositorioBase<TipoVacante>();
            TipoVacante tipoVacante = new TipoVacante();
            int.TryParse(IdnumericUpDown.Text, out id);
            controla = id;
            Limpiar();
            try
            {
                tipoVacante = repositorioBase.Buscar(id);
                if (tipoVacante != null)
                {
                    MessageBox.Show("Vacante encontrada");
                    LlenarCampo(tipoVacante);
                }
                else
                {
                    MessageBox.Show("Vacante no encontrada");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No existe la vacante");
            }
        }

        private void NombreSoloLetrasValidacion(KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetter(e.KeyChar))
                    e.Handled = false;
                else if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }

            }
            catch
            {

            }
        }

        private void NombreVacantetextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            NombreSoloLetrasValidacion(e);
        }

    }
}
