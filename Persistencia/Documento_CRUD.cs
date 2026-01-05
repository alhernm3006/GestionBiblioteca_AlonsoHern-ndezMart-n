using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class Documento_CRUD
    {
        // PRE: 'isbn' no debe ser nulo.
        // POS: Devuelve el objeto Documento si existe en la base de datos y su estado es distinto de "inactivo".
        //      Devuelve null si no existe o si está marcado como inactivo.
        public Documento Buscar(string isbn)
        {
            if (BD.TablaDocumentos.Contains(isbn))
            {
                DocumentoDato dato = (DocumentoDato)BD.TablaDocumentos[isbn];

                if (dato.Estado != "inactivo")
                {
                    return Transformer.DocumentoDatoADocumento(dato);
                }
            }
            return null;
        }

        // PRE: 'textoTitulo' no debe ser nulo .
        // POS: Devuelve una lista de documentos cuyo título contiene la cadena 'textoTitulo' .
        //      La búsqueda incluye documentos activos e inactivos. Devuelve una lista vacía si no hay coincidencias.
        public List<Documento> BuscarPorTitulo(string textoTitulo)
        {
            List<Documento> resultados = new List<Documento>();

            foreach (var item in BD.TablaDocumentos)
            {
                DocumentoDato docDato = (DocumentoDato)item;

                if (docDato.Titulo.ToLower().Contains(textoTitulo.ToLower()))
                {

                    Documento doc = Transformer.DocumentoDatoADocumento(docDato);
                    resultados.Add(doc);
                }
            }
            return resultados;
        }

        // PRE: 'isbn' no debe ser nulo.
        // POS: Devuelve true si encuentra el documento y cambia su estado a "inactivo".
        //      Devuelve false si el documento no existe en la base de datos.
        public bool Eliminar(string isbn)
        {
            if (BD.TablaDocumentos.Contains(isbn))
            {
                DocumentoDato dato = (DocumentoDato)BD.TablaDocumentos[isbn];
                dato.Estado = "inactivo";
                return true;
            }
            return false;
        }

        // PRE: 
        // POS: Devuelve una lista con todos los documentos registrados en el sistema.
        public List<Documento> ListarTodos()
        {
            List<Documento> lista = new List<Documento>();

            foreach (var item in BD.TablaDocumentos)
            {
                DocumentoDato dato = (DocumentoDato)item;
                lista.Add(Transformer.DocumentoDatoADocumento(dato));
            }
            return lista;
        }
    }
}
