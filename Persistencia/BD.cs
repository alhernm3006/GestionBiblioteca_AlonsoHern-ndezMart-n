using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal static class BD
    {
        private static Tabla<String> tablaUsuarios;
        private static Tabla<String> tablaPrestamos;
        private static Tabla<String> tablaPersonal;
        private static Tabla<String> tablaDocumentos;
        private static Tabla<ClaveEjemplar> tablaEjemplares;
        private static Tabla<String> tablaLibrosPapel;
        private static Tabla<String> tablaAudioLibros;
        private static Tabla<ClavePrestamoEjemplar> tablaPrestamosEjemplares;

        // PRE: 
        // POS: Devuelve la  tabla de Usuarios. Si es null, la inicializa antes de devolverla vacía.
        public static Tabla<String> TablaUsuarios
        {
            get
            {
                if (tablaUsuarios == null)
                {
                    tablaUsuarios = new Tabla<String>();
                }
                return tablaUsuarios;
            }
        }

        // PRE: 
        // POS: Devuelve la  tabla de Prestamos. Si es null, la inicializa antes de devolverla vacía.
        public static Tabla<String> TablaPrestamos
        {
            get
            {
                if (tablaPrestamos == null)
                {
                    tablaPrestamos = new Tabla<String>();
                }
                return tablaPrestamos;
            }
        }

        // PRE: 
        // POS: Devuelve la  tabla de Personal. Si es null, la inicializa antes de devolverla vacía.
        public static Tabla<String> TablaPersonal
        {
            get
            {
                if (tablaPersonal == null)
                {
                    tablaPersonal = new Tabla<String>();
                }
                return tablaPersonal;
            }
        }

        // PRE: 
        // POS: Devuelve la  tabla deDocumentos. Si es null, la inicializa antes de devolverla vacía.
        public static Tabla<String> TablaDocumentos
        {
            get
            {
                if (tablaDocumentos == null)
                {
                    tablaDocumentos = new Tabla<String>();
                }
                return tablaDocumentos;
            }
        }

        // PRE: 
        // POS: Devuelve la  tabla de Libros en papel. Si es null, la inicializa antes de devolverla vacía.
        public static Tabla<String> TablaLibrosPapel
        {
            get
            {
                if (tablaLibrosPapel == null)
                {
                    tablaLibrosPapel = new Tabla<String>();
                }
                return tablaLibrosPapel;
            }
        }

        // PRE: 
        // POS: Devuelve la  tabla de AudioLibros. Si es null, la inicializa antes de devolverla vacía.
        public static Tabla<String> TablaAudioLibros
        {
            get
            {
                if (tablaAudioLibros == null)
                {
                    tablaAudioLibros = new Tabla<String>();
                }
                return tablaAudioLibros;
            }
        }

        // PRE: 
        // POS: Devuelve la  tabla de Ejemplares. Si es null, la inicializa antes de devolverla vacía.
        public static Tabla<ClaveEjemplar> TablaEjemplares
        {
            get
            {
                if (tablaEjemplares == null)
                {
                    tablaEjemplares = new Tabla<ClaveEjemplar>();
                }
                return tablaEjemplares;
            }
        }

        // PRE: 
        // POS: Devuelve la  tabla de Prestamos. Si es null, la inicializa antes de devolverla vacía.
        public static Tabla<ClavePrestamoEjemplar> TablaPrestamosEjemplares
        {
            get
            {
                if (tablaPrestamosEjemplares == null)
                {
                    tablaPrestamosEjemplares = new Tabla<ClavePrestamoEjemplar>();
                }
                return tablaPrestamosEjemplares;
            }
        }
    }
}
