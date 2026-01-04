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
                préstamosToolStripMenuItem.Visible = false;
                
            }
            else if (this.personal is PersonalSala)
            {
                documentosToolStripMenuItem.Visible = false;
                ejemplaresToolStripMenuItem.Visible = false;
            }
        }

        private void usuariosToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case ("Listado"): new ListadoUsuario(personal, "Usuario").Show(); break;
                case ("Búsqueda por DNI"): new BusquedaDNI(personal).Show(); break;
                case ("Recorrido uno a uno"): new Recorrido(personal).Show(); break;
                default: new FrmSolicitarDato("Introducir DNI", "DNI:", e.ClickedItem.Text, personal).Show(); break;
            }
        }

        private void documentosToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {

                //case ("Búsqueda"): solicitud = new FrmSolicitarDato("Introducir DNI", "DNI:", personal); break;
                case ("Listado"): new ListadoDocumento((PersonalAdquisicion)this.personal).Show(); break;
                default: new FrmSolicitarDato("Introducir ISBN", "ISBN:", e.ClickedItem.Text, personal).Show(); break;
            }
        }

       

        private void ejemplaresToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                //case ("Búsqueda"): solicitud = new FrmSolicitarDato("Introducir DNI", "DNI:", personal); break;
                case ("Listado"): new ListadoEjemplares((PersonalAdquisicion)this.personal).Show(); break;
                default: new FrmSolicitarDato("Introducir codigo", "Codigo:", e.ClickedItem.Text, personal).Show(); break;
            }
        }

        private void préstamosToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                //case ("Búsqueda"): solicitud = new FrmSolicitarDato("Introducir DNI", "DNI:", personal); break;
                case ("Listado"): new ListadoPrestamo((PersonalSala)this.personal).Show(); break;
                case ("Búsqueda"): new FrmSolicitarDato("Introducir ID prestamo", "Prestamo:", e.ClickedItem.Text, personal).Show(); break;
                default: new FormPrestamo((PersonalSala)this.personal).Show(); break;
            }
        }
    } 
}
