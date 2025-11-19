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

        public Ejemplar(Documento documento, string codigo, PersonalAdquisicion trabajador)
        {
            this.documento = documento;
            this.codigo = codigo;
            this.estado = EstadoEjemplar.archivado;
            this.trabajador = trabajador;
        }

        public Documento getDocumento() { return documento; }
        public String getCodigo() { return codigo; }
        public EstadoEjemplar getEstado() { return estado; }
        public PersonalAdquisicion getPersonalAdquisicion() { return trabajador; }
        public void setEstado(EstadoEjemplar estado) { this.estado = estado; }
        public String toString() { return ("ISBN: " + this.documento.getISBN() + " código: " + this.codigo + " estado: " + this.trabajador + "\n"); }
    }
}
