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
using TrabajoFinalRecursosHumanos.UI.Reportes;

namespace TrabajoFinalRecursosHumanos.UI.Consultas
{
    public partial class TipoVacanteFormulario : Form
    {
        public List<TipoVacante> tipoVacantes;
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


                tipoVacantes = listado;
                ConsultadataGridView.DataSource = tipoVacantes;
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


                tipoVacantes = listado;
                ConsultadataGridView.DataSource = tipoVacantes;
            }
        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {
            if (ConsultadataGridView.RowCount == 0)
            {
                MessageBox.Show("No hay Datos Para Imprimir");
                return;
            }
            else
            {

                ListaVacantes listaVacantes = new ListaVacantes(tipoVacantes);
                listaVacantes.Show();
            }
        }
    }
}
