using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class AudioLibro: Documento
    {
        private string formato;
        private float duracion;
        public AudioLibro(string ISBN, string titulo, string autor, int año, string editorial, string formato, float duracion) : base(ISBN, titulo, autor, año, editorial)
        {
            this.formato = formato;
            this.duracion = duracion;
        }
        public string Formato {
            get{return this.formato;}      
        }
        public float Duracion {
            get{return this.duracion;  }      
        }
        public string toString() {
            return ("ISBN: " + this.ISBN + "\n" + "TITULO: " + this.Titulo + "\n" + "AUTOR: " + this.Autor + "\n" + "AÑO: " + this.Año + "\n" + "EDITORIAL: " + this.Editorial + "\n" + "ESTADO: " + this.Estado + "\n"+"FORMATO: "+this.formato+"\n"+"DURACION: "+this.duracion+"\n");
        }
    }
}
