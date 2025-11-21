using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class PersonalBibliotecaDato: Entity<String>
    {
        private String nss;
        private Type rol;

        public PersonalBibliotecaDato (String nss, String usuario, Type rol): base(usuario)
        {
            this.nss = nss;
            this.rol = rol;
        }

    }
}
