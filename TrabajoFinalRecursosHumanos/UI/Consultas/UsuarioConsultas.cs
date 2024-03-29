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
    public partial class UsuarioConsultas : Form
    {
        public List<Usuarios> Usuarios;
        public UsuarioConsultas()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repositorioBase = new RepositorioBase<Usuarios>();

            var listado = new List<Usuarios>();
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
                                listado = repositorioBase.GetList(p => p.Usuario.Contains(CriteriotextBox.Text));
                                break;
                            case 2:
                                listado = repositorioBase.GetList(p => p.FechaCreacion.ToString() == CriteriotextBox.Text);
                                break;
                            case 3:
                                listado = repositorioBase.GetList(p => p.NivelUsuario.Contains(CriteriotextBox.Text));
                                break;
                        }
                    }
                    catch (Exception)
                    {

                    }

                }
                else
                    listado = repositorioBase.GetList(p => true);


                Usuarios = listado;
                ConsultadataGridView.DataSource = Usuarios;
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
                                listado = repositorioBase.GetList(p => p.Usuario.Contains(CriteriotextBox.Text));
                                break;
                            case 2:
                                listado = repositorioBase.GetList(p => p.FechaCreacion.ToString() == CriteriotextBox.Text);
                                break;
                            case 3:
                                listado = repositorioBase.GetList(p => p.NivelUsuario.Contains(CriteriotextBox.Text));
                                break;
                        }
                    }
                    catch (Exception)
                    {

                    }

                }
                else
                    listado = repositorioBase.GetList(p => true);


                Usuarios = listado;
                ConsultadataGridView.DataSource = Usuarios;
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

                ListaUsuarios ListaUsuarios = new ListaUsuarios(Usuarios);
                ListaUsuarios.Show();
            }
        }
    }
}
