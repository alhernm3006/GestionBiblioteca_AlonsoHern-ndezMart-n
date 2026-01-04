using ModeloDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentación
{
    public partial class ListadoDocumento : Presentación.ListadoBase
    {
        private List<Documento> listaDocumentos;
        private LógicaNegocio.PersonalAdquisicion personal;
        public ListadoDocumento(LógicaNegocio.PersonalAdquisicion personal)
        {
            InitializeComponent();
            this.personal = personal;
        }

        private void ListadoDocumento_Load(object sender, EventArgs e)
        {
            listaDocumentos = personal.getDocumentos();
            CargarDatos(listaDocumentos);
            this.Text = "Listado de Documentos";
        }
    }
}
