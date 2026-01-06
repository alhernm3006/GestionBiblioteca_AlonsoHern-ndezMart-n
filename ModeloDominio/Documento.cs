using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public abstract class Documento
    {
        private string isbn;
        private string titulo;
        private string autor;
        private int año;
        private string editorial;
        private EstadoActivoInactivo estado;

        // PRE: ISBN, titulo, autor y editorial no deben ser nulos ni estar vacíos. 
        //      El año debe ser > 0.
        // POS: Inicializa los atributos del documento. El estado por defecto se establece en 'inactivo'.
        public Documento(string ISBN, string titulo, string autor, int año, string editorial)
        {
            this.isbn = ISBN;
            this.titulo = titulo;
            this.autor = autor;
            this.año = año;
            this.editorial = editorial;
            this.estado = EstadoActivoInactivo.inactivo;
        }

        // PRE: el documento tiene que ser inicializada previamente
        // POS: devuelve el isbn del documento
        public string ISBN
        {
            get
            {
                return isbn;
            }
        }

        // PRE: el documento tiene que ser inicializada previamente
        // POS: devuelve el título del documento
        public string Titulo
        {
            get
            {
                return titulo;
            }
        }

        // PRE: el documento tiene que ser inicializada previamente
        // POS: devuelve el autor del documento
        public string Autor
        {
            get
            {
                return autor;
            }
        }

        // PRE: el documento tiene que ser inicializada previamente
        // POS: devuelve el año del documento
        public int Año
        {
            get
            {
                return año;
            }
        }

        // PRE: el documento tiene que ser inicializada previamente
        // POS: devuelve el editorial del documento
        public string Editorial
        {
            get
            {
                return editorial;
            }
        }

        // PRE: el documento tiene que ser inicializada previamente
        public EstadoActivoInactivo Estado
        {
            // POS: devuelve el estado del documento
            get
            {
                return estado;
            }
            // POS: establece el valor del estado pasado al documento
            set
            {
                this.estado = value;
            }
        }

        // PRE: el documento tiene que ser inicializada previamente
        // POS: devuelve la representación en cadena de caracteres del documento
        public override string ToString()
        {
            return "Título: " + titulo + " Autor: " + autor + " ISBN: " + isbn + " Año: " + año + " Editorial: " + editorial + " Estado: " + estado;
        }
    }
}
