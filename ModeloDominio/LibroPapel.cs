using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class LibroPapel : Documento {
        public LibroPapel(string ISBN, string titulo, string autor, int año, string editorial) : base(ISBN, titulo, autor, año, editorial) { }
        public string toString() {
            return ("ISBN: " + this.ISBN + "\n" + "TITULO: " + this.Titulo + "\n" + "AUTOR: " + this.Autor + "\n" + "AÑO: " + this.Año + "\n" + "EDITORIAL: " + this.Editorial + "\n"+"ESTADO: "+this.Estado+"\n");
        }
    }
}
