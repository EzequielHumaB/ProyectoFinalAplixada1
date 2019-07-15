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
using TrabajoFinalRecursosHumanos.BLL;

namespace TrabajoFinalRecursosHumanos.UI.Registros
{
    public partial class ContratoFormulario : Form
    {
        public ContratoFormulario()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            SegurotextBox.Text = string.Empty;
            DescripciontextBox.Text = string.Empty;
            SueldonumericUpDown.Value = 0;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public Contratos LlenarClase()
        {
            Contratos contratos = new Contratos();
            contratos.ContratoId = (int)IdnumericUpDown.Value;
            contratos.DescripcionContrato = DescripciontextBox.Text;
            contratos.Seguro = SegurotextBox.Text;
            contratos.Sueldo = SueldonumericUpDown.Value;
            return contratos;
        }

        private void LlenarCampo(Contratos contratos)
        {
            IdnumericUpDown.Value = contratos.ContratoId;
            DescripciontextBox.Text = contratos.DescripcionContrato;
            SegurotextBox.Text = contratos.Seguro;
            SueldonumericUpDown.Value = contratos.Sueldo;
        }

        private bool Validar()
        {
            bool paso = true;
            if(string.IsNullOrEmpty(DescripciontextBox.Text))
            {
                MyErrorProvider.SetError(DescripciontextBox, "La descripcion no puede estar vacia");
                DescripciontextBox.Focus();
                paso = false;
            }
            if(string.IsNullOrEmpty(SegurotextBox.Text))
            {
                MyErrorProvider.SetError(SegurotextBox,"El seguro no puede estar vacio");
                SegurotextBox.Focus();
                paso = false;
            }
            if(SueldonumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(SueldonumericUpDown,"El sueldo no puede ser cero");
                SueldonumericUpDown.Focus();
                paso = false;
            }
            return paso;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Contratos> repositorioBase = new RepositorioBase<Contratos>();

            Contratos contratos;               
            bool paso = false;

            if (!Validar())
                return;

            contratos = LlenarClase();

            if (IdnumericUpDown.Value == 0)
            {
                paso = repositorioBase.Guardar(contratos);
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id = Convert.ToInt32(IdnumericUpDown.Value);
                contratos = repositorioBase.Buscar(id);
                if (contratos != null)
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
            id = (int)IdnumericUpDown.Value;
            RepositorioBase<Contratos> repositorioBase = new RepositorioBase<Contratos>();
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
            RepositorioBase<Contratos> repositorioBase = new RepositorioBase<Contratos>();
            Contratos contratos = new Contratos();
            int.TryParse(IdnumericUpDown.Text, out id);
            //id = (int)IDnumericUpDown.Value;
            Limpiar();
            try
            {
                contratos = repositorioBase.Buscar(id);
                if (contratos != null)
                {
                    MessageBox.Show("Contrado encontrado");
                    LlenarCampo(contratos);
                }
                else
                {
                    MessageBox.Show("Contrato no encontrado");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No existe el contrato");
            }
        }
    }
}
