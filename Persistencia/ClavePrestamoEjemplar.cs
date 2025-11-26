using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class ClavePrestamoEjemplar: IEquatable<ClavePrestamoEjemplar>
    {
        private String id;
        private ClaveEjemplar ejemplar;

        public ClavePrestamoEjemplar(String id, ClaveEjemplar ejemplar)
        {
            this.id = id;
            this.ejemplar = ejemplar;
        }
        public String Id
        {
            get { return id; }
        }

        public ClaveEjemplar Ejemplar
        {
            get { return ejemplar; }
        }

        public bool Equals(ClavePrestamoEjemplar clave)
        {
            if (clave is null) return false;

            return id.Equals(clave.id) &&
                   ejemplar.Equals(clave.ejemplar);
        }

        public override int GetHashCode()
        {
            return (id.GetHashCode() + ejemplar.GetHashCode());
        }
    }
}
