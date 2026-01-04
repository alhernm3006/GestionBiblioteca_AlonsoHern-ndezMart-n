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
    public partial class ListadoUsuario : Form
    {
        private LógicaNegocio.PersonalBiblioteca personal;
        private string tipo;
        private List<Usuario> listaUsuarios;
        private List<Documento> listaDocumentos;
        public ListadoUsuario(LógicaNegocio.PersonalBiblioteca p, string tipo)
        {
            InitializeComponent();
            this.personal = p;
            this.tipo = tipo;
            if (tipo.Equals("Usuario"))
            {
                listaUsuarios = new List<Usuario>();
                this.Text = "Listado de usuarios";
            }else if (tipo.Equals("Documento"))
            {
                button_dni.Text = "ISBN";
                button_nombre.Text = "Título";
                listaDocumentos = new List<Documento>();
                this.Text = "Listado de documentos";
            }
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
            if (tipo.Equals("Usuario"))
            {
                listaUsuarios.Sort((u1, u2) => string.Compare(u1.Nombre, u2.Nombre));
            }
            else if (tipo.Equals("Documento"))
            {
                listaDocumentos.Sort((d1, d2) => string.Compare(d1.Titulo, d2.Titulo));
            }
            ActualizarListasVisuales();

        }

        private void button_dni_Click(object sender, EventArgs e)
        {
            if (tipo.Equals("Usuario"))
            {
                listaUsuarios.Sort((u1, u2) => string.Compare(u1.DNI, u2.DNI));
            }
            else if (tipo.Equals("Documento"))
            {
                listaDocumentos.Sort((d1, d2) => string.Compare(d1.ISBN, d2.ISBN));
            }
            ActualizarListasVisuales();
        }

        private void ActualizarListasVisuales()
        {
            listBox_dni.Items.Clear();
            listBox_nombre.Items.Clear();

            if (tipo.Equals("Usuario"))
            {
                foreach (Usuario u in listaUsuarios)
                {
                    listBox_dni.Items.Add(u.DNI);
                    listBox_nombre.Items.Add(u.Nombre);
                }
            }
            else if (tipo.Equals("Documento"))
            {
                foreach (Documento d in listaDocumentos)
                {
                    listBox_dni.Items.Add(d.ISBN);
                    listBox_nombre.Items.Add(d.Titulo);
                }
            }
        }

        private void CargarDatos()
        {
            if (tipo.Equals("Usuario"))
            {
                List<Usuario> todos = personal.getUsuarios();
                listaUsuarios = todos.Where(u => u.Estado != EstadoActivoInactivo.inactivo).ToList();
            }
            else if (tipo.Equals("Documento"))
            {
                LógicaNegocio.PersonalAdquisicion p = (LógicaNegocio.PersonalAdquisicion) this.personal;
                listaDocumentos = p.getDocumentos();
            }
            ActualizarListasVisuales();
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
