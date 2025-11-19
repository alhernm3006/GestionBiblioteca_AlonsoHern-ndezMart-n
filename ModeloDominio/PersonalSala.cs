using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class PersonalSala : PersonalBiblioteca
    {
        public PersonalSala(string nss, string nombre) : base(nss, nombre){}
    }
}
