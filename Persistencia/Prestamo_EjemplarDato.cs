using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class Prestamo_EjemplarDato : Entity<ClavePrestamoEjemplar>
    {
        private DateTime fechaDevolucion;
        private DateTime fechaDevolucionPrevista;

        //terminar
        public Prestamo_EjemplarDato(ClavePrestamoEjemplar clave, DateTime fDev, DateTime fDevPrev) : base(clave)
        {
            {
                this.fechaDevolucion = fDev;
                this.fechaDevolucionPrevista = fDevPrev;
            }
        }

        public DateTime FechaDevolucion
        {
            get { return this.fechaDevolucion; }
            set { fechaDevolucion = value; }
        }

        public DateTime FechaDevolucionPrevista
        {
            get { return this.fechaDevolucionPrevista; }
            set { fechaDevolucionPrevista = value; }
        }
    }
}
