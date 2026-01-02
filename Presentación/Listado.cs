using LógicaNegocio;
using ModeloDominio;
using Persistencia;
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
    public partial class Listado : Form
    {
        private LógicaNegocio.PersonalBiblioteca personal;
        private List<Usuario> listaUsuarios;
        private Usuario_CRUD usuarioCRUD;
        public Listado(LógicaNegocio.PersonalBiblioteca p)
        {
           
            InitializeComponent();
            this.personal = p;
            listaUsuarios = new List<Usuario>();
            this.Load += new EventHandler(Listado_Load);
            this.button_dni.Click += new EventHandler(button_dni_Click);
            this.button_nombre.Click += new EventHandler(button_nombre_Click);
            this.button3.Click += new EventHandler(button3_Click); // button3 es el botón Cerrar
            this.listBox_dni.SelectedIndexChanged += new EventHandler(listBox_dni_SelectedIndexChanged);
            this.listBox_nombre.SelectedIndexChanged += new EventHandler(listBox_nombre_SelectedIndexChanged);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox_dni_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_dni.SelectedIndex != -1)
            {
                listBox_nombre.SelectedIndex = listBox_dni.SelectedIndex;
            }
        }

        private void listBox_nombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_nombre.SelectedIndex != -1)
            {
                listBox_dni.SelectedIndex = listBox_nombre.SelectedIndex;
            }
        }

        private void button_nombre_Click(object sender, EventArgs e)
        {
            listaUsuarios.Sort((u1, u2) => string.Compare(u1.Nombre, u2.Nombre));
            ActualizarListasVisuales();

        }

        private void button_dni_Click(object sender, EventArgs e)
        {
            listaUsuarios.Sort((u1, u2) => string.Compare(u1.DNI, u2.DNI));
            ActualizarListasVisuales();
        }

        private void ActualizarListasVisuales()
        {
            // Limpiamos los ListBox antes de volver a llenarlos
            listBox_dni.Items.Clear();
            listBox_nombre.Items.Clear();

            // Rellenamos ambos ListBox en el mismo orden
            foreach (Usuario u in listaUsuarios)
            {
                listBox_dni.Items.Add(u.DNI);
                listBox_nombre.Items.Add(u.Nombre);
            }
        }

        private void CargarDatos()
        {
            // 1. Obtenemos todos los usuarios de la base de datos simulada
            List<Usuario> todosLosUsuarios = personal.obtenerUsuarios();

            // 2. Limpiamos la lista local
            listaUsuarios.Clear();

            // 3. Filtramos: Solo mostramos los que NO estén inactivos
            // Usamos el Enum EstadoActivoInactivo definido en tu Modelo de Dominio
            foreach (Usuario u in todosLosUsuarios)
            {
                if (u.Estado != EstadoActivoInactivo.inactivo)
                {
                    listaUsuarios.Add(u);
                }
            }

            // 4. Actualizamos la interfaz visual
            ActualizarListasVisuales();
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
