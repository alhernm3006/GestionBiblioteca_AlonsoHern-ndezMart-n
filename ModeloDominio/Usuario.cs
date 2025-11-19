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

        private String DNI;
        private String nombre;
        private EstadoActivoInactivo estado;

        public Usuario(String DNI, String nombre, EstadoActivoInactivo estado)
        {
            this.DNI = DNI;
            this.nombre = nombre;
            this.estado = estado;
        }

        public String getDNI() {  return DNI; }
        public String getNombre() { return nombre; }
        public EstadoActivoInactivo getEstadoActivoInactivo() { return estado; }
        public void setEstado(EstadoActivoInactivo estado){ this.estado = estado; }
        public String toString()
        {
            return ("El DNI del usuario es: " + this.getDNI() + ", su nombre es: " + this.getNombre() + " y su estado es: " + this.getEstadoActivoInactivo());
        }
    }
}
