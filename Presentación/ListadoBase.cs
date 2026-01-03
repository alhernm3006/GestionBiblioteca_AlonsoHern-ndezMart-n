using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentación
{
    public partial class ListadoBase : Form
    {
        public ListadoBase()
        {
            InitializeComponent();

        }

        public void CargarDatos<T>(List<T> datos)
        {
            
            bindingSource1.DataSource = datos;
            dataGridView1.DataSource = bindingSource1;
        }
    }
}
