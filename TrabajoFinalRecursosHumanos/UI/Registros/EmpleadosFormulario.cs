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
        public List<Horarios> Horarios { get; set; }
        public EmpleadosFormulario()
        {
            InitializeComponent();
            Horarios = new List<Horarios>();
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
            this.Horarios = new List<Horarios>();
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
                empleados.Horarios = this.Horarios;
                CargarGrid();
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
                this.Horarios = empleados.Horarios;
                CargarGrid();
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

            if (this.Horarios.Count == 0)
            {
                MyerrorProvider.SetError(DetalledataGridView, "Tienes que ingresar un Horario");
                IdnumericUpDown.Focus();
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
            Empleados empleados = EmpleadosBLL.Buscar((int)IdnumericUpDown.Value);
            return (empleados != null);
        }

        public void CargarGrid()
        {
            DetalledataGridView.DataSource = null;
            DetalledataGridView.DataSource = Horarios;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Empleados empleados
                ;
            bool paso = false;

            if (!Validar())
                return;

            empleados = LlenarClase();

            if (IdnumericUpDown.Value == 0)
            {
                paso = EmpleadosBLL.Guardar(empleados);
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id = Convert.ToInt32(IdnumericUpDown.Value);
                empleados = EmpleadosBLL.Buscar(id);
                if (empleados != null)
                {
                    paso = EmpleadosBLL.Modificar(LlenarClase());
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

        private void AgregarenelGridbutton_Click(object sender, EventArgs e)
        {
            if (DetalledataGridView.DataSource != null)
                this.Horarios = (List<Horarios>)DetalledataGridView.DataSource;

            this.Horarios.Add(
                new Horarios(
                    IdHorario:0,
                    FechasHorario:(DateTime)HorariocomboBox.SelectedValue,
                    IdEmpleado: (int)IdnumericUpDown.Value
                    ));
            CargarGrid();
            IdnumericUpDown.Focus();
        }

        private void AgregarGrid_Click(object sender, EventArgs e)
        {
            if (DetalledataGridView.Rows.Count > 0 && DetalledataGridView.CurrentRow != null)
            {
                //remover la fila
                Horarios.RemoveAt(DetalledataGridView.CurrentRow.Index);
                CargarGrid();
            }
        }

        private void LlenarComboxHorario()
        {
            var listado = new List<Empleados>();
            listado = EmpleadosBLL.GetList(p => true);
            HorariocomboBox.DataSource = listado;
            HorariocomboBox.DisplayMember = "HorarioFechas";
            HorariocomboBox.ValueMember = "HorarioId";
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
                if (EmpleadosBLL.Eliminar(id))
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
            Empleados empleados = new Empleados();
            int.TryParse(IdnumericUpDown.Text, out id);
            //id = (int)IDnumericUpDown.Value;
            Limpiar();
            try
            {
                empleados = EmpleadosBLL.Buscar(id);
                if (empleados != null)
                {
                    MessageBox.Show("Empleado encontrado");
                    LlenarCampo(empleados);
                }
                else
                {
                    MessageBox.Show("Empleado no encontrada");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No existe el empleado");
            }
        }

        private void AgregarHorariobutton_Click(object sender, EventArgs e)
        {
            HorariosFormulario horarios = new HorariosFormulario();
            horarios.StartPosition = FormStartPosition.CenterScreen;
            horarios.ShowDialog();
        }
    }
}
