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

          

            if (this.documento is LibroPapel)
            {
                radioButton_libro.Checked = true;
                
            }
            else if (this.documento is AudioLibro)
            {
                radioButton_Audiolibro.Checked = true;
            }

            this.radioButton_libro.Enabled = false;
            this.radioButton_Audiolibro.Enabled = false;

           
           
             if (operacion.Equals("Búsqueda"))
            {
               
                this.Text = "Datos de documento";
                // Configuración de campos (IMPORTANTE: Faltaba esto en tu código)
                textBox_ISBN.ReadOnly = true;
                this.textBox_autor.ReadOnly = true;
                this.textBox_editorial.ReadOnly = true;
                this.textBox_ISBN.ReadOnly = true;
                this.textBox_titulo.ReadOnly = true;


                button_darAlta.Hide();
                button_cancelar.Hide();
                button_añadirEjemplar.Hide();
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

            // 2. Recoger datos de los controles existentes
            string isbn = textBox_ISBN.Text;
            string titulo = textBox_titulo.Text;
            string autor = textBox_autor.Text;
            string editorial = textBox_editorial.Text;

            // NOTA: El formulario actual no tiene campo de texto para el "Año", 
            // por lo que usamos el año actual o 0 como valor por defecto.
            int anio = DateTime.Now.Year;

            Documento nuevoDocumento = null;

            LógicaNegocio.PersonalAdquisicion p = (LógicaNegocio.PersonalAdquisicion)this.personal;

            // 3. Crear la instancia según el tipo seleccionado (Libro o Audiolibro)
            if (radioButton_libro.Checked)
            {
                nuevoDocumento = new LibroPapel(isbn, titulo, autor, anio, editorial);
                p.altaDocumento(nuevoDocumento);
                
                DialogResult resultado = MessageBox.Show("Documento añadido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (resultado.Equals(DialogResult.OK)) this.Close();
            }
            else if (radioButton_Audiolibro.Checked)
            {
                // NOTA: Faltan campos en la interfaz para 'Formato' y 'Duración'.
                // Se usan valores por defecto para evitar errores de compilación.
                string formato = "MP3";
                float duracion = 0.0f;

                nuevoDocumento = new AudioLibro(isbn, titulo, autor, anio, editorial, formato, duracion);
                p.altaDocumento(nuevoDocumento);
                DialogResult resultado = MessageBox.Show("Documento añadido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (resultado.Equals(DialogResult.OK)) this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar si es Libro o Audiolibro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Aseguramos que el estado sea activo al darlo de alta (el constructor lo pone inactivo por defecto)
            nuevoDocumento.Estado = EstadoActivoInactivo.activo;

            // 4. Llamar a la Lógica de Negocio
           


        }
    }
}
