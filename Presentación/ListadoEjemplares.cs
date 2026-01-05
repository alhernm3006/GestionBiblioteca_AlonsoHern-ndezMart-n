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
    public partial class ListadoEjemplares : Presentación.ListadoBase
    {

        private List<Ejemplar> listaEjemplares;
        private List<Documento> documentos;
        private LógicaNegocio.PersonalAdquisicion personal;

        //PRE:  personal es un PersonalAdquisicion valido.
        //POS:  Se inicializa el formulario.
        public ListadoEjemplares(LógicaNegocio.PersonalAdquisicion personal)
        {
            InitializeComponent();
            this.personal = personal;
            this.Text = "Listado de Ejemplares";
        }


        //PRE:  Se carga el listado de ejemplares
        //POS:  Se obtienen todos los ejemplares. A partir de los datos de esos ejemplares se crean objetos de tipo DatosEjemplar y se almacenan en una lista. Se llama a CargarDatos() con esa lista.
        private void ListadoEjemplares_Load(object sender, EventArgs e)
        {
            List<DatosEjemplar> listaParaMostrar = new List<DatosEjemplar>();
            List<Documento> misDocumentos = personal.getDocumentos();

            foreach (Documento doc in misDocumentos)
            {
                if (doc.Estado == EstadoActivoInactivo.activo)
                {
                    List<Ejemplar> ejemplaresLibro = personal.getEjemplares(doc.ISBN);

                    foreach (Ejemplar ej in ejemplaresLibro)
                    {
                        DatosEjemplar fila = new DatosEjemplar();
                        fila.Titulo = doc.Titulo;
                        fila.Isbn = doc.ISBN;
                        fila.Codigo = ej.Codigo;
                        fila.Estado = ej.Estado.ToString();
                        fila.Usuario = personal.IdPersonal;
                        listaParaMostrar.Add(fila);
                    }
                }
            }
            CargarDatos(listaParaMostrar);
        }

        public class DatosEjemplar
        {
            public string Titulo { get; set; }
            public string Usuario { get; set; }
            public string Isbn { get; set; }
            public string Codigo { get; set; }
            public string Estado { get; set; }
        }
    }
}
