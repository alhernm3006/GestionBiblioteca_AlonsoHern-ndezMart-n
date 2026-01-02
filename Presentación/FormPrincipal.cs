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
            if (this.personal is PersonalAdquisicion)
            {
                
            }
            else if (this.personal is PersonalSala)
            {
                documentosToolStripMenuItem.Visible = false;
                ejemplaresToolStripMenuItem.Visible = false;
            }
        }

        private void usuariosToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //FrmSolicitarDato solicitud = null;
            //Listado listar = null;
            switch (e.ClickedItem.Text)
            {
                case ("Listado"): Listado listar = null; listar = new Listado(personal); listar.Show(); break;
                case ("Búsqueda por DNI"): BusquedaUsuario2 b2 = null;b2 = new BusquedaUsuario2(personal); b2.Show(); break;
                default: FrmSolicitarDato solicitud = null; solicitud = new FrmSolicitarDato("Introducir DNI", "DNI:", e.ClickedItem.Text, personal); solicitud.Show(); break;
            }
            //solicitud.Show();
        }

        private void documentosToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            FrmSolicitarDato solicitud = null;
            switch (e.ClickedItem.Text)
            {
                //case ("Búsqueda"): solicitud = new FrmSolicitarDato("Introducir DNI", "DNI:", personal); break;
                default: solicitud = new FrmSolicitarDato("Introducir ISBN", "ISBN:", e.ClickedItem.Text, personal); break;
            }
            solicitud.Show();
        }

       

        private void ejemplaresToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            FrmSolicitarDato solicitud = null;
            switch (e.ClickedItem.Text)
            {
                //case ("Búsqueda"): solicitud = new FrmSolicitarDato("Introducir DNI", "DNI:", personal); break;
                default: solicitud = new FrmSolicitarDato("Introducir codigo", "Codigo:", e.ClickedItem.Text, personal); break;
            }
            solicitud.Show();
        }
    } 
}
