using ModeloDominio;
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
    public partial class BusquedaDNI : Form
    {

        private LógicaNegocio.PersonalBiblioteca personal;
        public BusquedaDNI( LógicaNegocio.PersonalBiblioteca p)
        {
            InitializeComponent();
            this.personal = p;
            this.textBox1.ReadOnly = true;
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            if (personal != null)
            {
                List<Usuario> listaUsuarios = personal.getUsuarios().Where(u => u.Estado == EstadoActivoInactivo.activo).ToList();

                comboBox1.DataSource = listaUsuarios;
                comboBox1.DisplayMember = "DNI";
                ActualizarNombre();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarNombre();
        }

        private void ActualizarNombre()
        {
            if (comboBox1.SelectedItem != null)
            {
                Usuario u = (Usuario)comboBox1.SelectedItem;
                textBox1.Text = u.Nombre;
            }
            else
            {
                textBox1.Text = "";
            }
        }
    }
}
