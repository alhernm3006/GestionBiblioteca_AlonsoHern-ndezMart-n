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

        public FormPrestamo(LógicaNegocio.PersonalSala personal)
        {
           
                InitializeComponent();
                this.personal = personal;
                this.ejemplaresEnPrestamo = new List<Ejemplar>();
                CargarDatosIniciales();
  
        }

        public FormPrestamo(LógicaNegocio.PersonalSala personal,string codigo)
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
                lblPrestado.Text = $"PRESTADO:\n{e.Documento.Titulo}( Cód: {e.Codigo})";
                lblPrestado.AutoSize = true;
               

                // Añadimos al panel
                flowLayoutPanel1.Controls.Add(lblPrestado);
            }
          
            CargarDatosIniciales();

        }



      

        private void CargarDatosIniciales()
        {
            // 1. Establecer fecha actual
            textBox_fecha.Text = DateTime.Now.ToShortDateString();
            textBox_fecha.ReadOnly = true; // La fecha no debería editarse manualmente

            // 2. Cargar Usuarios en el ComboBox
            try
            {
                // PersonalBiblioteca (padre de PersonalSala) tiene obtenerUsuarios
                List<Usuario> usuarios = personal.obtenerUsuarios();

                // Filtramos solo usuarios activos si es necesario
                var usuariosActivos = usuarios.Where(u => u.Estado == EstadoActivoInactivo.activo).ToList();

                comboBox_usuario.DataSource = usuariosActivos;
                // Mostramos el DNI o el Nombre según prefiera el cliente. El PDF muestra DNI en el combo.
                comboBox_usuario.DisplayMember = "DNI";
                comboBox_usuario.ValueMember = "DNI"; // Usamos el objeto completo o el DNI como valor
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
        }

        private void button_añadirEjemplar_Click(object sender, EventArgs e)
        {
            Búsqueda formBusqueda = new Búsqueda(this.personal);

            // 2. Mostramos el formulario como diálogo modal
            if (formBusqueda.ShowDialog() == DialogResult.OK)
            {
                // 3. Recuperamos el ejemplar seleccionado (requiere que añadas esta propiedad pública en Búsqueda)
                Ejemplar nuevoEjemplar = formBusqueda.EjemplarSeleccionado;

                if (nuevoEjemplar != null)
                {
                    // 4. Validamos que el ejemplar no esté ya en la lista
                    bool yaExiste = ejemplaresEnPrestamo.Any(ej =>
                        ej.Codigo == nuevoEjemplar.Codigo &&
                        ej.Documento.ISBN == nuevoEjemplar.Documento.ISBN);

                    if (yaExiste)
                    {
                        MessageBox.Show("Este ejemplar ya ha sido añadido al préstamo.");
                    }
                    else
                    {
                        AgregarEjemplarALista(nuevoEjemplar);
                    }
                }
            }
        }
        private void AgregarEjemplarALista(Ejemplar ej)
        {
            ejemplaresEnPrestamo.Add(ej);
            ActualizarVistaEjemplares();
        }

        private void ActualizarVistaEjemplares()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (Ejemplar ej in ejemplaresEnPrestamo)
            {
                Label lbl = new Label();
                lbl.Text = $"ID: {ej.Codigo} ({ej.Documento.Titulo})";
                lbl.AutoSize = true;
                lbl.BorderStyle = BorderStyle.FixedSingle;
                lbl.Padding = new Padding(5);
                lbl.Margin = new Padding(3);
                flowLayoutPanel1.Controls.Add(lbl);
            }
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            // Validaciones
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

            try
            {
                // Recopilar datos
                string idPrestamo = textBox_idprestamo.Text;
                Usuario usuario = (Usuario)comboBox_usuario.SelectedItem;
                DateTime fechaInicio = DateTime.Now;
                // Fecha fin: Suponemos 15 días de préstamo por defecto, o lógica de negocio
                DateTime fechaFin = fechaInicio.AddDays(15);

                ModeloDominio.PersonalSala p = new ModeloDominio.PersonalSala(personal.Nombre,personal.Contraseña);
                // Crear objeto Préstamo
                // Constructor: ID, FechaInicio, FechaFin, Estado, Usuario, Personal, ListaEjemplares
                Prestamo nuevoPrestamo = new Prestamo(
                    idPrestamo,
                    fechaInicio,
                    fechaFin,
                    EstadoPrestamo.enProceso,
                    usuario,
                   p, // El personal de sala que realiza la operación
                    ejemplaresEnPrestamo
                );

                // Llamar a la lógica de negocio
                personal.realizarPrestamo(nuevoPrestamo);

                MessageBox.Show("Préstamo registrado correctamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el préstamo: " + ex.Message);
            }
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }
