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
    public partial class FrmDetalleUsuario : Form
    {
        public Usuario UsuarioCreado;
        public FrmDetalleUsuario(string dni)
        {
            InitializeComponent();
            this.Text = "Alta de usuario";
            textBox_DNI.Text = dni;
            button_aceptar.Text = "Dar alta";
        }

        public FrmDetalleUsuario(Usuario u, string titulo)
        {
            InitializeComponent();
            this.Text = titulo;
            textBox_DNI.Text = u.DNI;
            textBox_Nombre.Text = u.Nombre;

           
           
            textBox_Nombre.ReadOnly = true;
            button_aceptar.Text = "Aceptar"; // O "Dar de Baja" según el caso
            
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            // Si estamos en modo Alta (txtNombre no es ReadOnly)
            if (!textBox_Nombre.ReadOnly)
            {
                if (string.IsNullOrWhiteSpace(textBox_Nombre.Text))
                {
                     MessageBox.Show("Debes introducir un nombre para el usuario", "Error");
                    return;
                }
                // Creamos el usuario para que lo recoja el formulario principal
                UsuarioCreado = new Usuario(textBox_DNI.Text, textBox_Nombre.Text);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button_salir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void ConfigurarBoton(string textoBoton)
        {
            button_aceptar.Text = textoBoton;
        }
    }
}
