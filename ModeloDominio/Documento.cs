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
        public Documento(string ISBN, string titulo, string autor, int año, string editorial)
        {
            this.isbn = ISBN;
            this.titulo = titulo;
            this.autor = autor;
            this.año = año;
            this.editorial = editorial;
            this.estado = EstadoActivoInactivo.inactivo;
        }

        public string ISBN {
            get
            {
                return isbn;
            }
        }
        public string Titulo {
            get
            {
                return titulo;
            }
        }
        public string Autor {
            get
            {
                return autor;
            }
        }
        public int Año {
            get
            {
                return año;
            }
        }
        public string Editorial
        {
            get
            {
                return editorial;
            }
        }
        public EstadoActivoInactivo Estado {
            get
            {
                return estado;
            }
            set
            {
                this.estado = value;
            }
        }
    }
}
