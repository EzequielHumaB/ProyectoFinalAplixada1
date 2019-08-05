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
using TrabajoFinalRecursosHumanos.UI.Reportes;

namespace TrabajoFinalRecursosHumanos.UI.Consultas
{
    public partial class DepartamentosConsultas : Form
    {
        public List<Departamentos> departamentos;
        public DepartamentosConsultas()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Departamentos> repositorioBase = new RepositorioBase<Departamentos>();

            var listado = new List<Departamentos>();
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
                                listado = repositorioBase.GetList(p => p.NombreDepartamento.Contains(CriteriotextBox.Text));
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


                departamentos = listado;
                ConsultadataGridView.DataSource = departamentos;
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
                                listado = repositorioBase.GetList(p => p.NombreDepartamento.Contains(CriteriotextBox.Text));
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


                departamentos = listado;
                ConsultadataGridView.DataSource = departamentos;
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

                ListaDepartamentos listaDepartamento = new ListaDepartamentos(departamentos);
                listaDepartamento.Show();
            }
        }
    }
}
