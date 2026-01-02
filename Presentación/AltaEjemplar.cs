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
        private string codigoEjemplar;
        private string modo; // "Alta", "Baja", "Búsqueda"
        private Ejemplar ejemplarActual;
        public AltaEjemplar(String codigo, LógicaNegocio.PersonalAdquisicion personal, String modoOperacion)
        {
            InitializeComponent();
            this.personalLogueado = personal;
            this.codigoEjemplar = codigo;
            this.modo = modoOperacion;

            // Configurar el título de la ventana según el modo
            this.Text = "Gestión de Ejemplar - " + this.modo;

            CargarDatosIniciales();
        }


        private void CargarDatosIniciales()
        {
            try
            {
                textBox_codigo.Text = this.codigoEjemplar;
                textBox_codigo.Enabled = false; // El código siempre es fijo tras introducirlo en el paso anterior

                textBox1_personal.Text = personalLogueado.Nombre;
                textBox1_personal.Enabled = false; // Campo informativo

                // 2. Cargar la lista de Documentos (ISBNs) en el ComboBox
                List<Documento> listaDocumentos = personalLogueado.obtenerDocumentos();
                comboBox_documentos.DataSource = listaDocumentos;
                comboBox_documentos.DisplayMember = "ISBN";
                comboBox_documentos.ValueMember = "ISBN";

                // 3. Lógica específica según el MODO
                if (this.modo == "Alta")
                {
                    // En Alta, permitimos editar el documento y el botón Aceptar guarda
                    comboBox_documentos.Enabled = true;
                    radioButton_prestado.Enabled = false; // Al dar de alta, por defecto no está prestado (o es editable)
                    radioButton_prestado.Checked = false;
                    button_aceptar.Text = "Dar de Alta";
                }
                else if (this.modo == "Búsqueda" || this.modo == "Baja")
                {
                    // En Búsqueda o Baja, primero debemos ENCONTRAR el ejemplar usando el código.
                    // Como la clave primaria es compuesta (ISBN + Código) y solo tenemos el Código,
                    // debemos buscar en los documentos para ver cuál contiene este ejemplar.

                    bool encontrado = BuscarYCargarEjemplar(listaDocumentos);

                    if (!encontrado)
                    {
                        MessageBox.Show("No se encontró ningún ejemplar con el código: " + this.codigoEjemplar, "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        // Opcional: Cerrar el formulario si no se encuentra
                        this.Close();
                        return;
                    }

                    // Bloquear controles visuales ya que es solo visualización (o confirmación de baja)
                    comboBox_documentos.Enabled = false;
                    radioButton_prestado.Enabled = false;

                    if (this.modo == "Búsqueda")
                    {
                        button_aceptar.Visible = false; // No hay acción de "Aceptar" en búsqueda, solo ver
                        button_cancelar.Text = "Cerrar";
                    }
                    else // Baja
                    {
                        button_aceptar.Text = "Eliminar";
                        button_aceptar.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos iniciales: " + ex.Message);
            }
        }

        // Método auxiliar para buscar el ejemplar iterando documentos
        private bool BuscarYCargarEjemplar(List<Documento> docs)
        {
            foreach (Documento doc in docs)
            {
                // Usamos el método getEjemplar de la lógica de negocio
                Ejemplar ej = personalLogueado.getEjemplar(doc.ISBN, this.codigoEjemplar);

                if (ej != null)
                {
                    this.ejemplarActual = ej;

                    // Asignar los valores a la interfaz
                    comboBox_documentos.SelectedValue = ej.Documento.ISBN;

                    // Mostrar si está prestado
                    // Asumiendo que EstadoEjemplar es un Enum o string. Ajustar según tu ModeloDominio.
                    // Aquí comparo con string o enum según tus archivos subidos:
                    radioButton_prestado.Checked = (ej.Estado.ToString().ToLower() == "prestado");

                    // Si el objeto Ejemplar guarda el personal que lo creó, podrías mostrarlo:
                    // textBox1_personal.Text = ej.Personal.Nombre; 

                    return true; // Encontrado
                }
            }
            return false; // No encontrado en ningún documento
        }





        private void button_aceptar_Click(object sender, EventArgs e)
        {
           
            {
                if (comboBox_documentos.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione un documento asociado.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    // 2. Recopilar datos
                    // Asegúrate de que comboBox tiene objetos Documento. Si usaste DataSource, haz el cast:
                    Documento documentoSeleccionado = (Documento)comboBox_documentos.SelectedItem;

                    // 3. Crear el objeto PersonalAdquisicion del DOMINIO (Solución del error)
                    // Como no tenemos los datos reales del usuario logueado (NSS, dirección, etc.) en este punto,
                    // creamos un objeto 'dummy' o marcador para que el Transformer pueda leer un NSS sin romperse.
                    // NOTA: Idealmente, deberías pasar el objeto Usuario real desde el Login hasta aquí.

                    ModeloDominio.PersonalAdquisicion personalDominio = new ModeloDominio.PersonalAdquisicion(
                       personalLogueado.Nombre ,// Este NSS se guardará en la BD. Cámbialo si tienes uno real.
                        personalLogueado.Contraseña
                    );

                   


                    // 4. Crear el Ejemplar pasando el personal válido
                    Ejemplar nuevoEjemplar = new Ejemplar(documentoSeleccionado, this.codigoEjemplar, personalDominio);

                    // 5. Guardar usando la lógica de negocio
                    bool exito = personalLogueado.altaEjemplar(nuevoEjemplar);

                    if (exito)
                    {
                        MessageBox.Show("Ejemplar dado de alta correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error: Ya existe un ejemplar con este código para el documento seleccionado.", "Error de Alta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error inesperado: " + ex.Message + "\n" + ex.StackTrace, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }}
            

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
