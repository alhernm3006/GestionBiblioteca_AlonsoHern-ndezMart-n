using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModeloDominio
{
    public class Ejemplar
    {
        private Documento documento;
        private String codigo;
        private EstadoEjemplar estado;
        private PersonalAdquisicion trabajador;
        private Documento documentoSeleccionado;

        // PRE: documento y trabajador deben estar instanciados.
        //      codigo no debe ser nulo ni estar vacío
        // POS: Crea una instancia de Ejemplar.El estado por defecto se establece en 'archivado'.
        public Ejemplar(Documento documento, string codigo, PersonalAdquisicion trabajador)
        {
            this.documento = documento;
            this.codigo = codigo;
            this.estado = EstadoEjemplar.archivado;
            this.trabajador = trabajador;
        }

        // PRE: el ejemplar tiene que ser inicializada previamente
        // POS: devuelve el documento del ejemplar
        public Documento Documento
        {
            get { return documento; }
        }

        // PRE: el ejemplar tiene que ser inicializada previamente
        // POS: devuelve el código del ejemplar
        public String Codigo { get { return codigo; } }

        // PRE: el ejemplar tiene que ser inicializada previamente
        public EstadoEjemplar Estado
        {
            // POS: devuelve el estado del ejemplar
            get { return estado; }
            // POS: establece el valor del estado pasado al ejemplar
            set { this.estado = value; }
        }

        // PRE: el ejemplar tiene que ser inicializada previamente
        // POS: devuelve el personal que creó el ejemplar
        public PersonalAdquisicion PersonalAdquisicion
        {
            get { return trabajador; }
        }

        // PRE: el ejemplar tiene que ser inicializada previamente
        // POS: devuelve la representación en cadena de caracteres del ejemplar
        public String toString() { return ("ISBN: " + this.documento.ISBN + " código: " + this.codigo + " estado: " + this.trabajador + "\n"); }
    }
}
