
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
           
        }

        private void button_entrar_Click(object sender, EventArgs e)
        {
            string nombre = textBox_nombre.Text;
            string password = textBox_apellido.Text; // Suponiendo que tienes este campo

            // 1. Validar que haya escrito el nombre
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Por favor, introduce un nombre.");
                return;
            }
            
            LógicaNegocio.PersonalBiblioteca personal = null;

            // 2. Verificar qué "Tipo empleado" se seleccionó
            if (radioButton_personalSala.Checked)
            {
                // Se seleccionó "Personal sala"
                // El constructor pide (NSS, Nombre). Simulamos el NSS por ahora o lo pedimos si hace falta.
                personal = new PersonalSala();
            }
            else if (radioButton_personalAdquisiciones.Checked)
            {
                // Se seleccionó "Personal adquisiciones"
                personal = new PersonalAdquisicion();
            }
            else
            {
                // No se seleccionó ninguno (raro en RadioButtons, pero posible si no hay default)
                MessageBox.Show("Debes seleccionar un tipo de empleado.");
                return;
            }

            // 3. Intentar iniciar sesión
            // Usamos el método polimórfico 'iniciarSesion' de la clase base PersonalBiblioteca
            if (personal.iniciarSesion(nombre, password))
            {
                // Login correcto: Abrir el menú principal pasándole el usuario creado
                FrmMenuPrincipal menu = new FrmMenuPrincipal(personal);
                this.Hide();
                menu.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error en el inicio de sesión.");
            }
        }
    }
}
