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
        public string getFormato() {
            return this.formato;        
        }
        public float getDuracion() {
            return this.duracion;        
        }
        public string toString() {
            return ("ISBN: " + this.getISBN() + "\n" + "TITULO: " + this.getTitulo() + "\n" + "AUTOR: " + this.getAutor() + "\n" + "AÑO: " + this.getAño() + "\n" + "EDITORIAL: " + this.getEditorial() + "\n" + "ESTADO: " + this.getEstado() + "\n"+"FORMATO: "+this.formato+"\n"+"DURACION: "+this.duracion+"\n");
        }
    }
}
