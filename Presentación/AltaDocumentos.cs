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
            this.Text = operacion + " de documento";
            this.documento = documento;
            textBox_ISBN.Text = isbn;
            this.personal = personal;

            this.textBox_autor.Text = documento.Autor;
            this.textBox_editorial.Text = documento.Editorial;
            this.textBox_titulo.Text = documento.Titulo;
            this.operacion = operacion;
            this.radioButton_libro.Enabled = false;
            this.radioButton_Audiolibro.Enabled = false;
            this.button_darAlta.Text = "Dar Baja";
            label_formato.Visible = false;
            label_duracion.Visible = false;
            textBox_formato.Visible = false;
            textBox_duracion.Visible = false;

            if (this.documento is LibroPapel)
            {
                radioButton_libro.Checked = true;
            }
            else
            {
                radioButton_Audiolibro.Checked = true;
            }
           
             if (operacion.Equals("Búsqueda"))
            {
                this.Text = "Datos de documento";
                this.textBox_ISBN.ReadOnly = true;
                this.textBox_autor.ReadOnly = true;
                this.textBox_editorial.ReadOnly = true;
                this.textBox_titulo.ReadOnly = true;

                button_darAlta.Hide();
                button_cancelar.Hide();
                button_añadirEjemplar.Hide();
            }
        }

        private void button_darAlta_Click(object sender, EventArgs e)
        {
            if (this.operacion.Equals("Alta"))
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

                // 2. Recoger datos de los controles existentes
                string isbn = textBox_ISBN.Text;
                string titulo = textBox_titulo.Text;
                string autor = textBox_autor.Text;
                string editorial = textBox_editorial.Text;
                int anio = DateTime.Now.Year;

                Documento nuevoDoc = null;
                LógicaNegocio.PersonalAdquisicion p = (LógicaNegocio.PersonalAdquisicion)this.personal;

                // 3. Crear la instancia según el tipo seleccionado (Libro o Audiolibro)
                if (radioButton_libro.Checked)
                {
                    nuevoDoc = new LibroPapel(isbn, titulo, autor, anio, editorial);
                    p.altaDocumento(nuevoDoc);

                    DialogResult resultado = MessageBox.Show("Documento añadido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (resultado.Equals(DialogResult.OK)) this.Close();
                }
                else if (radioButton_Audiolibro.Checked)
                {
                    // NOTA: Faltan campos en la interfaz para 'Formato' y 'Duración'.
                    // Se usan valores por defecto para evitar errores de compilación.
                    if(string.IsNullOrWhiteSpace(textBox_formato.Text) || string.IsNullOrWhiteSpace(textBox_duracion.Text)){
                        return;
                    }
                    string formato = textBox_formato.Text;
                    float duracion = float.Parse(textBox_duracion.Text);

                    nuevoDoc = new AudioLibro(isbn, titulo, autor, anio, editorial, formato, duracion);
                    p.altaDocumento(nuevoDoc);
                    DialogResult resultado = MessageBox.Show("Documento añadido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (resultado.Equals(DialogResult.OK)) this.Close();
                }
            }else if (this.operacion.Equals("Baja"))
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro que desea dar de baja el documento?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado.Equals(DialogResult.Yes))
                {
                    LógicaNegocio.PersonalAdquisicion p = (LógicaNegocio.PersonalAdquisicion)this.personal;
                    p.bajaDocumento(textBox_ISBN.Text);
                    DialogResult r2 = MessageBox.Show("Documento eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (resultado.Equals(DialogResult.OK)) this.Close();
                }
            }
        }

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
