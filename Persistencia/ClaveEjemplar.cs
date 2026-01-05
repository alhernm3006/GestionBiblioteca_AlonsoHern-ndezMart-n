using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class ClaveEjemplar: IEquatable<ClaveEjemplar>
    {
        private String isbn;
        private String codigo;

        // PRE: 'isbn' y 'codigo' deben ser strings.
        // POS: Crea una nueva claveEjemplar compuesta por ISBN y código.
        public ClaveEjemplar(String isbn, String codigo)
        {
            this.isbn = isbn;
            this.codigo = codigo;   
        }
        public String ISBN
        {
            // POS: Devuelve el ISBN de la clave.
            get { return isbn; }
        }

        public String Codigo
        {
            // POS: Devuelve el código de la clave.
            get { return codigo; }
        }

        // PRE: Clave debe ser ClaveEjemplar
        // POS: Devuelve true si 'clave' tiene el mismo ISBN y código que this.
        public bool Equals(ClaveEjemplar clave)
        {
            if(clave is null) return false;

            return isbn.Equals(clave.ISBN) &&
                   codigo.Equals(clave.Codigo);
        }

        // PRE:
        // POS: Devuelve un código hash calculado sumando los códigos hash del ISBN y el código.
        public override int GetHashCode()
        {
            int hashIsbn = isbn.GetHashCode();
            int hashCodigo = codigo.GetHashCode();
            return (hashIsbn+hashCodigo);
        }
    }

}
