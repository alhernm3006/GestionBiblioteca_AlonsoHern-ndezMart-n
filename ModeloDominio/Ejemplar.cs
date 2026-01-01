using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModeloDominio
{
    public  class Ejemplar
    {
        private Documento documento;
        private String codigo;
        private EstadoEjemplar estado;
        private PersonalAdquisicion trabajador;
        private Documento documentoSeleccionado;
     
      

        public Ejemplar(Documento documento, string codigo, PersonalAdquisicion trabajador)
        {
            this.documento = documento;
            this.codigo = codigo;
            this.estado = EstadoEjemplar.archivado;
            this.trabajador = trabajador;
        }

     

        public Documento Documento
        {
            get { return documento; }
        }
        public String Codigo { get { return codigo; } }
        public EstadoEjemplar Estado { 
            get { return estado; }
            set { this.estado = value; }
        }
        public PersonalAdquisicion PersonalAdquisicion {
            get { return trabajador; }
        }
        public String toString() { return ("ISBN: " + this.documento.ISBN + " código: " + this.codigo + " estado: " + this.trabajador + "\n"); }
    }
}
