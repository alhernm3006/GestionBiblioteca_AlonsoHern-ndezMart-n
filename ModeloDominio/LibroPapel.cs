using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDominio
{
    public class LibroPapel : Documento {

        // PRE: ISBN, titulo, autor, editorial y formato no deben ser nulos ni estar vacíos. El año debe ser > 0
        // POS: Se crea una instancia de LibroPapel
        public LibroPapel(string ISBN, string titulo, string autor, int año, string editorial) : base(ISBN, titulo, autor, año, editorial) { }

        // PRE: libroPapel tiene que ser inicializada previamente
        // POS: devuelve la representación en cadena de caracteres del libropapel
        public string toString() {
            return ("ISBN: " + this.ISBN + "\n" + "TITULO: " + this.Titulo + "\n" + "AUTOR: " + this.Autor + "\n" + "AÑO: " + this.Año + "\n" + "EDITORIAL: " + this.Editorial + "\n"+"ESTADO: "+this.Estado+"\n");
        }
    }
}
