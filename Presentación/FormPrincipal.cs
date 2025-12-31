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
    public partial class FrmPrincipal : Form
    {
        private PersonalBiblioteca personal;
        public FrmPrincipal(PersonalBiblioteca p)
        {
            InitializeComponent();
            this.personal= p;
        }

        private void usuariosToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            FrmSolicitarDato solicitud = null;
            switch (e.ClickedItem.Text)
            {
                //case ("Búsqueda"): solicitud = new FrmSolicitarDato("Introducir DNI", "DNI:", personal); break;
                default: solicitud = new FrmSolicitarDato("Introducir DNI", "DNI:", e.ClickedItem.Text, personal); break;
            }
            solicitud.Show();
        }
    } 
}
