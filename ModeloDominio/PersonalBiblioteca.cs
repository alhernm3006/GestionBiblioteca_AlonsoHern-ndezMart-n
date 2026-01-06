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

        // PRE: id, nombre y contraseña no deben ser nulos ni estar vacíos.
        // POS: Inicializa los atributos de personalBiblioteca.
        public PersonalBiblioteca(String id, String nombre, String contraseña)
        {
            this.idPersonal = id;
            this.nombre = nombre;
            this.contraseña = contraseña;
        }

        // PRE: personalBiblioteca tiene que ser inicializada previamente
        // POS: devuelve el id del personal
        public String IdPersonal { get { return idPersonal; } }

        // PRE: personalBiblioteca tiene que ser inicializada previamente
        // POS: devuelve el nombre del personal
        public String Nombre { get { return nombre; } }

        // PRE: personalBiblioteca tiene que ser inicializada previamente
        // POS: devuelve la contraseña del personal
        public String Contraseña { get { return contraseña; } }

    }
}
