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
