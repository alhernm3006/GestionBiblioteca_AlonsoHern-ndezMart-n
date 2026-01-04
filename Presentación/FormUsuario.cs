using LógicaNegocio;
using ModeloDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentación
{
    public partial class FormUsuario : Form
    {
        private LógicaNegocio.PersonalBiblioteca personal;
        private string operacion;
        public FormUsuario(string dni, string operacion, LógicaNegocio.PersonalBiblioteca personal)
        {
            InitializeComponent();
            this.Text = operacion+" de usuario";
            textBox_DNI.Text = dni;
            this.personal = personal;
            if (operacion.Equals("Alta"))
            {
                this.operacion = operacion;
                textBox_DNI.ReadOnly = true;
            }
        }
        public FormUsuario(string dni, string operacion, string nombre, LógicaNegocio.PersonalBiblioteca personal)
        {
            InitializeComponent();
            this.Text = operacion + " de usuario";
            textBox_DNI.Text = dni;
            this.personal = personal;
            if (operacion.Equals("Baja"))
            {
                this.operacion = operacion;
                textBox_DNI.ReadOnly = true;
                textBox_Nombre.Text = nombre;
                textBox_Nombre.ReadOnly = true;
            }else if (operacion.Equals("Búsqueda"))
            {
                this.operacion = operacion;
                this.Text = "Datos de usuario";

                textBox_DNI.ReadOnly = true;
                textBox_Nombre.Text = nombre;   
                textBox_Nombre.ReadOnly = true;

                button_aceptar.Hide();
                button_salir.Hide();
            }
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            if (!textBox_Nombre.ReadOnly)
            {
                if (string.IsNullOrWhiteSpace(textBox_Nombre.Text))
                {
                    MessageBox.Show("Debes introducir un nombre para el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    personal.altaUsuario(new Usuario(textBox_DNI.Text, textBox_Nombre.Text));
                    DialogResult resultado = MessageBox.Show("Usuario añadido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (resultado.Equals(DialogResult.OK)) this.Close();
                }
            }
            else
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro que desea dar de baja al usuario?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado.Equals(DialogResult.Yes))
                {
                    personal.bajaUsuario(textBox_Nombre.Text);
                    DialogResult r2 = MessageBox.Show("Usuario eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (resultado.Equals(DialogResult.OK)) this.Close();  
                }
            }
        }

        private void button_salir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
