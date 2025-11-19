using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class PersonaSala : PersonalBiblioteca
    {
        public PersonaSala(string nss, string nombre) : base(nss, nombre){}
    }
}
