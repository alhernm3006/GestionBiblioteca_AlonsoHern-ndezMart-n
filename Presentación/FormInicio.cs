
using LógicaNegocio;
using ModeloDominio;
using Persistencia;
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
    public partial class FormInicio : Form
    {
        private string idPersonal;
        private string password;
        private string rol;

        //PRE: 
        //POS:  Inicializa los componentes visuales del formulario de inicio de sesión.
        public FormInicio()
        {
            InitializeComponent();
        }

        //PRE:  El usuario ha introducido texto en los campos de usuario y contraseña y ha seleccionado su rol.
        //POS:  Si las credenciales y el rol son válidos, oculta el formulario actual, instancia, muestra el FrmPrincipal y cierra el formulario actual.
        //      Si las credenciales son incorrectas o faltan datos, muestra un mensaje de error y mantiene el formulario abierto.
        private void button_entrar_Click(object sender, EventArgs e)
        {
            idPersonal = textBox_nombre.Text;
            password = textBox_contraseña.Text;

            if (string.IsNullOrEmpty(idPersonal) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, introduce nombre y contraseña.");
                return;
            }

            LógicaNegocio.PersonalBiblioteca personal = null;

            if (radioButton_personalSala.Checked)
            {
                personal = new LógicaNegocio.PersonalSala();
                this.rol = "Sala";
            }
            else if (radioButton_personalAdquisiciones.Checked)
            {
                personal = new LógicaNegocio.PersonalAdquisicion();
                this.rol = "Adquisición";
            }
            else
            {
                MessageBox.Show("Debes seleccionar un tipo de empleado.");
                return;
            }

            if (personal.iniciarSesion(idPersonal, password, rol))
            {
                FrmPrincipal menu = new FrmPrincipal(personal);
                this.Hide();
                menu.ShowDialog(); 
                this.Close();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas", "Personal no autorizado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
