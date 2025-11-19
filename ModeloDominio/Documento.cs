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
        private string ISBN;
        private string titulo;
        private string autor;
        private int año;
        private string editorial;
        private EstadoActivoInactivo estado;
        public Documento(string ISBN, string titulo, string autor, int año, string editorial)
        {
            this.ISBN = ISBN;
            this.titulo = titulo;
            this.autor = autor;
            this.año = año;
            this.editorial = editorial;
            this.estado = EstadoActivoInactivo.inactivo;
        }

        public string getISBN() {
            return ISBN;
        }
        public string getTitulo() {
            return titulo;
        }
        public string getAutor() {
            return autor;
        }
        public int getAño() {
            return año;
        }
        public string getEditorial() { 
           return editorial;
        }
        public EstadoActivoInactivo getEstado() {
           return estado;
        }
        public void setEstado(EstadoActivoInactivo estado) { 
            this.estado = estado;
        }
    }
}
