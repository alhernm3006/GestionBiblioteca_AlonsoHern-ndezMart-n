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

        public PersonalBibliotecaDato(String id, String nombre, String contraseña, String rol) : base(id)
        {
            this.contraseña = contraseña;
            this.idPersonal = id;
            this.rol = rol;
        }

        public String IdPersonal
        {
            get { return idPersonal; }
        }
        public String Nombre
        {
            get { return nombre; }
        }
        public String Rol
        {
            get { return rol; }
        }
        public String Contraseña
        {
            get { return contraseña; }
        }
    }
}
