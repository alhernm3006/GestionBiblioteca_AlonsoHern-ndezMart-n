using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LógicaNegocio
{
    public abstract class PersonalBiblioteca
    {
        private String NSS;
        private String nombre;
        
        public PersonalBiblioteca(String nss,String nombre) {
            this.NSS = nss;
            this.nombre = nombre;
        }
        public String getNss() {  return NSS; }

    }

    // para préstamo public enum estado { Prestado=0,Disponible=1}
}
