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

        //PRE: 
        //POS:  Inicializa el formulario base
        public ListadoBase()
        {
            InitializeComponent();
        }

        //PRE:  datos es una lista genérica
        //POS:  Vincula la lista al BindingSource y este al DataGridView para mostrar los datos en formato tabla.
        public void CargarDatos<T>(List<T> datos)
        {
            bindingSource1.DataSource = datos;
            dataGridView1.DataSource = bindingSource1;
        }
    }
}
