using LógicaNegocio;
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
        private PersonalBiblioteca personal;
        private string op;
        public FrmSolicitarDato(string titulo, string etiqueta, PersonalBiblioteca personal)
        {
            InitializeComponent();
            this.Text = titulo;        // Ej: "Introducir DNI"
            this.lblEtiqueta.Text = etiqueta; // Ej: "DNI:"
            this.personal = personal;
        }
        public FrmSolicitarDato(string titulo, string etiqueta, string op, PersonalBiblioteca personal)
        {
            InitializeComponent();
            this.Text = titulo;        // Ej: "Introducir DNI"
            this.lblEtiqueta.Text = etiqueta; // Ej: "DNI:"
            this.op = op;
            this.personal = personal;
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_DNI.Text))
            {
                MessageBox.Show("El campo no puede estar vacío.");
                return;
            }
            this.DialogResult = DialogResult.OK;
            if (this.op.Equals("Alta"))
            {
                if (personal.getUsuario(textBox_DNI.Text)!=null)
                {
                    DialogResult resultado = MessageBox.Show("¿Quieres introducir otro?", "Ya existe un usuario con ese DNI",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
            }else if (this.op.Equals("Baja"))
            {
                if (personal.getUsuario(textBox_DNI.Text)!=null)
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
                    new FrmDetalleUsuario(textBox_DNI.Text, this.op, personal.getUsuario(textBox_DNI.Text).Nombre,this.personal).Show();
                    this.Close();
                }
            }
            else if (this.op.Equals("Búsqueda"))
            {
                if (personal.getUsuario(textBox_DNI.Text) == null)
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
                    new FrmDetalleUsuario(textBox_DNI.Text, this.op, personal.getUsuario(textBox_DNI.Text).Nombre, this.personal).Show();
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
