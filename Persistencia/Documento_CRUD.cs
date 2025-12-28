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
        public Documento Buscar(string isbn)
        {
            if (BD.TablaDocumentos.Contains(isbn))
            {
                DocumentoDato dato = (DocumentoDato)BD.TablaDocumentos[isbn];

                return Transformer.DocumentoDatoADocumento(dato);
            }
            return null;
        }


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


        public void Eliminar(string isbn)
        {
            if (!BD.TablaDocumentos.Contains(isbn))
            {
                throw new Exception("El documento no existe.");
            }


            if (BD.TablaLibrosPapel.Contains(isbn))
            {
                BD.TablaLibrosPapel.Remove(isbn);
            }
            else if (BD.TablaAudioLibros.Contains(isbn))
            {
                BD.TablaAudioLibros.Remove(isbn);
            }


            BD.TablaDocumentos.Remove(isbn);
        }
        public List<Documento> ListarTodos()
        {
            List<Documento> lista = new List<Documento>();

            // Iteramos sobre la tabla interna (BD solo visible en este proyecto)
            foreach (var item in BD.TablaDocumentos)
            {
                DocumentoDato dato = (DocumentoDato)item;
                // Transformamos el dato persistente al objeto de dominio
                lista.Add(Transformer.DocumentoDatoADocumento(dato));
            }

            return lista;
        }

        
    }
}
