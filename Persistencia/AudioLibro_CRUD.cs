using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class AudioLibro_CRUD
    {


        // PRE: El objeto 'audio' no debe ser nulo y de tipo AudioLibro.
        // POS: Devuelve true si el audiolibro se inserta correctamente en la base de datos .
        //      Devuelve false si ya existe un documento con el mismo ISBN en la base de datos, sin realizar cambios.
        public bool Insertar(AudioLibro audio)
        {
            if (!BD.TablaDocumentos.Contains(audio.ISBN))
            {
                BD.TablaDocumentos.Add(Transformer.DocumentoADocumentoDato(audio));
                BD.TablaAudioLibros.Add(Transformer.AudioLibroAAudioLibroDato(audio));
                return true;
            }
            return false;
        }


        // PRE: 'isbn' debe ser strin.
        // POS: Devuelve el objeto AudioLibro con ese ISBN si existe en la tabla de audiolibros.
        //      Devuelve null si no se encuentra ningún audiolibro con ese ISBN.
        
        public AudioLibro Buscar(string isbn)
        {
            if (BD.TablaAudioLibros.Contains(isbn))
            {
                AudioLibroDato dato = (AudioLibroDato)BD.TablaAudioLibros[isbn];
                return Transformer.AudioLibroDatoAAudioLibro(dato);
            }
            return null;
        }
    }
}
