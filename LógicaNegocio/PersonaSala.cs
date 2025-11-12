using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LógicaNegocio
{
    public class PersonaSala : PersonalBiblioteca
    {
        //añadir parámetros

        public PersonaSala(string nss, string nombre) : base(nss, nombre)
        {
       
        }

        public void realizarPrestamo() { }
        public void consultarPrestamo() { }
        public void devolverEjemplar() { }
        public void obtenerPrestamos() { }

        public void obtenerPrestamosVencidos() { }

        public void ejemplaresNoDevueltos() { }
        public void consultarEstadoPrestamo() { }


    }
}
