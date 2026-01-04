using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public abstract class PersonalBiblioteca
    {
        private String idPersonal;
        private String nombre;
        private String contraseña;

        public PersonalBiblioteca(String id, String nombre, String contraseña)
        {
            this.idPersonal = id;
            this.nombre = nombre;
            this.contraseña = contraseña;
        }
        public String IdUsuario { get { return idPersonal; } }
        public String Nombre { get { return nombre; } }
        public String Contraseña { get { return contraseña; } }

    }
}
