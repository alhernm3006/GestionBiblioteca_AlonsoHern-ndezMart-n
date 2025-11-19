using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public abstract class PersonalBiblioteca
    {
        private String NSS;
        private String usuario;
        
        public PersonalBiblioteca(String nss, String usuario) {
            this.NSS = nss;
            this.usuario = usuario;
        }
        public String getNSS() {  return NSS; }

        public String getUSUario() { return usuario; }

    }

    // para préstamo public enum estado { Prestado=0,Disponible=1}
}
