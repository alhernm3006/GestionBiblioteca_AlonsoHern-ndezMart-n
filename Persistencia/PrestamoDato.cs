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
        private string nssTrabajador;

        public PrestamoDato(string ID, DateTime fechaInicio, DateTime fechaFin,
                    string estado, string dni,
                    string nss) : base(ID)
        {
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.estado = estado;
            this.dniUsuario = dni;
            this.nssTrabajador = nss;
        }

        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value;}
        }

        public DateTime FechaFin
        {
            get { return fechaFin; }
            set { fechaFin = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string DniUsuario
        {
            get { return dniUsuario; }
            set { dniUsuario = value; }
        }

        public string NssTrabajador
        {
            get { return nssTrabajador; }
            set { nssTrabajador = value; }
        }
    }
}
