using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class DocumentoDato : Entity<String>
    {
        private string isbn;
        private string titulo;
        private string autor;
        private int año;
        private string editorial;
        private String estado;

        public DocumentoDato(string ISBN, string titulo, string autor, int año, string editorial) : base(ISBN)
        {
            this.isbn = ISBN;
            this.titulo = titulo;
            this.autor = autor;
            this.año = año;
            this.editorial = editorial;
            this.estado = "inactivo";
        }

    }
}
