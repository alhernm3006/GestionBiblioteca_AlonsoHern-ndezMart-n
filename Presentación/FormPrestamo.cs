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
    public partial class FormPrestamo : Form
    {
        private LógicaNegocio.PersonalSala personal;
        private List<Ejemplar> ejemplaresEnPrestamo;

        //PRE:  personal es un PersonalSala valido.
        //POS:  Se inicializa una lista vacia de ejemplares para el préstamo y llama a CargarDatosIniciales()
        public FormPrestamo(LógicaNegocio.PersonalSala personal)
        {
            InitializeComponent();
            this.personal = personal;
            this.ejemplaresEnPrestamo = new List<Ejemplar>();
            CargarDatosIniciales();
        }

        //PRE:  codigo corresponde a un préstamo existente y personal es un PersonalSala valido.
        //POS:  Busca el préstamo y carga sus datos. Se llama a  CargarDatosIniciales()
        public FormPrestamo(LógicaNegocio.PersonalSala personal, string codigo)
        {
            InitializeComponent();
            this.personal = personal;
            Prestamo p=personal.buscarPrestamo(codigo);

            this.textBox_idprestamo.Text = codigo;
            this.textBox_fecha.Text = p.FechaInicio.ToString();
            this.comboBox_usuario.Text = p.Usuario.Nombre;
            this.button_aceptar.Visible= false;

            this.button_añadirEjemplar.Visible = false;
            this.textBox_idprestamo.ReadOnly = true;
            this.comboBox_usuario.Enabled = false;

            List<Ejemplar> ejemplares = p.Ejemplares;

            foreach (Ejemplar e in ejemplares)
            {
                Label lblPrestado = new Label();
                lblPrestado.Text = "PRESTADO: "+ e.Documento.Titulo + " (Cód: " +e.Codigo +")";
                lblPrestado.AutoSize = true;
                flowLayoutPanel1.Controls.Add(lblPrestado);
            }
            CargarDatosIniciales();
        }


        //PRE: 
        //POS: Se establece la fecha actual en el textBox y rellena el comboBox con los usuarios activos
        private void CargarDatosIniciales()
        {
            textBox_fecha.Text = DateTime.Now.ToShortDateString();
            textBox_fecha.ReadOnly = true; 
            List<Usuario> usuarios = personal.getUsuarios();
            var usuariosActivos = usuarios.Where(u => u.Estado == EstadoActivoInactivo.activo).ToList();
            comboBox_usuario.DataSource = usuariosActivos;
            comboBox_usuario.DisplayMember = "DNI";
            comboBox_usuario.ValueMember = "DNI";
        }

        //PRE: 
        //POS:  Abre el formulario Búsqueda. Si se selecciona un ejemplar, verifica que no esté ya en la lista.  Si no se ha añadido
        //       lo añade a ejemplaresEnPrestamo y actualiza la vista llamando a ActualizarVistaEjemplares()
        private void button_añadirEjemplar_Click(object sender, EventArgs e)
        {
            Búsqueda formBusqueda = new Búsqueda(this.personal);

            if (formBusqueda.ShowDialog() == DialogResult.OK)
            {
                Ejemplar nuevoEjemplar = formBusqueda.EjemplarSeleccionado;

                if (nuevoEjemplar != null)
                {
                    bool yaExiste = ejemplaresEnPrestamo.Any(ej =>
                        ej.Codigo == nuevoEjemplar.Codigo &&
                        ej.Documento.ISBN == nuevoEjemplar.Documento.ISBN);

                    if (yaExiste)
                    {
                        MessageBox.Show("Este ejemplar ya ha sido añadido al préstamo.");
                    }
                    else
                    {
                        ejemplaresEnPrestamo.Add(nuevoEjemplar);
                        ActualizarVistaEjemplares();
                    }
                }
            }
        }


        //PRE:  
        //POS:  Se actualiza el FlowLayoutPanel con los ejemplares que se quieren prestar
        private void ActualizarVistaEjemplares()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (Ejemplar ej in ejemplaresEnPrestamo)
            {
                Label lbl = new Label();
                lbl.Text = "ID: "+ej.Codigo + " ("+ej.Documento.Titulo+")";
                lbl.AutoSize = true;
                lbl.BorderStyle = BorderStyle.FixedSingle;
                lbl.Padding = new Padding(5);
                lbl.Margin = new Padding(3);
                flowLayoutPanel1.Controls.Add(lbl);
            }
        }


        //PRE:  
        //POS:  Se crea el objeto Prestamo. Llama a personal.realizarPrestamo(). Muestra un mensaje de éxito y se cierra el formulario.
        private void button_aceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_idprestamo.Text))
            {
                MessageBox.Show("Debe introducir un ID para el préstamo.");
                return;
            }

            if (comboBox_usuario.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un usuario.");
                return;
            }

            if (ejemplaresEnPrestamo.Count == 0)
            {
                MessageBox.Show("Debe añadir al menos un ejemplar al préstamo.");
                return;
            }

            string idPrestamo = textBox_idprestamo.Text;
            Usuario usuario = (Usuario)comboBox_usuario.SelectedItem;
            DateTime fechaInicio = DateTime.Now;
            DateTime fechaFin = fechaInicio.AddDays(15);

            ModeloDominio.PersonalSala p = (ModeloDominio.PersonalSala)personal.getPersonal(personal.IdPersonal);
            Prestamo nuevoPrestamo = new Prestamo(idPrestamo, fechaInicio, fechaFin, EstadoPrestamo.enProceso, usuario, p, ejemplaresEnPrestamo);

            personal.realizarPrestamo(nuevoPrestamo);
            MessageBox.Show("Préstamo registrado correctamente.");
            this.Close();
        }


        //PRE:  El usuario pulsa el boton "cancelar"
        //POS:  Se cierra el formulario
        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
