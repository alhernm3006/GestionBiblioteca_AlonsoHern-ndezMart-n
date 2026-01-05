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
    public partial class ListadoPrestamo : Presentación.ListadoBase
    {
        private LógicaNegocio.PersonalSala personal;

        //PRE:  personal es un PersonalSala valido.
        //POS:  Se inicializa el formulario
        public ListadoPrestamo(LógicaNegocio.PersonalSala personal)
        {
            InitializeComponent();
            this.personal = personal;
            this.Text = "Listado de Préstamos";
        }


        //PRE:  Se carga el listado de prestamos
        //POS:  Se obtienen todos los prestamos. A partir de esos prestamos se almacenan sus datos en un objeto de tipo DatosPrestamo. Esos objetos se almacenan en una lista. Se llama a CargarDatos() con esa lista.
        private void ListadoPrestamo_Load(object sender, EventArgs e)
        {
            List<DatosPrestamo> listaParaMostrar = new List<DatosPrestamo>();
            List<Prestamo> listaOriginal = personal.obtenerPrestamos();

            foreach (Prestamo p in listaOriginal)
            {
                DatosPrestamo fila = new DatosPrestamo();
                fila.ID = p.ID;

                if (p.Usuario != null)
                {
                    fila.Usuario = p.Usuario.Nombre + " (" + p.Usuario.DNI + ")";
                }
                else
                {
                    fila.Usuario = "Desconocido";
                }

                fila.FechaInicio = p.FechaInicio.ToShortDateString();
                fila.FechaFin = p.FechaFin.ToShortDateString();
                fila.Estado = p.Estado.ToString();
                fila.CantidadEjemplares = p.Ejemplares != null ? p.Ejemplares.Count : 0;
                listaParaMostrar.Add(fila);
            }
            CargarDatos(listaParaMostrar);
        }
        public class DatosPrestamo
        {
            public string ID { get; set; }
            public string Usuario { get; set; }
            public string FechaInicio { get; set; }
            public string FechaFin { get; set; }
            public string Estado { get; set; }
            public int CantidadEjemplares { get; set; }
        }
    }


}
