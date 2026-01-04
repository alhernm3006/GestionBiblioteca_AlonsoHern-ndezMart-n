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
    public partial class FormDocumento : Form
    {
        private LógicaNegocio.PersonalBiblioteca personal;
        private string operacion;
        private Documento documento;
        public FormDocumento(string isbn, string operacion, LógicaNegocio.PersonalBiblioteca personal)
        {
            InitializeComponent();
            this.Text = operacion + " de documento";
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

        public FormDocumento(string isbn, string operacion,Documento documento, LógicaNegocio.PersonalBiblioteca personal)
        {
            InitializeComponent();

            this.documento = documento;
            this.personal = personal;
            this.operacion = operacion;

            this.textBox_ISBN.Text = isbn;
            this.textBox_autor.Text = documento.Autor;
            this.textBox_anio.Text = documento.Año.ToString();
            this.textBox_editorial.Text = documento.Editorial;
            this.textBox_titulo.Text = documento.Titulo;

            this.radioButton_libro.Enabled = false;
            this.radioButton_Audiolibro.Enabled = false;
            label_formato.Visible = false;
            label_duracion.Visible = false;
            textBox_formato.Visible = false;
            textBox_duracion.Visible = false;

            button_cancelar.Text = "Cerrar";
            textBox_ISBN.ReadOnly = true;
            textBox_autor.ReadOnly = true;
            textBox_editorial.ReadOnly = true;
            textBox_titulo.ReadOnly = true;
            textBox_anio.ReadOnly = true;
            textBox_formato.ReadOnly = true;
            textBox_duracion.ReadOnly = true;


            if (this.documento is LibroPapel)
            {
                radioButton_libro.Checked = true;
            }
            else if (this.documento is AudioLibro audio)
            {
                radioButton_Audiolibro.Checked = true;

                label_formato.Visible = true;
                label_duracion.Visible = true;
                textBox_formato.Visible = true;
                textBox_duracion.Visible = true;

                textBox_formato.Text = audio.Formato;
                textBox_duracion.Text = audio.Duracion.ToString();
            }

            if (operacion.Equals("Búsqueda"))
            {
                this.Text = "Consulta de Documento";
                button_darAlta.Hide();
            }
            else
            {
                this.Text = "Baja de Documento";
                button_darAlta.Text = "Dar baja";
            }
        }

        private void button_darAlta_Click(object sender, EventArgs e)
        {
            if (this.operacion.Equals("Alata"))
            {
                if (string.IsNullOrWhiteSpace(textBox_ISBN.Text) ||
                 string.IsNullOrWhiteSpace(textBox_titulo.Text) ||
                 string.IsNullOrWhiteSpace(textBox_autor.Text) ||
                 string.IsNullOrWhiteSpace(textBox_editorial.Text) ||
                 string.IsNullOrWhiteSpace(textBox_anio.Text)
                 )
                {
                    MessageBox.Show("Por favor, rellene todos los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (int.TryParse(textBox_anio.Text, out int anio) && anio > 0 && anio <= DateTime.Now.Year)
                {
                    MessageBox.Show("Por favor, ingrese un año válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!radioButton_Audiolibro.Checked && !radioButton_libro.Checked)
                {
                    MessageBox.Show("Por favor, seleccione el tipo de Documento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string isbn = textBox_ISBN.Text;
                LógicaNegocio.PersonalAdquisicion p = (LógicaNegocio.PersonalAdquisicion)this.personal;

                if (p.buscarPorISBN(isbn) != null)
                {
                    MessageBox.Show("Ya existe un documento registrado con este ISBN.", "ISBN Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string titulo = textBox_titulo.Text;
                string autor = textBox_autor.Text;
                string editorial = textBox_editorial.Text;

                Documento nuevoDoc = null;
                if (radioButton_libro.Checked)
                {
                    nuevoDoc = new LibroPapel(isbn, titulo, autor, anio, editorial);
                }
                else if (radioButton_Audiolibro.Checked)
                {
                    if (string.IsNullOrWhiteSpace(textBox_formato.Text) || string.IsNullOrWhiteSpace(textBox_duracion.Text))
                    {
                        MessageBox.Show("Por favor, rellene formato y duración.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!float.TryParse(textBox_duracion.Text, out float duracion))
                    {
                        MessageBox.Show("La duración debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string formato = textBox_formato.Text;
                    nuevoDoc = new AudioLibro(isbn, titulo, autor, anio, editorial, formato, duracion);
                }
                if (p.altaDocumento(nuevoDoc))
                {
                    DialogResult resultado = MessageBox.Show("Documento añadido correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (resultado == DialogResult.OK) this.Close();
                }
            }
            else if (this.operacion.Equals("Baja"))
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
