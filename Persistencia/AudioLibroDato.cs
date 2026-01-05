using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class AudioLibroDato : Entity<String>
    {
        private string formato;
        private float duracion;


        // PRE: 'isbn' debe ser string. 'formato' debe ser string. 'duracion' debe ser string.
        // POS: Crea una nueva instancia de AudioLibroDato con identificador "ISBN", formato y duración.
        public AudioLibroDato(String isbn, String formato, float duracion) : base(isbn)
        {
            this.formato = formato;
            this.duracion = duracion;
        }

        public string Formato
        {
            // POS: Devuelve el formato del audiolibro.
            get { return formato; }

            // POS: Asigna un nuevo valor al formato del audiolibro.
            set { formato = value; }
        }

        public float Duracion
        {
            // POS: Devuelve la duración del audiolibro.
            get { return duracion; }
            // POS: Asigna un nuevo valor a la duración del audiolibro.
            set { duracion = value; }
        }
    }
}