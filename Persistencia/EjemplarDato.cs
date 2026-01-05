using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class EjemplarDato : Entity<ClaveEjemplar>
    {
        private string isbn;
        private string codigo;
        private string estado;
        private string idPersonal;

        // PRE: 'clave' no debe ser nulo. 'estado' e 'id' no deben ser nulos.
        // POS: Crea una nueva instancia de EjemplarDato. 
       
        public EjemplarDato(ClaveEjemplar clave, string estado, string id) : base(clave)
        {
            this.isbn = clave.ISBN;
            this.codigo = clave.Codigo;
            this.estado = estado;
            this.idPersonal = id;
        }

        public string Isbn
        {
            // POS: Devuelve el ISBN del documento al que pertenece el ejemplar.
            get { return isbn; }
            // POS: Asigna un nuevo valor al ISBN.
            set { isbn = value; }
        }

        public string Codigo
        {
            // POS: Devuelve el código del ejemplar.
            get { return codigo; }
            // POS: Asigna un nuevo valor al código.
            set { codigo = value; }
        }

        public string Estado
        {
            // POS: Devuelve el estado actual del ejemplar.
            get { return estado; }
            // POS: Asigna un nuevo estado al ejemplar.
            set { estado = value; }
        }

        public string IdPersonal
        {
            // POS: Devuelve el identificador del personal asociado al ejemplar.
            get { return idPersonal; }
            // POS: Asigna un nuevo identificador de personal.
            set { idPersonal = value; }
        }
    }
}
