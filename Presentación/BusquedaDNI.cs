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

            // Cargar los usuarios en el ComboBox al iniciar
            CargarUsuarios();

            // Suscribir el evento de cambio de selección (si no está ya en el Designer)
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
        }

        private void CargarUsuarios()
        {
            if (personal != null)
            {
                // Obtiene la lista completa de usuarios desde la lógica de negocio
                List<Usuario> listaUsuarios = personal.obtenerUsuarios();

                // Enlazado de datos (Data Binding) para el ComboBox
                // Esto permite manejar objetos 'Usuario' completos en lugar de solo strings
                comboBox1.DataSource = listaUsuarios;
                comboBox1.DisplayMember = "DNI"; // Propiedad de la clase Usuario a mostrar

                // Actualizar el nombre inmediatamente para el primer elemento seleccionado por defecto
                ActualizarNombre();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Evento que se dispara al seleccionar un DNI diferente
            ActualizarNombre();
        }

        private void ActualizarNombre()
        {
            // Verifica que haya un elemento seleccionado
            if (comboBox1.SelectedItem != null)
            {
                // Al usar DataSource, SelectedItem es el objeto Usuario real
                Usuario u = (Usuario)comboBox1.SelectedItem;

                // Actualiza el TextBox con el nombre del usuario
                textBox1.Text = u.Nombre;
            }
            else
            {
                textBox1.Text = "";
            }
        }
    }
}
