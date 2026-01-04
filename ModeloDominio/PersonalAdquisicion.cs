using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class PersonalAdquisicion : PersonalBiblioteca
    {
        public PersonalAdquisicion(string idPersonal, string nombre, string contraseña) : base(idPersonal, nombre, contraseña) { }
    }
}
