using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabajoFinalRecursosHumanos.UI.Consultas;
using TrabajoFinalRecursosHumanos.UI.Registros;

namespace TrabajoFinalRecursosHumanos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void EmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmpleadosFormulario empleadosFormulario = new EmpleadosFormulario();
            empleadosFormulario.StartPosition = FormStartPosition.CenterScreen;
            empleadosFormulario.Show();
        }

        private void EmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContratoFormulario contratoFormulario = new ContratoFormulario();
            contratoFormulario.StartPosition = FormStartPosition.CenterScreen;
            contratoFormulario.Show();
        }

        private void HorarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HorariosFormulario horariosFormulario = new HorariosFormulario();
            horariosFormulario.StartPosition = FormStartPosition.CenterScreen;
            horariosFormulario.Show();
        }
    }
}
