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
