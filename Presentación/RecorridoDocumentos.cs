using LógicaNegocio;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Presentación
{
    public partial class RecorridoDocumentos : Form
    {

        private LógicaNegocio.PersonalBiblioteca personal;
        private BindingSource miBindingSource = new BindingSource();

        //PRE:  personal es un PersonalAdquisicion válido
        //POS:  Se inicializa el formulario y llama a ConfigurarEnlaceDatos()
        public RecorridoDocumentos(LógicaNegocio.PersonalAdquisicion personal )
        {
            InitializeComponent();
            this.personal = personal;
            ConfigurarEnlaceDatos();
        }


        //PRE: 
        //POS:  Se obtienen los documentos activos. Configura el BindingSource y el BindingNavigator.
        private void ConfigurarEnlaceDatos()
        {
         
            List<Documento> listaDocs = personal.getDocumentos()
                                        .Where(d => d.Estado == EstadoActivoInactivo.activo)
                                        .ToList();

        
            miBindingSource.DataSource = listaDocs;

            bindingNavigator1.BindingSource = miBindingSource;

     
            textBox_isbn.DataBindings.Clear();
            textBox_titulo.DataBindings.Clear();
            textBox_autor.DataBindings.Clear();
            textBox_editorial.DataBindings.Clear();
            textBox_año.DataBindings.Clear();

            textBox_isbn.DataBindings.Add("Text", miBindingSource, "ISBN");
            textBox_titulo.DataBindings.Add("Text", miBindingSource, "Titulo");
            textBox_autor.DataBindings.Add("Text", miBindingSource, "Autor");
            textBox_editorial.DataBindings.Add("Text", miBindingSource, "Editorial");
            textBox_año.DataBindings.Add("Text", miBindingSource, "Año");
        }
    }
}
