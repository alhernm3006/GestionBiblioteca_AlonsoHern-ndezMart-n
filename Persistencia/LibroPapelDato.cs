using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class LibroPapelDato : Entity<String>
    {
        public LibroPapelDato(String isbn) : base(isbn)
        {
        }

    }
}
