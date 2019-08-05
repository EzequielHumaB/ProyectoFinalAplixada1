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

namespace TrabajoFinalRecursosHumanos.UI.Registros
{
    public partial class EmpleadosFormulario : Form
    {
        public EmpleadosFormulario()
        {
            InitializeComponent();
            LlenarComboBox();
            LlenarEstadoCivilComboBox();
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
            EstadoCivilcomboBox.Text = string.Empty;
            TelefonotextBox.Text = string.Empty;
            CelulartextBox.Text = string.Empty;
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
                empleados.EstadoCivil = EstadoCivilcomboBox.Text;
                empleados.Salario = SalarionumericUpDown.Value;
                empleados.FechaIngreso = FechaIngresodateTimePicker.Value;
                empleados.Celular = CelulartextBox.Text;
                empleados.Telefono = TelefonotextBox.Text;
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
                EstadoCivilcomboBox.Text = empleados.EstadoCivil;
                SalarionumericUpDown.Value = empleados.Salario;
                FechaIngresodateTimePicker.Value = empleados.FechaIngreso;
                TelefonotextBox.Text = empleados.Telefono;
                CelulartextBox.Text = empleados.Celular;
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

            if(EstadoCivilcomboBox.Text !="Soltero" & EstadoCivilcomboBox.Text !="Casado" & EstadoCivilcomboBox.Text !="Divorciado" 
                &EstadoCivilcomboBox.Text!= "Viudo")
            {
                MyerrorProvider.SetError(EstadoCivilcomboBox, "Tienes que elegir una de las opciones");
                EstadoCivilcomboBox.Focus();
                paso = false;
            }
           
            if (CedulatextBox.Text == string.Empty)
            {
                MessageBox.Show("La cedula no puede estar vacia");
                CedulatextBox.Focus();
                paso = false;
            }

            if(CedulatextBox.Text.Length != 11)
            {
                MyerrorProvider.SetError(CedulatextBox,"Cedula invalida");
                CedulatextBox.Focus();
                paso = false;
            }

            if(NombrestextBox.Text.Length <2)
            {
                MyerrorProvider.SetError(NombrestextBox, "Nombre invalido");
                NombrestextBox.Focus();
                paso = false;
            }

            if(ApellidostextBox.Text.Length < 2)
            {
                MyerrorProvider.SetError(ApellidostextBox, "Apellido invalido");
                ApellidostextBox.Focus();
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


            if(TelefonotextBox.Text.Length <10)
            {
                MyerrorProvider.SetError(TelefonotextBox, "Telefono invalido");
                TelefonotextBox.Focus();
                paso = false;
            }
                
            if(CelulartextBox.Text.Length  != 10)
            {
                MyerrorProvider.SetError(CelulartextBox, "Celular invalido");
                CelulartextBox.Focus();
                paso = false;
            }

            if (SalarionumericUpDown.Value == 0)
            {
                MyerrorProvider.SetError(SalarionumericUpDown,"El salario no puede ser cero");
                SalarionumericUpDown.Focus();
                paso = false;
            }


             
            return paso;
        }

        private bool NoRepetido()
        {
            bool paso = true;
            if (Validaciones.TelefonosNoIguales(TelefonotextBox.Text))
            {
                MyerrorProvider.SetError(TelefonotextBox, "Este telefono ya existe");
                TelefonotextBox.Focus();
                paso = false;
            }

            if (Validaciones.CedulasNoIguales(CedulatextBox.Text))
            {
                MyerrorProvider.SetError(CedulatextBox, "Ya existe esta cedula");
                CedulatextBox.Focus();
                paso = false;
            }
            if(Validaciones.CedulasNoIguales(CelulartextBox.Text))
            {
                MyerrorProvider.SetError(CelulartextBox,"Esta cedula ya existe");
                CelulartextBox.Focus();
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
                if (!NoRepetido())
                    return;
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
            RepositorioBase<Empleados> repositorioBase = new RepositorioBase<Empleados>();
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
            RepositorioBase<Empleados> repositorio = new RepositorioBase<Empleados>();
            Empleados empleados = new Empleados();
            int.TryParse(IdnumericUpDown.Text, out id);
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

     
        public void SoloNumero(KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if(char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if(char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void CedulatextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumero(e);  
        }

        private void TelefonotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumero(e);
        }

        private void CelulartextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumero(e);
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

        private void NombrestextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            NombreSoloLetrasValidacion(e);
        }

        private void ApellidostextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            NombreSoloLetrasValidacion(e);
        }

     private void LlenarEstadoCivilComboBox()
        {
            EstadoCivilcomboBox.Items.Add("Soltero");
            EstadoCivilcomboBox.Items.Add("Casado");
            EstadoCivilcomboBox.Items.Add("Divorciado");
            EstadoCivilcomboBox.Items.Add("Viudo");
        }

        private void VacantecomboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            
        }
    }
}
