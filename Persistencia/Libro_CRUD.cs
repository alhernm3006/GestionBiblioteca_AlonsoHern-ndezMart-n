using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class Libro_CRUD
    {
        // PRE: El objeto 'libro' no debe ser nulo.
        // POS: Devuelve true si el libro se inserta correctamente en la base de datos.
        //      Devuelve false si ya existe un documento con el mismo ISBN en la base de datos.
        public bool Insertar(LibroPapel libro)
        {
            if (!BD.TablaDocumentos.Contains(libro.ISBN))
            {
                BD.TablaDocumentos.Add(Transformer.DocumentoADocumentoDato(libro));
                BD.TablaLibrosPapel.Add(Transformer.LibroPapelALibroPapelDato(libro));
                return true;
            }
            return false;
        }

        // PRE: 'isbn' no debe ser nulo.
        // POS: Devuelve el objeto LibroPapel correspondiente al ISBN si existe en la tabla específica de libros en papel.
        //      Devuelve null si no se encuentra ningún libro en papel con ese ISBN.
        public LibroPapel Buscar(string isbn)
        {
            if (BD.TablaLibrosPapel.Contains(isbn))
            {
                LibroPapelDato datoEspecifico = (LibroPapelDato)BD.TablaLibrosPapel[isbn];
                return Transformer.LibroPapelDatoALibroPapel(datoEspecifico);
            }
            return null;
        }
    }
}
