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
            return ("ISBN: " + this.getISBN() + "\n" + "TITULO: " + this.getTitulo() + "\n" + "AUTOR: " + this.getAutor() + "\n" + "AÑO: " + this.getAño() + "\n" + "EDITORIAL: " + this.getEditorial() + "\n"+"ESTADO: "+this.getEstado()+"\n");
        }
    }
}
