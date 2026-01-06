using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class Prestamo
    {

        private String id;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private EstadoPrestamo estado;
        private Usuario usuario;
        private PersonalSala trabajador;
        private List<Ejemplar> ejemplares;

        // PRE: ID, usuario, trabajador y la lista de ejemplares no deben ser nulos. fechaFin debe ser posterior a fechaInicio.
        //      La lista 'ejemplares' debe contener al menos un elemento.
        // POS Se crea una instancia de Prestamo.
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

        // PRE: el préstamo tiene que ser inicializada previamente
        // POS: devuelve el id del préstamo
        public String ID { get { return id; } }

        // PRE: el préstamo tiene que ser inicializada previamente
        // POS: devuelve la fecha de inicio del préstamo
        public DateTime FechaInicio { get { return fechaInicio; } }

        // PRE: el préstamo tiene que ser inicializada previamente
        // POS: devuelve la fecha de fin del préstamo
        public DateTime FechaFin { get { return fechaFin; } }

        // PRE: el préstamo tiene que ser inicializada previamente
        public EstadoPrestamo Estado {
            // POS: devuelve estado del préstamo
            get { return estado; }
            //POS: establece el valor del estado pasado al préstamo
            set { this.estado = value; } }

        // PRE: el préstamo tiene que ser inicializada previamente
        // POS: devuelve el usuario del préstamo
        public Usuario Usuario { get { return usuario; } }

        // PRE: el préstamo tiene que ser inicializada previamente
        // POS: devuelve personal de sala que ha realizado el préstamo
        public PersonalSala PersonalSala { get { return trabajador; } }

        // PRE: el préstamo tiene que ser inicializada previamente
        // POS: devuelve la lista de ejemplares del préstamo
        public List<Ejemplar> Ejemplares { get { return ejemplares; } }
    }
}
