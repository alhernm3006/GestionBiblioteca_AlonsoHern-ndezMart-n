using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    internal class Prestamo
    {

        private String id;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private EstadoPrestamo estado;
        private Usuario usuario;
        private PersonalSala trabajador;
        private List<Ejemplar> ejemplares;

        public Prestamo(string ID, DateTime fechaInicio, DateTime fechaFin,
                    EstadoPrestamo estado, Usuario usuario,
                    PersonalSala trabajador, List<Ejemplar> ejemplares)
        {
            this.id = ID;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.estado = estado;
            this.usuario = usuario;
            this.trabajador = trabajador;
            this.ejemplares = new List<Ejemplar>(ejemplares);
        }

        public String ID { get { return id; } }
        public DateTime FechaInicio { get { return fechaInicio; } }
        public DateTime FechaFin { get { return fechaFin; } }
        public EstadoPrestamo Estado { get { return estado; } set { this.estado = value; } }
        public Usuario Usuario { get { return usuario; } }
        public PersonalSala PersonalSala { get { return trabajador; } }
        public List<Ejemplar> Ejemplares { get { return ejemplares; } }
    }
}
