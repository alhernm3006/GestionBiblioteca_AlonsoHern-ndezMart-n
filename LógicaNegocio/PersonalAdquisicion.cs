using ModeloDominio;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LógicaNegocio
{
    public class PersonalAdquisicion : PersonalBiblioteca
    {
        private Libro_CRUD libroCRUD = new Libro_CRUD();
        private AudioLibro_CRUD audioCRUD = new AudioLibro_CRUD();
        private Documento_CRUD documentoCRUD = new Documento_CRUD();

        public PersonalAdquisicion() { }

        public bool altaDocumento(Documento doc)
        {
            doc.Estado = EstadoActivoInactivo.activo;
            if (doc is LibroPapel libro)
            {
                return libroCRUD.Insertar(libro);
            }
            else if (doc is AudioLibro audio)
            {
                return audioCRUD.Insertar(audio);
            }
            return false;
        }

        public bool bajaDocumento(string isbn)
        {
            foreach (var item in getEjemplares(isbn))
            {
                if (item.Estado.Equals(EstadoEjemplar.prestado)) { return false; }
            }
            return documentoCRUD.Eliminar(isbn);
        }

        public Documento documentoMasPrestado()
        {
            List<Prestamo> Prestamos = prestamoCRUD.ListarTodos();
            Dictionary<string, int> conteoISBN = new Dictionary<string, int>();

            foreach (var prestamo in Prestamos)
            {
                foreach (var ejemplar in prestamo.Ejemplares)
                {
                    string isbn = ejemplar.Documento.ISBN;
                    if (conteoISBN.ContainsKey(isbn))
                    {
                        conteoISBN[isbn]++;
                    }
                    else
                    {
                        conteoISBN[isbn] = 1;
                    }
                }
            }

            if (conteoISBN.Count == 0) return null;

            string isbnGanador = conteoISBN.OrderByDescending(pair => pair.Value).First().Key;

            return documentoCRUD.Buscar(isbnGanador);
        }


        public bool altaEjemplar(Ejemplar ej)
        {
            ej.Estado = EstadoEjemplar.disponible;
            return ejemplarCRUD.Insertar(ej);
        }
        public bool bajaEjemplar(string isbn, string codigo)
        {
            return ejemplarCRUD.Eliminar(isbn, codigo);
        }

        public bool ejemplaresDisponibles(string isbn)
        {
            List<Ejemplar> lista = ejemplarCRUD.ListarEjemplares(isbn);
            return lista.Any(e => e.Estado == EstadoEjemplar.disponible);
        }

        public Ejemplar getEjemplar(String isbnDocu, String codigo)
        {
            return ejemplarCRUD.Buscar(isbnDocu, codigo);
        }

        public Documento buscarPorISBN(string ISBN)
        {
            Documento d = documentoCRUD.Buscar(ISBN);
            return d;
        }

        public DateTime fechaDisponibilidad(string isbn)
        {
            if (ejemplaresDisponibles(isbn)) return DateTime.Now;

            List<Prestamo> prestamos = prestamoCRUD.ListarTodos();
            DateTime fechaMasProxima = DateTime.MaxValue;
            bool encontrado = false;

            foreach (var p in prestamos)
            {
                if (p.Estado == EstadoPrestamo.enProceso)
                {
                    if (p.Ejemplares.Any(e => e.Documento.ISBN == isbn))
                    {
                        encontrado = true;
                        if (p.FechaFin < fechaMasProxima)
                        {
                            fechaMasProxima = p.FechaFin;
                        }
                    }
                }
            }
            return encontrado ? fechaMasProxima : DateTime.MinValue;
        }
    }
}
