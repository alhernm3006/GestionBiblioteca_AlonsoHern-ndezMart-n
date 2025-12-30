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
        private string op;
        public FrmSolicitarDato(string titulo, string etiqueta)
        {
    
            InitializeComponent();
            this.Text = titulo;        // Ej: "Introducir DNI"
            this.lblEtiqueta.Text = etiqueta; // Ej: "DNI:"
        }
        public FrmSolicitarDato(string titulo, string etiqueta, string op)
        {

            InitializeComponent();
            this.Text = titulo;        // Ej: "Introducir DNI"
            this.lblEtiqueta.Text = etiqueta; // Ej: "DNI:"
            this.op = op;
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_DNI.Text))
            {
                MessageBox.Show("El campo no puede estar vacío.");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Hide();
            new FrmDetalleUsuario(textBox_DNI.Text, this.op).Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
