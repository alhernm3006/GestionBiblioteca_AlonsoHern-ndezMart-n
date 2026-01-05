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
        //PRE:  p es una instancia valida de PersonalBiblioteca autenticada correctamente.
        //POS:  Inicializa los componentes y configura la visibilidad de los elementos del menú "Préstamos", "Documentos", "Ejemplares" según si p es PersonalAdquisicion o PersonalSala.
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

        //PRE:  El usuario ha seleccionado una opción del menu Usuarios
        //POS:  Se abre el formulario correspondiente: ListadoUsuario, BusquedaDNI, RecorridoUsuario o FrmSolicitarDato.
        private void usuariosToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case ("Listado"): new ListadoUsuario(personal, "Usuario").Show(); break;
                case ("Búsqueda por DNI"): new BusquedaDNI(personal).Show(); break;
                case ("Recorrido uno a uno"): new RecorridoUsuario(personal).Show(); break;
                default: new FrmSolicitarDato("Introducir DNI", "DNI:", e.ClickedItem.Text, personal).Show(); break;
            }
        }

        //PRE:  El usuario ha seleccionado una opción del menú Documentos
        //POS:  Se abre el formulario correspondiente: ListadoDocumento, RecorridoDocumentos o FrmSolicitarDato.
        private void documentosToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case ("Listado"): new ListadoDocumento((PersonalAdquisicion)this.personal).Show(); break;
                case ("Recorrido uno a uno"): new RecorridoDocumentos((PersonalAdquisicion)this.personal).Show(); break;
                default: new FrmSolicitarDato("Introducir ISBN", "ISBN:", e.ClickedItem.Text, personal).Show(); break;
            }
        }


        //PRE:  El usuario ha seleccionado una opción del menú Ejemplares
        //POS:  Se abre el formulario correspondiente: ListadoEjemplares o FrmSolicitarDato
        private void ejemplaresToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case ("Listado"): new ListadoEjemplares((PersonalAdquisicion)this.personal).Show(); break;
                default: new FrmSolicitarDato("Introducir codigo", "Codigo:", e.ClickedItem.Text, personal).Show(); break;
            }
        }

        //PRE:  El usuario ha seleccionado una opción del menú Préstamos
        //POS:  Se abre el formulario correspondiente: ListadoPrestamo, FrmSolicitarDato o FormPrestamo
        private void préstamosToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case ("Listado"): new ListadoPrestamo((PersonalSala)this.personal).Show(); break;
                case ("Búsqueda"): new FrmSolicitarDato("Introducir ID prestamo", "Prestamo:", e.ClickedItem.Text, personal).Show(); break;
                default: new FormPrestamo((PersonalSala)this.personal).Show(); break;
            }
        }
    } 
}
