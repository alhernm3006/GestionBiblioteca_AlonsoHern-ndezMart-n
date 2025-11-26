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
        protected override T GetKeyForItem(Entity<T> t)
        {
            return t.Id;
        }
    }
}
