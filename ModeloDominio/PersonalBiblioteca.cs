using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public abstract class PersonalBiblioteca
    {
        private String idUsuario;
        private String contraseña;
        
        public PersonalBiblioteca(String id, String contraseña) {
            this.idUsuario = id;
            this.contraseña = contraseña;
        }
        public String IdUsuario{ get { return idUsuario; } }

        public String Contraseña { get { return contraseña; } }

    }
}
