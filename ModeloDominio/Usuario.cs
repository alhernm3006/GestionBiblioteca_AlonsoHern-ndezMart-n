using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class Usuario
    {

        private String dni;
        private String nombre;
        private EstadoActivoInactivo estado;

        // PRE: DNI y nombre no deben ser nulos ni estar vacíos.
        // POS: Se crea una instancia de Usuario
        public Usuario(String DNI, String nombre)
        {
            this.dni = DNI;
            this.nombre = nombre;
            this.estado = EstadoActivoInactivo.inactivo;
        }

        // PRE: usuario tiene que ser inicializada previamente
        // POS: devuelve el dni del usuario
        public String DNI {  get{ return dni; } }

        // PRE: usuario tiene que ser inicializada previamente
        // POS: devuelve el nombre del usuario
        public String Nombre { get { return nombre; } }

        // PRE: usuario tiene que ser inicializada previamente
        public EstadoActivoInactivo Estado {
            // POS: devuelve el estado del usuario
            get { return estado; }
            //POS: establece el valor del estado pasado al usuario
            set { this.estado = value; }}

        // PRE: usuario tiene que ser inicializada previamente
        // POS: devuelve la representación en cadena de caracteres del usuario
        public String toString()
        {
            return ("El DNI del usuario es: " + this.DNI + ", su nombre es: " + this.Nombre + " y su estado es: " + this.Estado);
        }
    }
}
