using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class LibroPapelDato : Entity<String>
    {
        // PRE: 'isbn' no debe ser nulo ni una cadena vacía.
        // POS: Crea una nueva instancia de LibroPapelDato.
        public LibroPapelDato(String isbn) : base(isbn)
        {
        }

    }
}
