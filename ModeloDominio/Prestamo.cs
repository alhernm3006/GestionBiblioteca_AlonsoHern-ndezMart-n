using LógicaNegocio;
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

        private String ID;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private EstadoPrestamo estado;
        private Usuario usuario;
        private PersonalSala trabajador;
        private List<Ejemplar> ejemplar;

        public Prestamo(string ID, DateTime fechaInicio, DateTime fechaFin,
                    EstadoPrestamo estado, Usuario usuario,
                    PersonalSala trabajador, List<Ejemplar> ejemplar)
        {
            this.ID = ID;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.estado = estado;
            this.usuario = usuario;
            this.trabajador = trabajador;
            this.ejemplar =  new ArrayList<Ejemplar>(); // evita null
        }

        public String getID() {  return ID; }
        public DateTime getFechaInicio() { return fechaInicio; }
        public DateTime getFechaFin() { return fechaFin; }
        public EstadoPrestamo getEstado() { return estado; }
        public void setEstado(EstadoPrestamo estado) { this.estado = estado; }
        public Usuario getUsuario() { return usuario; }
        public PersonalSala getPersonalSala() { return trabajador; }
        public ArrayList getEjemplares() { return ejemplar; }
    }
}
