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
        public void Insertar(LibroPapel libro)
        {
            if (BD.TablaDocumentos.Contains(libro.ISBN))
                throw new Exception("Ya existe un documento con ese ISBN.");

            // Guardar en las dos tablas necesarias
            BD.TablaDocumentos.Add(Transformer.DocumentoADocumentoDato(libro));
            BD.TablaLibrosPapel.Add(Transformer.LibroPapelALibroPapelDato(libro));
        }

        public LibroPapel Buscar(string isbn)
        {
            if (BD.TablaLibrosPapel.Contains(isbn))
            {
                // El Transformer interno ya se encarga de buscar en TablaDocumentos
                LibroPapelDato datoEspecifico = (LibroPapelDato)BD.TablaLibrosPapel[isbn];
                return Transformer.LibroPapelDatoALibroPapel(datoEspecifico);
            }
            return null;
        }

        public void Eliminar(string isbn)
        {
            if (BD.TablaLibrosPapel.Contains(isbn))
            {
                BD.TablaLibrosPapel.Remove(isbn);
                BD.TablaDocumentos.Remove(isbn);
            }
        }
    }
}
