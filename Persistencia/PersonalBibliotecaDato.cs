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
        private String contraseña;
        private String rol;

        public PersonalBibliotecaDato ( String usuario,String contraseña, String rol): base(usuario)
        {
            this.contraseña = contraseña;
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

        public String Contraseña
        {
            get { return contraseña; }
        }
    }
}
