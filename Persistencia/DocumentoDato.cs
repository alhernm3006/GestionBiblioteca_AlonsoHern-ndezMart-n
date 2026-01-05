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

        // PRE: 'ISBN' no debe ser nulo . 'titulo', 'autor', 'editorial' y 'estado' no deben ser nulos.
        // POS: Crea DocumentoDato .
        public DocumentoDato(string ISBN, string titulo, string autor, int año, string editorial, string estado) : base(ISBN)
        {
            this.isbn = ISBN;
            this.titulo = titulo;
            this.autor = autor;
            this.año = año;
            this.editorial = editorial;
            this.estado = estado;
        }

        public string Isbn
        {
            // POS: Devuelve el ISBN del documento.
            get { return isbn; }
            // POS: Asigna un nuevo valor al ISBN del documento.
            set { isbn = value; }
        }

        public string Titulo
        {
            // POS: Devuelve el título del documento.
            get { return titulo; }
            // POS: Asigna un nuevo valor al título del documento.
            set { titulo = value; }
        }

        public string Autor
        {
            // POS: Devuelve el autor del documento.
            get { return autor; }
            // POS: Asigna un nuevo valor al autor del documento.
            set { autor = value; }
        }

        public int Año
        {
            // POS: Devuelve el año de publicación del documento.
            get { return año; }
            // POS: Asigna un nuevo valor al año de publicación.
            set { año = value; }
        }

        public string Editorial
        {
            // POS: Devuelve la editorial del documento.
            get { return editorial; }
            // POS: Asigna un nuevo valor a la editorial del documento.
            set { editorial = value; }
        }

        public string Estado
        {
            // POS: Devuelve el estado actual del documento
            get { return estado; }
            // POS: Asigna un nuevo valor al estado del documento.
            set { estado = value; }
        }
    }
}
