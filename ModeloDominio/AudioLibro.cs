using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class AudioLibro : Documento
    {
        private string formato;
        private float duracion;

        // PRE: ISBN, titulo, autor, editorial y formato no deben ser nulos ni estar vacíos.
        //      El año debe ser > 0 al igual que la duracion, representada en horas.
        // POS: Se crea una instancia de AudioLibro
        public AudioLibro(string ISBN, string titulo, string autor, int año, string editorial, string formato, float duracion) : base(ISBN, titulo, autor, año, editorial)
        {
            this.formato = formato;
            this.duracion = duracion;
        }

        // PRE: audioLibro tiene que ser inicializada previamente
        // POS: devuelve el formato del audiolibro
        public string Formato
        {
            get { return this.formato; }
        }

        // PRE: audioLibro tiene que ser inicializada previamente
        // POS: devuelve la duración del audiolibro
        public float Duracion
        {
            get { return this.duracion; }
        }

        // PRE: audioLibro tiene que ser inicializada previamente
        // POS: devuelve la representación en cadena de caracteres del audiolibro
        public string toString()
        {
            return ("ISBN: " + this.ISBN + "\n" + "TITULO: " + this.Titulo + "\n" + "AUTOR: " + this.Autor + "\n" + "AÑO: " + this.Año + "\n" + "EDITORIAL: " + this.Editorial + "\n" + "ESTADO: " + this.Estado + "\n" + "FORMATO: " + this.formato + "\n" + "DURACION: " + this.duracion + "\n");
        }
    }
}
