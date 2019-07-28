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

namespace TrabajoFinalRecursosHumanos.UI.Consultas
{
    public partial class ConsultaDeContratos : Form
    {
        public ConsultaDeContratos()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {

            var listado = new List<Contratos>();
            if (FechacheckBox.Checked == true)
            {
                if (CriteriotextBox.Text.Trim().Length > 0)
                {
                    try
                    {
                        switch (FiltrocomboBox.SelectedIndex)
                        {

                            case 0:
                                listado = ContratosBLL.GetList(p => true);
                                break;
                            case 1:
                                listado = ContratosBLL.GetList(p => p.Horarios.ToString() ==CriteriotextBox.Text);
                                break;
                            case 2:
                                listado = ContratosBLL.GetList(p => p.Salario.ToString() == CriteriotextBox.Text);
                                break;
                            case 3:
                                listado = ContratosBLL.GetList(p => p.Seguro.Contains(CriteriotextBox.Text));
                                break;
                            case 4:
                                listado = ContratosBLL.GetList(p => p.Puesto.Contains(CriteriotextBox.Text));
                                break;
                        }
                    }
                    catch (Exception)
                    {

                    }

                }
                else
                    listado = ContratosBLL.GetList(p => true);


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
                                listado = ContratosBLL.GetList(p => true);
                                break;
                            case 1:
                                listado = ContratosBLL.GetList(p => p.Horarios.ToString() == CriteriotextBox.Text);
                                break;
                            case 2:
                                listado = ContratosBLL.GetList(p => p.Salario.ToString() == CriteriotextBox.Text);
                                break;
                            case 3:
                                listado = ContratosBLL.GetList(p => p.Seguro.Contains(CriteriotextBox.Text));
                                break;
                            case 4:
                                listado = ContratosBLL.GetList(p => p.Puesto.Contains(CriteriotextBox.Text));
                                break;
                        }
                    }
                    catch (Exception)
                    {

                    }

                }
                else
                    listado = ContratosBLL.GetList(p => true);


                ConsultadataGridView.DataSource = null;
                ConsultadataGridView.DataSource = listado;
            }
        }
    }
}
