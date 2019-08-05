using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabajoFinalRecursosHumanos.UI.Consultas
{
    public partial class ListaContrato : Form
    {

        public ListaContrato(List<Entidades.Contratos> contratos)
        {
            InitializeComponent();
        }
    }
}
