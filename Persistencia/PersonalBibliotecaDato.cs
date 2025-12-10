using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class PersonalBibliotecaDato: Entity<String>
    {
        private String usuario;
        private String rol;

        public PersonalBibliotecaDato (String nss, String usuario, String rol): base(usuario)
        {
            this.usuario = usuario;
            this.rol = rol;
        }

        public String Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public String Rol
        {
            get { return rol; }
            set { rol = value; }
        }
    }
}
