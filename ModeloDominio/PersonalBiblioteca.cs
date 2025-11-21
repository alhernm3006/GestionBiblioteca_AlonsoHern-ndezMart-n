using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public abstract class PersonalBiblioteca
    {
        private String nss;
        private String usuario;
        
        public PersonalBiblioteca(String nss, String usuario) {
            this.nss = nss;
            this.usuario = usuario;
        }
        public String NSS{ get { return nss; } }

        public String Usuario { get { return usuario; } }

    }
}
