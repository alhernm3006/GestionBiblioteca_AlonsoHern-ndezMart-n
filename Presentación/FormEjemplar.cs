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
    public partial class FormEjemplar : Form
    {
        private LógicaNegocio.PersonalAdquisicion personal;
        private string codigoEjemplar;
        private string modo;
        private Ejemplar ejemplarActual;
        public FormEjemplar(String codigo, LógicaNegocio.PersonalAdquisicion personal, String modoOperacion)
        {
            InitializeComponent();
            this.personal = personal;
            this.codigoEjemplar = codigo;
            this.modo = modoOperacion;

            this.Text = this.modo + "de Ejemplar";

            CargarDatosIniciales();
        }


        private void CargarDatosIniciales()
        {
            textBox_codigo.Text = this.codigoEjemplar;
            textBox_codigo.Enabled = false;
            textBox1_personal.Text = personal.IdPersonal;
            textBox1_personal.ReadOnly = true;

            List<Documento> listaDocumentos = personal.getDocumentos().Where(u => u.Estado == EstadoActivoInactivo.activo).ToList();
            comboBox_documentos.DataSource = listaDocumentos;
            comboBox_documentos.DisplayMember = "ISBN";
            comboBox_documentos.ValueMember = "ISBN";

            if (this.modo == "Alta")
            {
                radioButton_prestado.Visible = false;
                button_aceptar.Text = "Dar de Alta";
            }
            else if (this.modo == "Búsqueda" || this.modo == "Baja")
            {
                if (!BuscarYCargarEjemplar(listaDocumentos))
                {
                    MessageBox.Show("No se encontró ningún ejemplar con el código: " + this.codigoEjemplar, "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }
                comboBox_documentos.Enabled = false;
                radioButton_prestado.Enabled = false;
                if (this.modo == "Búsqueda")
                {
                    button_aceptar.Visible = false;
                    button_cancelar.Text = "Cerrar";
                }
                else
                {
                    button_aceptar.Text = "Eliminar";
                    button_aceptar.Visible = true;
                }
            }
        }

        private bool BuscarYCargarEjemplar(List<Documento> docs)
        {
            foreach (Documento doc in docs)
            {
                Ejemplar ej = personal.getEjemplar(doc.ISBN, this.codigoEjemplar);

                if (ej != null)
                {
                    this.ejemplarActual = ej;
                    comboBox_documentos.SelectedValue = ej.Documento.ISBN;
                    radioButton_prestado.Checked = (ej.Estado.ToString().ToLower() == "prestado");
                    return true;
                }
            }
            return false;
        }


        private void button_aceptar_Click(object sender, EventArgs e)
        {
            if (comboBox_documentos.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un documento asociado.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Documento documentoSeleccionado = (Documento)comboBox_documentos.SelectedItem;
            ModeloDominio.PersonalAdquisicion personalDominio = (ModeloDominio.PersonalAdquisicion)personal.getPersonal(personal.IdPersonal);
            Ejemplar nuevoEjemplar = new Ejemplar(documentoSeleccionado, this.codigoEjemplar, personalDominio);

            if (personal.altaEjemplar(nuevoEjemplar))
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


        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
