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
using TrabajoFinalRecursosHumanos.BLL;

namespace TrabajoFinalRecursosHumanos.UI.Registros
{
    public partial class EmpleadosFormulario : Form
    {
        public EmpleadosFormulario()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        public void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            NombrestextBox.Text = string.Empty;
            ApellidostextBox.Text = string.Empty;
            CedulatextBox.Text = string.Empty;
            FechaIngresodateTimePicker.Value = DateTime.Now;
            SalarionumericUpDown.Value = 0;
            FechaIngresodateTimePicker.Value = DateTime.Now;
            NacionaliddadtextBox.Text = string.Empty;
            EstadoCivil.Text = string.Empty;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private Empleados LlenarClase()
        {
            Empleados empleados = new Empleados();
            try
            {
                empleados.EmpleadoId = (int)IdnumericUpDown.Value;
                empleados.Nombres = NombrestextBox.Text.Trim();
                empleados.Apellidos = ApellidostextBox.Text;
                empleados.Cedula = CedulatextBox.Text;
                empleados.FechaNacimiento = FechaNacimientodateTimePicker.Value;
                empleados.Nacionalidad = NacionaliddadtextBox.Text;
                empleados.EstadoCivil = EstadoCivil.Text;
                empleados.Salario = SalarionumericUpDown.Value;
                empleados.FechaIngreso = FechaIngresodateTimePicker.Value;
            }
            catch (Exception)
            {
                MessageBox.Show("Valor no admitido");
            }
            return empleados;
        }
        private void LlenarCampo(Empleados empleados)
        {
            try
            {
                IdnumericUpDown.Value = empleados.EmpleadoId;
                NombrestextBox.Text = empleados.Nombres;
                ApellidostextBox.Text = empleados.Apellidos;
                CedulatextBox.Text = empleados.Cedula;
                FechaNacimientodateTimePicker.Value = empleados.FechaNacimiento;
                NacionaliddadtextBox.Text = empleados.Nacionalidad;
                EstadoCivil.Text = empleados.EstadoCivil;
                SalarionumericUpDown.Value = empleados.Salario;
                FechaIngresodateTimePicker.Value = empleados.FechaIngreso;
            }
            catch (Exception)
            {
                MessageBox.Show("Valor no admitido");
            }
        }

        public bool Validar()
        {
            bool paso = true;
            if (String.IsNullOrEmpty(NombrestextBox.Text))
            {
                MessageBox.Show("El nombre no puede estar vacio");
                NombrestextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrEmpty(ApellidostextBox.Text))
            {
                MessageBox.Show("El apellido no puede estar vacio");
                ApellidostextBox.Focus();
                paso = false;
            }

            if (CedulatextBox.Text == string.Empty)
            {
                MessageBox.Show("La cedula no puede estar vacia");
                CedulatextBox.Focus();
                paso = false;
            }

       

            if(FechaNacimientodateTimePicker.Value == DateTime.Now)
            {
                MyerrorProvider.SetError(FechaNacimientodateTimePicker, "Fecha invalidad");
                FechaNacimientodateTimePicker.Focus();
                paso = false; 
            }

            if(FechaIngresodateTimePicker.Value > DateTime.Now)
            {
                MyerrorProvider.SetError(FechaIngresodateTimePicker,"Fecha invalidad");
                FechaIngresodateTimePicker.Focus();
                paso = false;
            }

            if(SalarionumericUpDown.Value == 0)
            {
                MyerrorProvider.SetError(SalarionumericUpDown,"El salario no puede ser cero");
                SalarionumericUpDown.Focus();
                paso = false;
            }
            return paso;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Empleados> repositorio = new RepositorioBase<Empleados>();
            Empleados empleados = repositorio.Buscar((int)IdnumericUpDown.Value);
            return (empleados != null);
        }



        private void GuardarButton_Click(object sender, EventArgs e)
        {

            RepositorioBase<Empleados> repositorio = new RepositorioBase<Empleados>();
            bool paso = false;

            if (!Validar())
                return;

            Empleados empleado = LlenarClase();

            if (IdnumericUpDown.Value == 0)
            {
                paso = repositorio.Guardar(empleado);
            }
            else
            {      
               paso = repositorio.Modificar(empleado); 
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

      
       
        private void LlenarComboxDepartamento()
        {
            var listado = new List<Horarios>();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id;
            id = (int)IdnumericUpDown.Value;
            Limpiar();
            try
            {
                if (ContratosBLL.Eliminar(id))
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
            RepositorioBase<Empleados> repositorio = new RepositorioBase<Empleados>();
            Empleados empleados = new Empleados();
            int.TryParse(IdnumericUpDown.Text, out id);
            //id = (int)IDnumericUpDown.Value;
            Limpiar();
            try
            {
                empleados = repositorio.Buscar(id);
                if (empleados != null)
                {
                    MessageBox.Show("Empleado encontrado");
                    LlenarCampo(empleados);
                }
                else
                {
                    MessageBox.Show("Empleado no encontrado");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No existe el empleado");
            }
        }

        private void AgregarVacantebutton_Click(object sender, EventArgs e)
        {
            FoTipoVacantermulario foTipoVacantermulario = new FoTipoVacantermulario();
            foTipoVacantermulario.StartPosition = FormStartPosition.CenterScreen;
            foTipoVacantermulario.ShowDialog();
        }

        private void LlenarComboBox()
        {
            var listado = new List<TipoVacante>();
            RepositorioBase<TipoVacante> repositorioBase = new RepositorioBase<TipoVacante>();
            listado = repositorioBase.GetList(p => true);
            VacantecomboBox.DataSource = listado;
            VacantecomboBox.DisplayMember = "NombreTipoVacante";
            VacantecomboBox.ValueMember = "TipoVacanteId";
        }
    }
}
