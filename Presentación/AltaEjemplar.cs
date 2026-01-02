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

namespace Presentación
{

    public partial class AltaEjemplar : Form
    {
        private LógicaNegocio.PersonalAdquisicion personalLogueado;
        public AltaEjemplar(LógicaNegocio.PersonalAdquisicion personal)
        {
            InitializeComponent();
            this.personalLogueado = personal;
            //CargarDatosIniciales();
        }

        /*private void CargarDatosIniciales()
        {
            try
            {
                // 1. Mostrar el personal que está realizando el alta (solo lectura en la interfaz)
                // Asumimos que PersonalAdquisicion hereda de Usuario/PersonalBiblioteca y tiene un ToString o propiedad NSS
                if (personalLogueado != null)
                {
                    textBox1_personal.Text = personalLogueado.ToString();
                    textBox1_personal.Enabled = false; // El usuario no debe poder cambiar esto manualmente
                }

                // 2. Cargar la lista de Documentos (ISBNs) disponibles en el ComboBox
                List<Documento> listaDocumentos = personalLogueado.obtenerDocumentos();

                if (listaDocumentos.Count > 0)
                {
                    comboBox_documentos.DataSource = listaDocumentos;
                    comboBox_documentos.DisplayMember = "ISBN"; // Mostramos el ISBN en la lista
                    // Opcional: Si quieres mostrar Título e ISBN, podrías modificar el DisplayMember o el ToString de Documento
                    comboBox_documentos.ValueMember = "ISBN";
                }
                else
                {
                    MessageBox.Show("No hay documentos registrados en el sistema. Debe dar de alta un documento antes de crear ejemplares.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    button_aceptar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos iniciales: " + ex.Message);
            }}*/
    

        /*private void btnAceptar_Click(object sender, EventArgs e)
        {
            // 1. Validaciones básicas
            if (string.IsNullOrWhiteSpace(textBox_codigo.Text))
            {
                MessageBox.Show("Por favor, introduzca un código para el ejemplar.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBox_documentos.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un documento asociado.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Recopilar datos
                string codigo = textBox_codigo.Text;
                Documento documentoSeleccionado = (Documento)comboBox_documentos.SelectedItem;


              
                // 3. Crear el objeto Ejemplar
                // Según tu archivo Ejemplar.cs, el constructor es: Ejemplar(Documento, codigo, PersonalAdquisicion)
                Ejemplar nuevoEjemplar = new Ejemplar(documentoSeleccionado, codigo, personalLogueado);

                // 4. Llamar a la capa de Lógica de Negocio para guardar
                // El método altaEjemplar devuelve true si éxito, false si falla (ej. duplicado)
                bool exito = personalLogueado.altaEjemplar(nuevoEjemplar);

                if (exito)
                {
                    MessageBox.Show("Ejemplar dado de alta correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    // Según el PDF: "Si se introduce el código de un ejemplar que ya existe, debe mostrar un mensaje"
                    MessageBox.Show("No se pudo dar de alta el ejemplar. Es posible que el código ya exista para este documento o haya un error en la base de datos.", "Error de Alta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/
    }
}
