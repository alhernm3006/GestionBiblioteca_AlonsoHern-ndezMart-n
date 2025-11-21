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
        
    }
}
