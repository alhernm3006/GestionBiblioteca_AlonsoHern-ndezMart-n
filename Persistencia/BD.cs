using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal static class BD
    {
        private static Tabla<String, UsuarioDato> tablaUsuarios;
        private static Tabla<String, PrestamoDato> tablaPrestamos;
        private static Tabla<String, PersonalBibliotecaDato> tablaPersonal;
        private static Tabla<String, DocumentoDato> tablaDocumentos;
        //private static Tabla<?, EjemplarDato> tablaEjemplares;
        private static Tabla<String, LibroPapelDato> tablaLibrosPapel;
        private static Tabla<String, AudioLibroDato> tablaAudioLibros;
        //private static Tabla<?, Prestamo_EjemplarDato> tablaPrestamosEjemplares;

        public static Tabla<String, UsuarioDato> TablaUsuarios
        {
            get
            {
                if (tablaUsuarios == null)
                {
                    tablaUsuarios = new Tabla<String, UsuarioDato>();
                }
                return tablaUsuarios;
            }

        }

        public static Tabla<String, PrestamoDato> TablaPrestamos
        {
            get
            {
                if (tablaPrestamos == null)
                {
                    tablaPrestamos = new Tabla<String, PrestamoDato>();
                }
                return tablaPrestamos;
            }

        }

        public static Tabla<String, PersonalBibliotecaDato> TablaPersonal
        {
            get
            {
                if (tablaPersonal == null)
                {
                    tablaPersonal = new Tabla<String, PersonalBibliotecaDato>();
                }
                return tablaPersonal;
            }

        }

        public static Tabla<String, DocumentoDato> TablaDocumentos
        {
            get
            {
                if (tablaDocumentos == null)
                {
                    tablaDocumentos = new Tabla<String, DocumentoDato>();
                }
                return tablaDocumentos;
            }

        }

        public static Tabla<String, LibroPapelDato> TablaLibrosPapel
        {
            get
            {
                if (tablaLibrosPapel == null)
                {
                    tablaLibrosPapel = new Tabla<String, LibroPapelDato>();
                }
                return tablaLibrosPapel;
            }

        }

        public static Tabla<String, AudioLibroDato> TablaAudioLibros
        {
            get
            {
                if (tablaAudioLibros == null)
                {
                    tablaAudioLibros = new Tabla<String, AudioLibroDato>();
                }
                return tablaAudioLibros;
            }
        }
    }
}
