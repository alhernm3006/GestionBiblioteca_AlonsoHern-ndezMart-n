using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class PersonalAdquisicion : PersonalBiblioteca
    {
        // PRE: idPersonal, nombre y contraseña no deben ser nulos ni estar vacíos.
        // POS: crea una instancia de PersonalAdquisicion.
        public PersonalAdquisicion(string idPersonal, string nombre, string contraseña) : base(idPersonal, nombre, contraseña) { }
    }
}
