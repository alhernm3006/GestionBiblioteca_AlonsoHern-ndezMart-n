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
        public ListadoPrestamo(LógicaNegocio.PersonalSala personal)
        {
            InitializeComponent();
            this.personal = personal;
        }

        private void ListadoPrestamo_Load(object sender, EventArgs e)
        {
            List<DatosPrestamo> listaParaMostrar = new List<DatosPrestamo>();

            // 1. Obtenemos la lista de objetos de dominio (Préstamos)
            // Se asume que PersonalSala tiene el método obtenerPrestamos()
            List<Prestamo> listaOriginal = personal.obtenerPrestamos();

            // 2. Recorremos y transformamos a la clase visual (DTO)
            foreach (Prestamo p in listaOriginal)
            {
                DatosPrestamo fila = new DatosPrestamo();

                fila.ID = p.ID;

                // Formateamos el usuario para mostrar Nombre y DNI
                if (p.Usuario != null)
                {
                    fila.Usuario = p.Usuario.Nombre + " (" + p.Usuario.DNI + ")";
                }
                else
                {
                    fila.Usuario = "Desconocido";
                }

                // Formateamos las fechas para que se vean cortas (sin hora)
                fila.FechaInicio = p.FechaInicio.ToShortDateString();
                fila.FechaFin = p.FechaFin.ToShortDateString();

                fila.Estado = p.Estado.ToString();

                // Mostramos cuántos libros tiene este préstamo
                fila.CantidadEjemplares = p.Ejemplares != null ? p.Ejemplares.Count : 0;

                listaParaMostrar.Add(fila);
            }

            // 3. Cargamos los datos usando el método del padre (ListadoBase)
            CargarDatos(listaParaMostrar);

            // 4. Ajustes visuales
            this.Text = "Listado de Préstamos";
        }
        public class DatosPrestamo
        {
            public string ID { get; set; }
            public string Usuario { get; set; }
            public string FechaInicio { get; set; } // Nombre columna: FechaInicio
            public string FechaFin { get; set; }    // Nombre columna: FechaFin
            public string Estado { get; set; }
            public int CantidadEjemplares { get; set; }
        }
    }


}
