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

        //PRE:  p es PersonalBiblioteca válido
        //POS:  Inicializa el formulario y llama a CargarUsuarios()
        public BusquedaDNI( LógicaNegocio.PersonalBiblioteca p)
        {
            InitializeComponent();
            this.personal = p;
            this.textBox1.ReadOnly = true;
            CargarUsuarios();
        }

        //PRE:  Formulario inicializado.
        //POS:  Obtiene los usuarios activos y los asigna al ComboBox. Llama a ActualizarNombre()
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


        //PRE:  Se cambia la selección del ComboBox de DNIs
        //POS:  Llama a ActualizarNombre() para mostrar el nombre asociado
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarNombre();
        }


        //PRE:  Hay un usuario seleccionado en el ComboBox de DNIs
        //POS:  Muestra el nombre del usuario seleccionado
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
