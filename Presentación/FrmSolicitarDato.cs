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
    public partial class FrmSolicitarDato : Form
    {
        private LógicaNegocio.PersonalBiblioteca personal;
        private string op;
        private string etiqueta;
       /* public FrmSolicitarDato(string titulo, string etiqueta, LógicaNegocio.PersonalBiblioteca personal)
        {
            InitializeComponent();
            this.Text = titulo;        // Ej: "Introducir DNI"
            this.lblEtiqueta.Text = etiqueta; // Ej: "DNI:"
            this.personal = personal;
            
        }*/
        public FrmSolicitarDato(string titulo, string etiqueta, string op, LógicaNegocio.PersonalBiblioteca personal)
        {
            InitializeComponent();
            this.Text = titulo;        // Ej: "Introducir DNI"
            this.lblEtiqueta.Text = etiqueta; // Ej: "DNI:"
            this.op = op;
            this.personal = personal;
            this.etiqueta = etiqueta;
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_DNI.Text))
            {
                MessageBox.Show("El campo no puede estar vacío.");
                return;
            }

            if( (this.op.Equals("Alta")) && (this.etiqueta=="DNI:"))
            {
                // Comprobamos si el usuario YA existe
                if (personal.getUsuario(textBox_DNI.Text) != null)
                {
                    DialogResult resultado = MessageBox.Show("¿Quieres introducir otro?", "Ya existe un usuario con ese DNI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado.Equals(DialogResult.Yes))
                    {
                        this.Hide();
                        new FrmSolicitarDato("Introducir DNI", "DNI:", this.op, personal).Show();
                        this.Close();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    this.Hide();
                    // Abrimos el formulario de detalle pasando el DNI, la operación y la referencia al personal
                    new FrmDetalleUsuario(textBox_DNI.Text, this.op, this.personal).Show();
                    this.Close();
                }
            }
            else if (this.op.Equals("Baja") && (this.etiqueta == "DNI:"))
            {
                if (personal.getUsuario(textBox_DNI.Text) != null)
                {
                    this.Hide();
                    // Nota: aquí usabas el constructor de 4 parámetros, asegúrate de que exista
                    new FrmDetalleUsuario(textBox_DNI.Text, this.op, personal.getUsuario(textBox_DNI.Text).Nombre, this.personal).Show();
                    this.Close();
                }
                else
                {
                    // Lógica existente para cuando NO existe en Baja: preguntar de nuevo
                    DialogResult resultado = MessageBox.Show("¿Quieres introducir otro?", "No existe un usuario con ese DNI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado.Equals(DialogResult.Yes))
                    {
                        this.Hide();
                        new FrmSolicitarDato("Introducir DNI", "DNI:", this.op, personal).Show();
                        this.Close();
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
            else if (this.op.Equals("Búsqueda") && (this.etiqueta == "DNI:"))
            {
                Usuario usuario= personal.getUsuario(textBox_DNI.Text);
                if (usuario == null || usuario.Estado==EstadoActivoInactivo.inactivo)
                {
                   
                    // Si NO existe, mostramos el mensaje correcto (en tu código original decía "Ya existe")
                    DialogResult resultado = MessageBox.Show(
                        "¿Quieres introducir otro?",
                        "No existe un usuario con ese DNI",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (resultado.Equals(DialogResult.Yes))
                    {
                        this.Hide();
                        new FrmSolicitarDato("Introducir DNI", "DNI:", this.op, personal).Show();
                        this.Close();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                  
                    // Si SÍ existe, abrimos la ventana de detalles con los datos del usuario
                    this.Hide();
                    // Usamos el constructor que acepta DNI, Operación, Nombre y Personal
                    new FrmDetalleUsuario(
                        textBox_DNI.Text,
                        this.op,
                       personal.getUsuario(textBox_DNI.Text).Nombre,
                        this.personal
                    ).Show();
                    this.Close();
                }
            }

            if ((this.op.Equals("Alta")) && (this.etiqueta == "ISBN:"))
            {
                LógicaNegocio.PersonalAdquisicion p = (LógicaNegocio.PersonalAdquisicion)personal;
                // Comprobamos si el usuario YA existe
                if (p.buscarPorISBN((textBox_DNI.Text)) != null)
                {
                    DialogResult resultado = MessageBox.Show("¿Quieres introducir otro?", "Ya existe un documento con ese ISBN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado.Equals(DialogResult.Yes))
                    {
                        this.Hide();
                        new FrmSolicitarDato("Introducir ISBN", "ISBN:", this.op, personal).Show();
                    }
                    this.Close();
                }
                else
                {
                    // --- CÓDIGO AÑADIDO: Si no existe, procedemos al Alta ---
                    this.Hide();
                    // Abrimos el formulario de detalle pasando el DNI, la operación y la referencia al personal
                    new AltaDocumentos(textBox_DNI.Text, this.op, this.personal).Show();
                    this.Close();
                }

            }
            else if (this.op.Equals("Baja") && (this.etiqueta == "ISBN:"))
            {
                LógicaNegocio.PersonalAdquisicion p = (LógicaNegocio.PersonalAdquisicion)personal;
                // ... (resto del código igual para Baja) ...
                if (p.buscarPorISBN(textBox_DNI.Text) != null)
                {
                    // Lógica existente para cuando SI existe en Baja: mostrar detalles para borrar
                    this.Hide();
                    // Nota: aquí usabas el constructor de 4 parámetros, asegúrate de que exista
                    new AltaDocumentos(textBox_DNI.Text, this.op, p.buscarPorISBN((textBox_DNI.Text)), this.personal).Show();
                    this.Close();
                }
                else
                {
                    // Lógica existente para cuando NO existe en Baja: preguntar de nuevo
                    DialogResult resultado = MessageBox.Show("¿Quieres introducir otro?", "No existe un documento con ese ISBN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado.Equals(DialogResult.Yes))
                    {
                        this.Hide();
                        new FrmSolicitarDato("Introducir ISBN", "ISBN:", this.op, personal).Show();
                    }
                    this.Close();
                }
            }
            else if (this.op.Equals("Búsqueda") && (this.etiqueta == "ISBN:"))
            {
                LógicaNegocio.PersonalAdquisicion p = (LógicaNegocio.PersonalAdquisicion)personal;

                // Usamos el texto introducido (textBox_DNI se reutiliza para ISBN)
                Documento d = p.buscarPorISBN(textBox_DNI.Text);

                // Verificamos si es nulo o está inactivo
                if (d == null || d.Estado == EstadoActivoInactivo.inactivo)
                {
                    DialogResult resultado = MessageBox.Show(
                        "No se ha encontrado ningún documento activo con ese ISBN. ¿Desea buscar otro?",
                        "Búsqueda sin resultados",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (resultado == DialogResult.Yes)
                    {
                        this.Hide();
                        // Reabrimos la ventana para intentarlo de nuevo
                        new FrmSolicitarDato("Introducir ISBN", "ISBN:", this.op, personal).Show();
                    }
                    this.Close();
                }
                else
                {
                    // SI LO ENCUENTRA: Abrimos el formulario de detalle
                    this.Hide();
                    new AltaDocumentos(textBox_DNI.Text, this.op, d, this.personal).Show();
                    this.Close();
                }
            }
            }



        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
