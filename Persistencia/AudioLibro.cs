using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class AudioLibro : Entity<String>
    {
        private string formato;
        private float duracion;

        public AudioLibro(String isbn, String formato, float duracion) : base(isbn)
        {
            this.formato = formato;
            this.duracion = duracion;
        }
    }
}
