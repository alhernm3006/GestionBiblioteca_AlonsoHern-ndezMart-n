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

        // PRE: 'clave' no debe ser nulo .
        // POS: Crea Prestamo_Ejemplar.
        public Prestamo_EjemplarDato(ClavePrestamoEjemplar clave, DateTime fDev, DateTime fDevPrev) : base(clave)
        {
            {
                this.fechaDevolucion = fDev;
                this.fechaDevolucionPrevista = fDevPrev;
            }
        }

        public DateTime FechaDevolucion
        {
            // POS: Devuelve la fecha real en la que se devolvió el ejemplar.
            get { return this.fechaDevolucion; }
            // POS: Asigna una nueva fecha de devolución real.
            set { fechaDevolucion = value; }
        }

        public DateTime FechaDevolucionPrevista
        {
            // POS: Devuelve la fecha en la que estaba prevista la devolución del ejemplar.
            get { return this.fechaDevolucionPrevista; }
            // POS: Asigna una nueva fecha de devolución prevista.
            set { fechaDevolucionPrevista = value; }
        }
    }
}
