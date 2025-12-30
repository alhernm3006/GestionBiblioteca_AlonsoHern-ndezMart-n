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
        public FrmDetalleUsuario(string dni, string operacion)
        {
            InitializeComponent();
            this.Text = operacion+" de usuario";
            textBox_DNI.Text = dni;
            if (operacion.Equals("Alta"))
            {
                textBox_DNI.ReadOnly = true;
            }else if (operacion.Equals("Baja"))
            {
                textBox_DNI.ReadOnly = true;
                textBox_Nombre.ReadOnly = true;
            }
            
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
