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
    public partial class Búsqueda : Form
    {
        private LógicaNegocio.PersonalSala personal;
        public Ejemplar EjemplarSeleccionado { get; private set; }
        public Búsqueda(LógicaNegocio.PersonalSala personal)
        {
            InitializeComponent();
            this.personal = personal;
            this.personal =personal;
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            { 
                this.EjemplarSeleccionado = (Ejemplar)comboBox1.SelectedValue;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un ejemplar.");
            }
        }
    
        

        private void CargarTodosLosEjemplares()
        {
            List<Documento> documentos = personal.getDocumentos();
            List<object> lista = new List<object>();

            foreach (Documento doc in documentos)
            {
                List<Ejemplar> ejemplaresDoc = personal.getEjemplares(doc.ISBN);

                foreach (var ex in ejemplaresDoc)
                {
                    if (ex.Estado == EstadoEjemplar.disponible)
                    {
                        lista.Add(new
                        {
                            ObjetoReal = ex,
                            TextoMostrar = "Cód: " + ex.Codigo + " - " + doc.Titulo + " (" + ex.Estado + ")"
                        });
                    }
                }
            }

            comboBox1.DataSource = lista;
            comboBox1.DisplayMember = "TextoMostrar";
            comboBox1.ValueMember = "ObjetoReal";

            label_ejemplares.Text = "Total ejemplares: " + lista.Count;

            if (lista.Count == 0)
            {
                MessageBox.Show("No existen ejemplares en el sistema.");
                button_aceptar.Enabled = false;
            }
        }

        private void Búsqueda_Load(object sender, EventArgs e)
        {
            CargarTodosLosEjemplares();
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
