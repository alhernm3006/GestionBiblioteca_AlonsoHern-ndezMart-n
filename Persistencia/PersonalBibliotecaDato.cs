using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class PersonalBibliotecaDato : Entity<String>
    {
        private String idPersonal;
        private String nombre;
        private String contraseña;
        private String rol;

        // PRE: 'id' no debe ser nulo. 'nombre', 'contraseña' y 'rol' no deben ser nulos.
        // POS: Crea PersonalBibliotecaDato.
        public PersonalBibliotecaDato(String id, String nombre, String contraseña, String rol) : base(id)
        {
            this.contraseña = contraseña;
            this.idPersonal = id;
            this.rol = rol;
        }

        public String IdPersonal
        {
            // POS: Devuelve el identificador del personal.
            get { return idPersonal; }
        }
        public String Nombre
        {
            // POS: Devuelve el nombre del personal.
            get { return nombre; }
        }
        public String Rol
        {
            // POS: Devuelve el rol asignado al personal.
            get { return rol; }
        }
        public String Contraseña
        {
            // POS: Devuelve la contraseña del personal.
            get { return contraseña; }
        }
    }
}
