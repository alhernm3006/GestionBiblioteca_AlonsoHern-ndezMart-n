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
    public partial class menuPersonalSala : Form
    {
        public menuPersonalSala(PersonalSala p)
        {
            InitializeComponent();
        }

        private void menuPersonalSala_Load(object sender, EventArgs e)
        {

        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // 1. Pedir DNI [cite: 211]
            FrmSolicitarDato frmDni = new FrmSolicitarDato("Introducir DNI", "DNI:");

           // Bucle para permitir reintentar si ya existe [cite: 247]
            while (frmDni.ShowDialog() == DialogResult.OK)
            {
                string dni = frmDni.DatoIntroducido;

                // Verificar si existe (usando LógicaNegocio)
                if (usuarioActual.getUsuario(dni) != null)
                {
                     DialogResult r = MessageBox.Show("Ya existe un usuario con ese DNI\n¿Quieres introducir otro?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question); [cite: 240, 243]
            if (r == DialogResult.No) break;
                    // Si dice Sí, el bucle while repite y muestra el form de DNI otra vez
                }
                else
                {
                   // No existe, procedemos al Alta [cite: 249]
                    FrmDetalleUsuario frmAlta = new FrmDetalleUsuario(dni);
                    if (frmAlta.ShowDialog() == DialogResult.OK)
                    {
                        // Recuperamos el objeto creado por el formulario
                        Usuario nuevoUsuario = frmAlta.UsuarioCreado;
                        if (usuarioActual.altaUsuario(nuevoUsuario))
                        {
                            MessageBox.Show("Usuario dado de alta correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("Error al guardar el usuario.");
                        }
                    }
                    break; // Salir del bucle tras el proceso
                }
            }
        }
    }
}
