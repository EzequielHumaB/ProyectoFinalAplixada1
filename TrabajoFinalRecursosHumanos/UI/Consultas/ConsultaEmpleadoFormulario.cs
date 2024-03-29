﻿using System;
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
    public partial class ConsultaEmpleadoFormulario : Form
    {
        public List<Empleados> empleados;
        public ConsultaEmpleadoFormulario()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
             
            RepositorioBase<Empleados> repositorioBase = new RepositorioBase<Empleados>();

            var listado = new List<Empleados>();
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
                                listado = repositorioBase.GetList(p => p.Nombres.Contains(CriteriotextBox.Text));
                                break;
                            case 2:
                                listado = repositorioBase.GetList(p => p.Apellidos.ToString() == CriteriotextBox.Text);
                                break;
                            case 3:
                                listado = repositorioBase.GetList(p => p.Cedula.Contains(CriteriotextBox.Text));
                                break;
                            case 4:
                                listado = repositorioBase.GetList(p => p.Nacionalidad.Contains(CriteriotextBox.Text));
                                break;
                        }
                    }
                    catch (Exception)
                    {

                    }

                }
                else
                    listado = repositorioBase.GetList(p => true);


                empleados = listado;
                ConsultadataGridView.DataSource = empleados;
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
                                listado = repositorioBase.GetList(p => p.Nombres.Contains(CriteriotextBox.Text));
                                break;
                            case 2:
                                listado = repositorioBase.GetList(p => p.Apellidos.ToString() == CriteriotextBox.Text);
                                break;
                            case 3:
                                listado = repositorioBase.GetList(p => p.Cedula.Contains(CriteriotextBox.Text));
                                break;
                            case 4:
                                listado = repositorioBase.GetList(p => p.Nacionalidad.Contains(CriteriotextBox.Text));
                                break;
                        }
                    }
                    catch (Exception)
                    {

                    }

                }
                else
                    listado = repositorioBase.GetList(p => true);


                empleados = listado;
                ConsultadataGridView.DataSource = empleados;
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

                ListaEmpleados listaEmpleados = new ListaEmpleados(empleados);
                listaEmpleados.Show();
            }

        }
    }
}
