using Microsoft.VisualBasic;
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
    public partial class AltaDocumentos : Form
    {
        private LógicaNegocio.PersonalBiblioteca personal;
        private string operacion;
        private Documento documento;
        public AltaDocumentos(string isbn, string operacion, LógicaNegocio.PersonalBiblioteca personal)
        {
            InitializeComponent();
            this.Text = operacion + " de usuario";
            textBox_ISBN.Text = isbn;
            this.personal = personal;
            label_formato.Visible = false;
            label_duracion.Visible = false;
            textBox_formato.Visible = false;
            textBox_duracion.Visible = false;

            if (operacion.Equals("Alta"))
            {
                this.operacion = operacion;
                textBox_ISBN.ReadOnly = true;
            }
        }

        public AltaDocumentos(string isbn, string operacion,Documento documento, LógicaNegocio.PersonalBiblioteca personal)
        {
            InitializeComponent();

            this.documento = documento;
            this.personal = personal;
            this.operacion = operacion;

            // 1. Rellenar datos comunes
            this.textBox_ISBN.Text = isbn;
            this.textBox_autor.Text = documento.Autor;
            this.textBox_editorial.Text = documento.Editorial;
            this.textBox_titulo.Text = documento.Titulo;

            // Bloquear cambio de tipo de documento
            this.radioButton_libro.Enabled = false;
            this.radioButton_Audiolibro.Enabled = false;

            // 2. Comprobar tipo y rellenar datos específicos
            // Inicialmente ocultamos los campos de AudioLibro
            label_formato.Visible = false;
            label_duracion.Visible = false;
            textBox_formato.Visible = false;
            textBox_duracion.Visible = false;

            if (this.documento is LibroPapel)
            {
                radioButton_libro.Checked = true;
            }
            else if (this.documento is AudioLibro audio) // Casteo automático
            {
                radioButton_Audiolibro.Checked = true;

                // Hacemos visibles los campos y asignamos valores
                label_formato.Visible = true;
                label_duracion.Visible = true;
                textBox_formato.Visible = true;
                textBox_duracion.Visible = true;

                textBox_formato.Text = audio.Formato;
                textBox_duracion.Text = audio.Duracion.ToString();
            }

            // 3. Configurar interfaz según la operación (Búsqueda o Baja)
            if (operacion.Equals("Búsqueda"))
            {
                this.Text = "Consulta de Documento";

                // MODO SOLO LECTURA: Bloqueamos todos los campos
                textBox_ISBN.ReadOnly = true;
                textBox_autor.ReadOnly = true;
                textBox_editorial.ReadOnly = true;
                textBox_titulo.ReadOnly = true;
                textBox_formato.ReadOnly = true;
                textBox_duracion.ReadOnly = true;

                // Ocultar botones de acción
                button_darAlta.Hide(); // No queremos dar de alta ni baja
                                       // Si tienes botón de añadir ejemplar, ocúltalo también:
                                       // button_añadirEjemplar.Hide(); 

                // Cambiamos el texto de cancelar para que sirva de "Cerrar"
                button_cancelar.Text = "Cerrar";
            }
        }

        private void button_darAlta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_ISBN.Text) ||
             string.IsNullOrWhiteSpace(textBox_titulo.Text) ||
             string.IsNullOrWhiteSpace(textBox_autor.Text) ||
             string.IsNullOrWhiteSpace(textBox_editorial.Text))
            {
                MessageBox.Show("Por favor, rellene todos los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!radioButton_Audiolibro.Checked && !radioButton_libro.Checked)
            {
                MessageBox.Show("Por favor, seleccione el tipo de Documento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Definimos las variables y el personal
            string isbn = textBox_ISBN.Text;
            LógicaNegocio.PersonalAdquisicion p = (LógicaNegocio.PersonalAdquisicion)this.personal;

            // 2. NUEVA VALIDACIÓN: Comprobar si el ISBN ya existe en el sistema
            // Si buscarPorISBN devuelve un objeto diferente de null, significa que ya existe.
            if (p.buscarPorISBN(isbn) != null)
            {
                MessageBox.Show("Ya existe un documento registrado con este ISBN.", "ISBN Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Detenemos la ejecución aquí para no crear duplicados
            }

            string titulo = textBox_titulo.Text;
            string autor = textBox_autor.Text;
            string editorial = textBox_editorial.Text;
            int anio = DateTime.Now.Year;

            Documento nuevoDoc = null;

            // 3. Crear la instancia según el tipo seleccionado
            if (radioButton_libro.Checked)
            {
                nuevoDoc = new LibroPapel(isbn, titulo, autor, anio, editorial);
            }
            else if (radioButton_Audiolibro.Checked)
            {
                // Validaciones específicas para audiolibro
                if (string.IsNullOrWhiteSpace(textBox_formato.Text) || string.IsNullOrWhiteSpace(textBox_duracion.Text))
                {
                    MessageBox.Show("Por favor, rellene formato y duración.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Control de errores de conversión numérica
                if (!float.TryParse(textBox_duracion.Text, out float duracion))
                {
                    MessageBox.Show("La duración debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string formato = textBox_formato.Text;
                nuevoDoc = new AudioLibro(isbn, titulo, autor, anio, editorial, formato, duracion);
            }

            // 4. Intentar dar de alta (doble seguridad con el bool de retorno)
            if (nuevoDoc != null)
            {
                bool exito = p.altaDocumento(nuevoDoc);

                if (exito)
                {
                    DialogResult resultado = MessageBox.Show("Documento añadido correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (resultado == DialogResult.OK) this.Close();
                }
                else
                {
                    // Este mensaje saldrá si falla la inserción por otra razón (ej. documento inactivo con mismo ISBN)
                    MessageBox.Show("No se pudo añadir el documento. Verifique que no exista previamente (incluso inactivo).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }/*else if (this.operacion.Equals("Baja"))
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro que desea dar de baja el documento?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado.Equals(DialogResult.Yes))
                {
                    LógicaNegocio.PersonalAdquisicion p = (LógicaNegocio.PersonalAdquisicion)this.personal;
                    p.bajaDocumento(textBox_ISBN.Text);
                    DialogResult r2 = MessageBox.Show("Documento eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (resultado.Equals(DialogResult.OK)) this.Close();
                }
            }*/
        

        private void radioButton_Audiolibro_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Audiolibro.Checked)
            {
                label_formato.Visible = true;
                label_duracion.Visible = true;
                textBox_formato.Visible = true;
                textBox_duracion.Visible = true;
            }
            else
            {
                label_formato.Visible = false;
                label_duracion.Visible = false;
                textBox_formato.Visible = false;
                textBox_duracion.Visible = false;
            }
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
