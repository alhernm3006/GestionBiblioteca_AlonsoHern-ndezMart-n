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

        public EjemplarDato(ClaveEjemplar clave, string estado, string id) : base(clave)
        {
            this.isbn = clave.ISBN;
            this.codigo = clave.Codigo;
            this.estado = estado;
            this.idPersonal = id;
        }

        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string IdPersonal
        {
            get { return idPersonal; }
            set { idPersonal = value; }
        }
    }
}
