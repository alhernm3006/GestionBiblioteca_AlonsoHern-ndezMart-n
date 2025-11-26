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
    
        public ClaveEjemplar(String isbn, String codigo)
        {
            this.isbn = isbn;
            this.codigo = codigo;   
        }
        public String ISBN
        {
            get { return isbn; }
        }

        public String Codigo
        {
            get { return codigo; }
        }

        public bool Equals(ClaveEjemplar clave)
        {
            if(clave is null) return false;

            return isbn.Equals(clave.ISBN) &&
                   codigo.Equals(clave.Codigo);
        }

        public override int GetHashCode()
        {
            int hashIsbn = isbn.GetHashCode();
            int hashCodigo = codigo.GetHashCode();
            return (hashIsbn+hashCodigo);
        }
    }

}
