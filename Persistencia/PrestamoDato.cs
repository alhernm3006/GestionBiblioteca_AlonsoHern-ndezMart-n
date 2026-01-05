using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class PrestamoDato : Entity<String>
    {
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private string estado;
        private string dniUsuario;
        private string idPersonal;

        // PRE: 'ID' no debe ser nulo. 'dni' y 'idPersonal' no deben ser nulos .
        // POS: Crea PrestamoDato.
        public PrestamoDato(string ID, DateTime fechaInicio, DateTime fechaFin, string estado, string dni, string idPersonal) : base(ID)
        {
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.estado = estado;
            this.dniUsuario = dni;
            this.idPersonal = idPersonal;
        }

        public DateTime FechaInicio
        {
            // POS: Devuelve la fecha de inicio del préstamo.
            get { return fechaInicio; }
            // POS: Asigna una nueva fecha de inicio al préstamo.
            set { fechaInicio = value; }
        }

        public DateTime FechaFin
        {
            // POS: Devuelve la fecha de finalización (prevista o real) del préstamo.
            get { return fechaFin; }
            // POS: Asigna una nueva fecha de finalización al préstamo.
            set { fechaFin = value; }
        }

        public string Estado
        {
            // POS: Devuelve el estado actual del préstamo.
            get { return estado; }
            // POS: Asigna un nuevo estado al préstamo.
            set { estado = value; }
        }

        public string DniUsuario
        {
            // POS: Devuelve el DNI del usuario asociado al préstamo.
            get { return dniUsuario; }
            // POS: Asigna un nuevo DNI de usuario al préstamo.
            set { dniUsuario = value; }
        }

        public string IdPersonal
        {
            // POS: Devuelve el identificador del personal que gestionó el préstamo.
            get { return idPersonal; }
            // POS: Asigna un nuevo identificador de personal al préstamo.
            set { idPersonal = value; }
        }
    }
}
