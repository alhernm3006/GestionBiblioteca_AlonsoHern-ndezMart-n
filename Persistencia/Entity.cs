using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class Entity<T>
    {
        private T id;

        // PRE: 'id' no debe ser nulo .
        // POS: Crea una nueva instancia de la clase base Entity.
        public Entity (T id)
        {
            this.id = id;
        }

        public T Id
        {
            // POS: Devuelve el identificador asociado a la entidad.
            get { return this.id; }
        }
    }
}
