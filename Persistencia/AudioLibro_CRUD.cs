using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class AudioLibro_CRUD
    {
        public void Insertar(AudioLibro audio)
        {
            if (BD.TablaDocumentos.Contains(audio.ISBN))
                throw new Exception("Ya existe un documento con ese ISBN.");

            BD.TablaDocumentos.Add(Transformer.DocumentoADocumentoDato(audio));
            BD.TablaAudioLibros.Add(Transformer.AudioLibroAAudioLibroDato(audio));
        }

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
