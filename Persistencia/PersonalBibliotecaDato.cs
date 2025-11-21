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
        private String rol;

        public PersonalBibliotecaDato (String nss, String usuario, String rol): base(usuario)
        {
            this.nss = nss;
            this.rol = rol;
        }

    }
}
