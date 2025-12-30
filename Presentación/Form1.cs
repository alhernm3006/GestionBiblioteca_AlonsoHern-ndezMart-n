
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Ajuste visual por código si no se hace en el Designer
            label_contraseña.Text = "Contraseña";
            textBox_contraseña.PasswordChar = '*';
        }

        private void button_entrar_Click(object sender, EventArgs e)
        {
            string nombre = textBox_nombre.Text;
            string password = textBox_contraseña.Text; // Este campo actúa como contraseña

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, introduce nombre y contraseña.");
                return;
            }

            LógicaNegocio.PersonalBiblioteca personal = null;

            if (radioButton_personalSala.Checked)
            {
                // También es probable que necesites especificarlo aquí para evitar ambigüedad con PersonalSala
                personal = new LógicaNegocio.PersonalSala();
            }
            else if (radioButton_personalAdquisiciones.Checked)
            {
                // Y aquí
                personal = new LógicaNegocio.PersonalAdquisicion();
            }
            else
            {
                MessageBox.Show("Debes seleccionar un tipo de empleado.");
                return;
            }

            // Validar credenciales
            if (personal.iniciarSesion(nombre, password))
            {
                // Pasamos el objeto 'personal' al menú para controlar permisos
                menuPersonalSala menu = new menuPersonalSala((LógicaNegocio.PersonalSala)personal);
                this.Hide();
                menu.ShowDialog(); // La ejecución se detiene aquí hasta que se cierre el menú
                this.Close();      // Cierra la app al salir del menú
            }
            else
            {
                MessageBox.Show("Error en el inicio de sesión.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
