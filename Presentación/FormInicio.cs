
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
        private string idUsuario;
        private string password;
        private string rol;
        public FormInicio()
        {
            
            InitializeComponent();
        }

        private void button_entrar_Click(object sender, EventArgs e)
        {
            idUsuario = textBox_nombre.Text;
            password = textBox_contraseña.Text;

            if (string.IsNullOrEmpty(idUsuario) || string.IsNullOrEmpty(password))
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

            // Validar credenciales
            if (personal.iniciarSesion(idUsuario, password, rol))
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
