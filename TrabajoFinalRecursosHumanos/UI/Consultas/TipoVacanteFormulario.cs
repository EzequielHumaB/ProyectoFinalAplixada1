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

namespace TrabajoFinalRecursosHumanos.UI.Consultas
{
    public partial class TipoVacanteFormulario : Form
    {
        public TipoVacanteFormulario()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<TipoVacante> repositorioBase = new RepositorioBase<TipoVacante>();

            var listado = new List<TipoVacante>();
            if (FechacheckBox.Checked == true)
            {
                if (CriteriotextBox.Text.Trim().Length > 0)
                {
                    try
                    {
                        switch (FiltrocomboBox.SelectedIndex)
                        {

                            case 0:
                                listado = repositorioBase.GetList(p => true);
                                break;
                            case 1:
                                listado = repositorioBase.GetList(p => p.NombreTipoVacante.Contains(CriteriotextBox.Text));
                                break;
                            case 2:
                                listado = repositorioBase.GetList(p => p.FechaCreacion.ToString() == CriteriotextBox.Text);
                                break;

                        }
                    }
                    catch (Exception)
                    {

                    }

                }
                else
                    listado = repositorioBase.GetList(p => true);


                ConsultadataGridView.DataSource = null;
                ConsultadataGridView.DataSource = listado;
            }

            else
            {
                if (CriteriotextBox.Text.Trim().Length > 0)
                {
                    try
                    {
                        switch (FiltrocomboBox.SelectedIndex)
                        {

                            case 0:
                                listado = repositorioBase.GetList(p => true);
                                break;
                            case 1:
                                listado = repositorioBase.GetList(p => p.NombreTipoVacante.Contains(CriteriotextBox.Text));
                                break;
                            case 2:
                                listado = repositorioBase.GetList(p => p.FechaCreacion.ToString() == CriteriotextBox.Text);
                                break;
                        }
                    }
                    catch (Exception)
                    {

                    }

                }
                else
                    listado = repositorioBase.GetList(p => true);


                ConsultadataGridView.DataSource = null;
                ConsultadataGridView.DataSource = listado;
            }
        }

        private void CriteriotextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void FiltrocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void HastadateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DesdedateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ConsultadataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void FechacheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
