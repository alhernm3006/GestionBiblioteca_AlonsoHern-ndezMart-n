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

        public AudioLibroDato(String isbn, String formato, float duracion) : base(isbn)
        {
            this.formato = formato;
            this.duracion = duracion;
        }

        public string Formato
        {
            get { return formato; }
            set { formato = value; }
        }

        public float Duracion
        {
            get { return duracion; }
            set { duracion = value; }
        }
    }
}