using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    internal class Usuario
    {

        private String dni;
        private String nombre;
        private EstadoActivoInactivo estado;

        public Usuario(String DNI, String nombre, EstadoActivoInactivo estado)
        {
            this.dni = DNI;
            this.nombre = nombre;
            this.estado = estado;
        }

        public String DNI {  get{ return dni; } }
        public String Nombre { get { return nombre; } }
        public EstadoActivoInactivo Estado { get { return estado; } set { this.estado = value; }}
        public String toString()
        {
            return ("El DNI del usuario es: " + this.DNI + ", su nombre es: " + this.Nombre + " y su estado es: " + this.Estado);
        }
    }
}
