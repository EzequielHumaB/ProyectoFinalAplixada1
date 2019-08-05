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
    public partial class ContratoFormulario : Form
    {
        public List<Horarios> Horarios;
        public ContratoFormulario()
        {
            Horarios = new List<Horarios>();  
            InitializeComponent();
            LlenarComboBox();
        }

        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            SegurotextBox.Text = string.Empty;
            DescripciontextBox.Text = string.Empty;
            SueldonumericUpDown.Value = 0;
            PrecioPorHorasnumericUpDown.Value = 0;
            IdEmpleadonumericUpDown.Value = 0;
            HorarioDelEmpleadodateTimePicker.Value = DateTime.Now;
            HorarioSalidadateTimePicker.Value = DateTime.Now;
            IdEmpleadonumericUpDown.Value = 0;
            IdDelHorarionumericUpDown.Value = 0;
            FechaCreaciondateTimePicker.Value = DateTime.Now;
            CargarGrid();
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
            contratos.Salario = SueldonumericUpDown.Value;
            contratos.Horarios = this.Horarios;
            contratos.FechaCreacion = FechaCreaciondateTimePicker.Value;
            contratos.EmpleadoId = (int)IdEmpleadonumericUpDown.Value;
            CargarGrid();
            return contratos;
        }

        private void LlenarCampo(Contratos contratos)
        {
            IdnumericUpDown.Value = contratos.ContratoId;
            DescripciontextBox.Text = contratos.DescripcionContrato;
            SegurotextBox.Text = contratos.Seguro;
            SueldonumericUpDown.Value = contratos.Salario;
            IdEmpleadonumericUpDown.Value = contratos.EmpleadoId;
            FechaCreaciondateTimePicker.Value = contratos.FechaCreacion;
            IdEmpleadonumericUpDown.Value = contratos.EmpleadoId;
            this.Horarios = contratos.Horarios;
            CargarGrid();
        }

        private bool Validar()
        {
            bool paso = true;
            Empleados empleados = new Empleados();

            if(string.IsNullOrEmpty(DescripciontextBox.Text))
            {
                MyErrorProvider.SetError(DescripciontextBox, "La descripcion no puede estar vacia");
                DescripciontextBox.Focus();
                paso = false;
            }

            if(HorarioSalidadateTimePicker.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                MyErrorProvider.SetError(HorarioSalidadateTimePicker,"No se trabajan los domingos");
                HorarioSalidadateTimePicker.Focus();
                paso = false;
            }

            if(HorarioDelEmpleadodateTimePicker.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                MyErrorProvider.SetError(HorarioDelEmpleadodateTimePicker, "No se trabajan los domingos");
                HorarioDelEmpleadodateTimePicker.Focus();
                paso = false;
            }

            if (HorarioDelEmpleadodateTimePicker.Value.DayOfWeek == DayOfWeek.Saturday || HorarioDelEmpleadodateTimePicker.MinDate.Hour > 14)
            {
                MyErrorProvider.SetError(HorarioDelEmpleadodateTimePicker, "Hora invalida");
                HorarioDelEmpleadodateTimePicker.Focus();
                paso = false;
            }

            if(HorarioDelEmpleadodateTimePicker.MaxDate.Hour >=22)
            {
                MyErrorProvider.SetError(HorarioDelEmpleadodateTimePicker, "Hora invalida");
                HorarioDelEmpleadodateTimePicker.Focus();
                paso = false;
            }

            if(HorarioSalidadateTimePicker.Value.DayOfWeek == DayOfWeek.Saturday || HorarioSalidadateTimePicker.MinDate.Hour >=14)
            {
                MyErrorProvider.SetError(HorarioSalidadateTimePicker, "Hora invalida");
                HorarioSalidadateTimePicker.Focus();
                paso = false;
            }

            if(HorarioSalidadateTimePicker.Value.Hour >22)
            {
                MyErrorProvider.SetError(HorarioSalidadateTimePicker, "Hora invalida");
                HorarioSalidadateTimePicker.Focus();
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
            if(IdEmpleadonumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(IdEmpleadonumericUpDown,"El id de empleado no puede estar vacio");
                IdEmpleadonumericUpDown.Focus();
                paso = false;
            }
            if(IdDelHorarionumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(IdDelHorarionumericUpDown, "El id del horario no puede estar vacio");
                IdDelHorarionumericUpDown.Focus();
                paso = false;
            }
            if(DetalledataGridView.Rows.Count==0)
            {
                MyErrorProvider.SetError(DetalledataGridView, "El detalle no puede estar vacio");
                DetalledataGridView.Focus();
                paso = false;
            }
            if(empleados==null)
            {
                MessageBox.Show("El empleado no ha sido creado");
                paso = false;
            }

        

            return paso;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {

            Contratos contratos;               
            bool paso = false;

            if (!Validar())
                return;

            contratos = LlenarClase();

            if (IdnumericUpDown.Value == 0)
            {
                paso = ContratosBLL.Guardar(contratos);
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id = Convert.ToInt32(IdnumericUpDown.Value);
                contratos = ContratosBLL.Buscar(id);
                if (contratos != null)
                {
                    paso = ContratosBLL.Modificar(LlenarClase());
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
            Contratos contratos = new Contratos();
            int.TryParse(IdnumericUpDown.Text, out id);
            Limpiar();
            try
            {
                contratos = ContratosBLL.Buscar(id);
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

        private void Departamentobutton_Click(object sender, EventArgs e)
        {
            DepartamentoFormulario departamentoFormulario = new DepartamentoFormulario();
            departamentoFormulario.StartPosition = FormStartPosition.CenterScreen;
            departamentoFormulario.ShowDialog();
        }

        private void CargarGrid()
        {
            DetalledataGridView.DataSource = null;
            DetalledataGridView.DataSource = this.Horarios;
        }

        private void AgregarenelGridbutton_Click(object sender, EventArgs e)
        {
            if (DetalledataGridView.DataSource != null)
                this.Horarios = (List<Horarios>)DetalledataGridView.DataSource;

            this.Horarios.Add(
                new Horarios(
                    fechaHorario: (DateTime)HorarioDelEmpleadodateTimePicker.Value,
                    SalidaHorario: (DateTime)HorarioSalidadateTimePicker.Value,
                    HorasExtrasCantidad: (int)CantidadHorasExtrasnumericUpDown.Value,
                    HorasExtrasPrecio: (int)PrecioPorHorasnumericUpDown.Value
                    )) ;
            CargarGrid();
            IdnumericUpDown.Focus();

        }

        private void Removerbutton_Click(object sender, EventArgs e)
        {
            if (DetalledataGridView.Rows.Count > 0 && DetalledataGridView.CurrentRow != null)
            {
                Horarios.RemoveAt(DetalledataGridView.CurrentRow.Index);
                CargarGrid();
            }
        }

        private void LlenarComboBox()
        {
            var listado = new List<Departamentos>();
            RepositorioBase<Departamentos> repositorioBase = new RepositorioBase<Departamentos>();
            listado = repositorioBase.GetList(p => true);
            DepartamentocomboBox.DataSource = listado;
            DepartamentocomboBox.DisplayMember = "NombreDepartamento";
            DepartamentocomboBox.ValueMember = "DepartamentoId";
        }

        private void HorarioDelEmpleadodateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            HorarioDelEmpleadodateTimePicker.CustomFormat = "HH:mm";
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            HorarioSalidadateTimePicker.CustomFormat = "HH:mm";
        }

     
    }
}
