using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class PersonalSala : PersonalBiblioteca
    {
        // PRE: idPersonal, nombre y contraseña no deben ser nulos ni estar vacíos.
        // POS: se crea una instancia de PersonalSala.
        public PersonalSala(string idPersonal, string nombre, string contraseña) : base(idPersonal, nombre, contraseña) { }
    }
}
