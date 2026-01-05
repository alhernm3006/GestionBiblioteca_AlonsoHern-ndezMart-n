using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class Tabla<T>: KeyedCollection<T,Entity<T>>
    {

        // PRE: El objeto 't' (la entidad) no debe ser nulo.
        // POS: Devuelve la clave única asociada a la entidad 't'.
        protected override T GetKeyForItem(Entity<T> t)
        {
            return t.Id;
        }
    }
}
