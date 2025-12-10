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
        private string estado;

        public DocumentoDato(string ISBN, string titulo, string autor, int año, string editorial) : base(ISBN)
        {
            this.isbn = ISBN;
            this.titulo = titulo;
            this.autor = autor;
            this.año = año;
            this.editorial = editorial;
            this.estado = "inactivo";
        }

        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }

        public int Año
        {
            get { return año; }
            set { año = value; }
        }

        public string Editorial
        {
            get { return editorial; }
            set { editorial = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }
}
