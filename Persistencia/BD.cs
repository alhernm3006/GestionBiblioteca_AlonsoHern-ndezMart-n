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

        public static Tabla<ClaveEjemplar> TablaEjemplares
        {
            get
            {
                // CORREGIDO: Antes comprobaba tablaAudioLibros
                if (tablaEjemplares == null)
                {
                    // CORREGIDO: Antes inicializaba tablaAudioLibros y con Tabla<String>
                    tablaEjemplares = new Tabla<ClaveEjemplar>();
                }
                return tablaEjemplares;
            }
        }

        public static Tabla<ClavePrestamoEjemplar> TablaPrestamosEjemplares
        {
            get
            {
                // CORREGIDO: Antes comprobaba tablaAudioLibros
                if (tablaPrestamosEjemplares == null)
                {
                    // CORREGIDO: Antes inicializaba tablaAudioLibros y con Tabla<String>
                    tablaPrestamosEjemplares = new Tabla<ClavePrestamoEjemplar>();
                }
                return tablaPrestamosEjemplares;
            }
        }
    }
}
