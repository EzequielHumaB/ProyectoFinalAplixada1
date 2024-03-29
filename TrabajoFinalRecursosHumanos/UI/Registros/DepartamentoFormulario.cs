﻿using System;
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
    public partial class DepartamentoFormulario : Form
    {
        int controla;
        public DepartamentoFormulario()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            NombreDepartamentotextBox.Text = string.Empty;
            FechaCreaciondateTimePicker.Value = DateTime.Now;
        }
        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private Departamentos LlenarClase()
        {
            Departamentos departamentos = new Departamentos();
            departamentos.DepartamentoId = (int)IdnumericUpDown.Value;
            departamentos.FechaCreacion = (DateTime)FechaCreaciondateTimePicker.Value;
            departamentos.NombreDepartamento = NombreDepartamentotextBox.Text;
            return departamentos;
        }

        private void LlenarCampo(Departamentos departamentos)
        {
            IdnumericUpDown.Value = departamentos.DepartamentoId;
            NombreDepartamentotextBox.Text = departamentos.NombreDepartamento;
            FechaCreaciondateTimePicker.Value = departamentos.FechaCreacion;
        }

        private bool Validar()
        {
            bool paso = true;
            if (string.IsNullOrEmpty(NombreDepartamentotextBox.Text))
            {
                MyerrorProvider.SetError(NombreDepartamentotextBox, "El nombre no puede estar vacio");
                NombreDepartamentotextBox.Focus();
                paso = false;
            }
            if(NombreDepartamentotextBox.Text.Length<3)
             {
                MyerrorProvider.SetError(NombreDepartamentotextBox, "Nombre ivalido");
                NombreDepartamentotextBox.Focus();
                paso = false;
            }
         
            return paso;
        }

        private bool NoRepetidos()
        {
            bool paso = true;
            if(Validaciones.DepartamentosNoIguales(NombreDepartamentotextBox.Text))
            {
                MyerrorProvider.SetError(NombreDepartamentotextBox, "El departamento ya existe");
                NombreDepartamentotextBox.Focus();
                paso = false;
            }
            return paso;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Departamentos> repositorio = new RepositorioBase<Departamentos>();
            bool paso = false;

            if (!Validar())
                return;

            Departamentos departamentos = LlenarClase();

            if (IdnumericUpDown.Value == 0)
            {
                if (!NoRepetidos())
                    return;
                paso = repositorio.Guardar(departamentos);
            }
            else if(IdnumericUpDown.Value!=controla)
            {
                MessageBox.Show("Se ha camiado el id");
                return;
            }
            else
            {
               paso = repositorio.Modificar(departamentos); 
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
            id = (int)IdnumericUpDown.Value;
            RepositorioBase<Departamentos> repositorioBase = new RepositorioBase<Departamentos>();
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
            RepositorioBase<Departamentos> repositorioBase = new RepositorioBase<Departamentos>();
            Departamentos departamentos = new Departamentos();
            int.TryParse(IdnumericUpDown.Text, out id);
            controla = id;
            Limpiar();
            try
            {
                departamentos = repositorioBase.Buscar(id);
                if (departamentos != null)
                {
                    MessageBox.Show("Departamwnto encontrado");
                    LlenarCampo(departamentos);
                }
                else
                {
                    MessageBox.Show("Departamento no encontrado");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No existe el departamento");
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
        private void NombreDepartamentotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            NombreSoloLetrasValidacion(e);
        }
    }
}
