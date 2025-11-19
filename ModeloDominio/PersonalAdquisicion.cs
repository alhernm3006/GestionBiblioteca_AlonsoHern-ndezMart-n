using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class PersonalAdquisicion : PersonalBiblioteca
    {
        public PersonalAdquisicion(String nss, String usuario): base(nss, usuario){}
    }
}
