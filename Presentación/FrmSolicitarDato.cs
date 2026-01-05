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

        //PRE:  titulo, etiqueta y op son cadenas no nulas. personal es PersonalBiblioteca valido.
        //POS:  Se inicializa el formulario asignandose los parametros a los atributos
        public FrmSolicitarDato(string titulo, string etiqueta, string op, LógicaNegocio.PersonalBiblioteca personal)
        {
            InitializeComponent();
            this.Text = titulo;     
            this.lblEtiqueta.Text = etiqueta;
            this.op = op;
            this.personal = personal;
            this.etiqueta = etiqueta;
        }

        //PRE:  El usuario pulsa el botón Aceptar. El campo de texto contiene el dato solicitado
        //POS:  Valida la existencia del dato en la capa de negocio.
        //      -Alta: Si no existe, abre el formulario de alta correspondiente. Si existe, avisa y permite reintentar
        //      -Baja o Busqueda: Si existe, abre el formulario de gestión con los datos cargados. Si no existe, avisa y permite reintentar.
        private void button_aceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_DNI.Text))
            {
                MessageBox.Show("El campo no puede estar vacío.");
                return;
            }

            if ((this.op.Equals("Alta")) && (this.etiqueta == "DNI:"))
            {
                if (personal.getUsuario(textBox_DNI.Text) != null)
                {
                    DialogResult resultado = MessageBox.Show("¿Quieres introducir otro?", "Ya existe un usuario con ese DNI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado.Equals(DialogResult.Yes))
                    {
                        this.Hide();
                        new FrmSolicitarDato("Introducir DNI", "DNI:", this.op, personal).Show();
                    }
                    this.Close();
                }
                else
                {
                    this.Hide();
                    new FormUsuario(textBox_DNI.Text, this.op, this.personal).Show();
                    this.Close();
                }
            }
            else if (this.op.Equals("Baja") && (this.etiqueta == "DNI:"))
            {
                if (personal.getUsuario(textBox_DNI.Text) != null)
                {
                    this.Hide();
                    new FormUsuario(textBox_DNI.Text, this.op, personal.getUsuario(textBox_DNI.Text).Nombre, this.personal).Show();
                    this.Close();
                }
                else
                {
                    DialogResult resultado = MessageBox.Show("¿Quieres introducir otro?", "No existe un usuario con ese DNI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado.Equals(DialogResult.Yes))
                    {
                        this.Hide();
                        new FrmSolicitarDato("Introducir DNI", "DNI:", this.op, personal).Show();
                    }
                    this.Close();
                }
            }
            else if (this.op.Equals("Búsqueda") && (this.etiqueta == "DNI:"))
            {
                Usuario usuario = personal.getUsuario(textBox_DNI.Text);
                if (usuario == null || usuario.Estado == EstadoActivoInactivo.inactivo)
                {
                    DialogResult resultado = MessageBox.Show("¿Quieres introducir otro?", "No existe un usuario con ese DNI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado.Equals(DialogResult.Yes))
                    {
                        this.Hide();
                        new FrmSolicitarDato("Introducir DNI", "DNI:", this.op, personal).Show();
                    }
                    this.Close();
                }
                else
                {
                    this.Hide();
                    new FormUsuario(textBox_DNI.Text, this.op, personal.getUsuario(textBox_DNI.Text).Nombre, this.personal).Show();
                    this.Close();
                }
            }

            if ((this.op.Equals("Alta")) && (this.etiqueta == "ISBN:"))
            {
                LógicaNegocio.PersonalAdquisicion p = (LógicaNegocio.PersonalAdquisicion)personal;

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
                    this.Hide();
                    new FormDocumento(textBox_DNI.Text, this.op, this.personal).Show();
                    this.Close();
                }
            }
            else if (this.op.Equals("Baja") && (this.etiqueta == "ISBN:"))
            {
                LógicaNegocio.PersonalAdquisicion p = (LógicaNegocio.PersonalAdquisicion)personal;

                if (p.buscarPorISBN(textBox_DNI.Text) != null && p.getEjemplares(textBox_DNI.Text).Count(ej => ej.Estado == EstadoEjemplar.prestado)==0)
                {
                    this.Hide();
                    new FormDocumento(textBox_DNI.Text, this.op, p.buscarPorISBN((textBox_DNI.Text)), this.personal).Show();
                    this.Close();
                }
                else
                {
                    if (p.buscarPorISBN(textBox_DNI.Text) == null)
                    {
                        DialogResult resultado = MessageBox.Show("¿Quieres introducir otro?", "No existe un documento con ese ISBN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado.Equals(DialogResult.Yes))
                        {
                            this.Hide();
                            new FrmSolicitarDato("Introducir ISBN", "ISBN:", this.op, personal).Show();
                        }
                        this.Close();
                    }
                    else
                    {
                        DialogResult resultado = MessageBox.Show("¿Quieres introducir otro?", "Documento con ejemplares en prestamo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado.Equals(DialogResult.Yes))
                        {
                            this.Hide();
                            new FrmSolicitarDato("Introducir ISBN", "ISBN:", this.op, personal).Show();
                        }
                        this.Close();
                    }
                }
            }
            else if (this.op.Equals("Búsqueda") && (this.etiqueta == "ISBN:"))
            {
                LógicaNegocio.PersonalAdquisicion p = (LógicaNegocio.PersonalAdquisicion)personal;
                Documento d = p.buscarPorISBN(textBox_DNI.Text);

                if (d == null || d.Estado == EstadoActivoInactivo.inactivo)
                {
                    DialogResult resultado = MessageBox.Show("No se ha encontrado ningún documento activo con ese ISBN. ¿Desea buscar otro?", "Búsqueda sin resultados", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        this.Hide();
                        new FrmSolicitarDato("Introducir ISBN", "ISBN:", this.op, personal).Show();
                    }
                    this.Close();
                }
                else
                {
                    this.Hide();
                    new FormDocumento(textBox_DNI.Text, this.op, d, this.personal).Show();
                    this.Close();
                }
            }

            if ((this.op.Equals("Alta")) && (this.etiqueta == "Codigo:"))
            {
                LógicaNegocio.PersonalAdquisicion p = (LógicaNegocio.PersonalAdquisicion)personal;

                if (p.getDocumentos().Count == 0)
                {
                    MessageBox.Show("No hay documentos registrados en el sistema. Debe dar de alta un documento antes de crear ejemplares.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }
                this.Hide();
                new FormEjemplar(textBox_DNI.Text, p, "Alta").Show();
                this.Close();
            }
            else if (this.op.Equals("Búsqueda") && (this.etiqueta == "Codigo:"))
            {
                LógicaNegocio.PersonalAdquisicion p = (LógicaNegocio.PersonalAdquisicion)personal;
                string codigoBuscado = textBox_DNI.Text;
                bool encontrado = false;

                foreach (ModeloDominio.Documento doc in p.getDocumentos())
                {
                    if (p.getEjemplar(doc.ISBN, codigoBuscado) != null)
                    {
                        encontrado = true;
                        break;
                    }
                }
                if (!encontrado)
                {
                    DialogResult resultado = MessageBox.Show(
                        "No se ha encontrado ningún ejemplar con ese código. ¿Desea buscar otro?",
                        "Búsqueda sin resultados",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (resultado == DialogResult.Yes)
                    {
                        this.Hide();
                        new FrmSolicitarDato("Introducir codigo", "Codigo:", this.op, personal).Show();
                    }
                    this.Close();
                }
                else
                {
                    this.Hide();
                    new FormEjemplar(codigoBuscado, p, "Búsqueda").Show();
                    this.Close();
                }
            }

            if ((this.op.Equals("Búsqueda")) && (this.etiqueta == "Prestamo:"))
            {
                LógicaNegocio.PersonalSala p = (LógicaNegocio.PersonalSala)personal;

                if (p.obtenerPrestamos().Count == 0)
                {
                    MessageBox.Show("No hay prestamos registrados en el sistema. Debe dar de alta un prestamo antes de crear ejemplares.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }
                else
                {

                    if (p.buscarPrestamo(this.textBox_DNI.Text)==null)
                    {
                        MessageBox.Show("No hay prestamso con ese ISBN.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                        return;
                    }
                    this.Hide();
                    new FormPrestamo(p,this.textBox_DNI.Text).Show();
                    this.Close();
                }
            }
        }


        //PRE:  El usuario pulsa el boton "cancelar".
        //POS:  Se cierra el formulario actual.
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
