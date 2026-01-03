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
                // Recuperamos el objeto Ejemplar real
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
            try
            {
                // 1. Obtenemos todos los documentos
                List<Documento> documentos = personal.obtenerDocumentos();

                // 2. Creamos una lista para acumular TODOS los ejemplares de la biblioteca
                List<object> listaVisual = new List<object>();

                foreach (Documento doc in documentos)
                {
                    // Obtenemos ejemplares de este documento
                    List<Ejemplar> ejemplaresDoc = personal.obtenerEjemplares(doc.ISBN);

                    // 3. Los añadimos a la lista visual transformándolos para el ComboBox
                    // SIN FILTRAR por estado (se muestran todos: disponibles, prestados, etc.)
                    
                    foreach (var ex in ejemplaresDoc)
                    {
                        if (ex.Estado==EstadoEjemplar.disponible) {
                            listaVisual.Add(new
                            {
                                ObjetoReal = ex,
                                // Mostramos el Estado para que el usuario sepa si puede prestarlo o no
                                TextoMostrar = $"Cód: {ex.Codigo} - {doc.Titulo} ({ex.Estado})"
                            });
                        }
                    }
                }

                // 4. Enlazamos la lista acumulada al ComboBox
                comboBox1.DataSource = listaVisual;
                comboBox1.DisplayMember = "TextoMostrar";
                comboBox1.ValueMember = "ObjetoReal";

                label_ejemplares.Text = $"Total ejemplares: {listaVisual.Count}";

                if (listaVisual.Count == 0)
                {
                    MessageBox.Show("No existen ejemplares en el sistema.");
                    button_aceptar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ejemplares: " + ex.Message);
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
