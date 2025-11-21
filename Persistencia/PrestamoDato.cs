using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class PrestamoDato : Entity<String>
    {
        private String id;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private String estado;
        private String dniUsuario;
        private String nssTrabajador;

        public PrestamoDato(string ID, DateTime fechaInicio, DateTime fechaFin,
                    String estado, String dni,
                    String nss) : base(ID)
        {
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.estado = estado;
            this.dniUsuario = dni;
            this.nssTrabajador = nss;
        }

    }
}
