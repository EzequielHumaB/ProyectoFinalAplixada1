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

namespace TrabajoFinalRecursosHumanos.UI.Registros
{
    public partial class HorariosFormulario : Form
    {
        public HorariosFormulario()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            HorariodateTimePicker.Value = DateTime.Now;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private Horarios LlenarClase()
        {
            Horarios horarios = new Horarios();
            horarios.HorarioId = (int)IdnumericUpDown.Value;
            horarios.HorarioEntrada = (DateTime)HorariodateTimePicker.Value;
            return horarios;
        }

        private void LlenarCampo(Horarios horarios)
        {
            IdnumericUpDown.Value = horarios.HorarioId;
            HorariodateTimePicker.Value = horarios.HorarioEntrada;
        }

        private bool Validar()
        {
            bool paso = true;
         
            if (HorariodateTimePicker.Value.Hour < 7)
            {
                MessageBox.Show("A esa hora no se trabaja");
                HorariodateTimePicker.Focus();
                paso = false;
            }

            return paso;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Horarios> repositorioBase = new RepositorioBase<Horarios>();
            Horarios horarios;
            ;
            bool paso = false;

            if (!Validar())
                return;

            horarios = LlenarClase();

            if (IdnumericUpDown.Value == 0)
            {
                paso = repositorioBase.Guardar(horarios);
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id = Convert.ToInt32(IdnumericUpDown.Value);
                horarios = repositorioBase.Buscar(id);
                if (horarios != null)
                {
                    paso = repositorioBase.Modificar(LlenarClase());
                    MessageBox.Show("Modificado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Id no existe", "Falló", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (paso)
            {
                Limpiar();
            }
            else
                MessageBox.Show("No se pudo guardar!!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id;
            RepositorioBase<Horarios> repositorioBase = new RepositorioBase<Horarios>();
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
            RepositorioBase<Horarios> repositorioBase = new RepositorioBase<Horarios>();
            Horarios horarios = new Horarios();
            int.TryParse(IdnumericUpDown.Text, out id);
            Limpiar();
            try
            {
                horarios = repositorioBase.Buscar(id);
                if (horarios != null)
                {
                    MessageBox.Show("Dia encontrado");
                    LlenarCampo(horarios);
                }
         
            }
            catch (Exception)
            {
                MessageBox.Show("No existe el horario");
            }
        }

        private void HorariodateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            HorariodateTimePicker.Format = DateTimePickerFormat.Custom;
            HorariodateTimePicker.CustomFormat = "hh;mmv tt";
        }
    }
}
