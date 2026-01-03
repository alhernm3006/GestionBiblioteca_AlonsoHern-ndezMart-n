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
        public ListadoEjemplares(LógicaNegocio.PersonalAdquisicion personal)
        {
            InitializeComponent();
            this.personal = personal;
        }

        private void ListadoEjemplares_Load(object sender, EventArgs e)
        {
            List<DatosEjemplar> listaParaMostrar = new List<DatosEjemplar>();

            // 1. Obtenemos documentos
            List<Documento> misDocumentos = personal.obtenerDocumentos();

            // 2. Recorremos y extraemos datos
            foreach (Documento doc in misDocumentos)
            {
                if (doc.Estado == EstadoActivoInactivo.activo)
                {
                    List<Ejemplar> ejemplaresLibro = personal.obtenerEjemplares(doc.ISBN);

                    foreach (Ejemplar ej in ejemplaresLibro)
                    {
                        // CREAMOS EL OBJETO DE VISTA
                        DatosEjemplar fila = new DatosEjemplar();

                        // Rellenamos datos simples
                       
                        fila.Titulo = doc.Titulo; // ¡Ahora el título saldrá perfecto!


                        // Buscamos el USUARIO usando el método nuevo
                        fila.Codigo = ej.Codigo;
                        fila.Estado = ej.Estado.ToString();

                        fila.Usuario = personal.Nombre;
                        
                        
                        

                        listaParaMostrar.Add(fila);
                    }
                }
            }

            // 3. ¡Importante! Cargamos la lista NUEVA (listaParaMostrar)
            CargarDatos(listaParaMostrar);

            this.Text = "Listado de Ejemplares";
        }

        public class DatosEjemplar
        {
           
            public string Titulo { get; set; }  // Aquí mostraremos el nombre del libro
          
            public string Usuario { get; set; } // Aquí mostraremos el nombre del usuario

            public string Codigo { get; set; }
            public string Estado { get; set; }
        }
    }
}
