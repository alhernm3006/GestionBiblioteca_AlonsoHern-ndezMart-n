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

        // PRE: 'id' y 'ejemplar' no deben ser nulos.
        // POS: Crea una nueva instancia de la clave compuesta por id y ejemplar.
        public ClavePrestamoEjemplar(String id, ClaveEjemplar ejemplar)
        {
            this.id = id;
            this.ejemplar = ejemplar;
        }
        public String Id
        // POS: Devuelve el identificador del préstamo asociado a esta clave.
        {
            get { return id; }
        }

        public ClaveEjemplar Ejemplar
        {
            // POS: Devuelve la clave del ejemplar asociado.
            get { return ejemplar; }
        }

        // PRE: 
        // POS: Devuelve true si 'clave' no es nulo y coinciden tanto el ID del préstamo como la clave del ejemplar.
        public bool Equals(ClavePrestamoEjemplar clave)
        {
            if (clave is null) return false;

            return id.Equals(clave.id) &&
                   ejemplar.Equals(clave.ejemplar);
        }

        // PRE: 
        // POS: Devuelve un código hash calculado a partir de la suma de los hashes del ID y del ejemplar.
        public override int GetHashCode()
        {
            return (id.GetHashCode() + ejemplar.GetHashCode());
        }
    }
}
