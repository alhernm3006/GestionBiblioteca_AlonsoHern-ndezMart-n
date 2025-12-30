using ModeloDominio;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LógicaNegocio
{
    internal class PersonalAdquisicion : PersonalBiblioteca
    {
        private Libro_CRUD libroCRUD;
        private AudioLibro_CRUD audioCRUD;
        private Documento_CRUD documentoCRUD;
        private Ejemplar_CRUD ejemplarCRUD;

        public PersonalAdquisicion(string nss, string usuario) : base(nss, usuario)
        {
            libroCRUD = new Libro_CRUD();
            audioCRUD = new AudioLibro_CRUD();
            documentoCRUD = new Documento_CRUD();
            ejemplarCRUD = new Ejemplar_CRUD();
        }

        // --- Gestión de Documentos ---

        public bool altaDocumento(Documento doc)
        {
            try
            {
                if (doc is LibroPapel libro)
                {
                    libroCRUD.Insertar(libro);
                }
                else if (doc is AudioLibro audio)
                {
                    audioCRUD.Insertar(audio);
                }
                else
                {
                    return false; // Tipo desconocido
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool bajaDocumento(string isbn)
        {
            try
            {
                // Nota: Idealmente deberías verificar si tiene ejemplares o préstamos activos antes de borrar
                documentoCRUD.Eliminar(isbn);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Documento> obtenerDocumentos()
        {
            return documentoCRUD.ListarTodos();
        }

        public Documento documentoMasPrestado()
        {
            // Estrategia: Obtener todos los préstamos y contar los ISBNs manualmente
            // ya que no podemos acceder a la tabla de relaciones de la BD directamente.

            // 1. Obtener historial completo de préstamos
            List<Prestamo> todosLosPrestamos = prestamoCRUD.ListarTodos();
            
            Dictionary<string, int> conteoISBN = new Dictionary<string, int>();

            // 2. Contar apariciones
            foreach (var prestamo in todosLosPrestamos)
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

            // 3. Determinar ganador
            if (conteoISBN.Count == 0) return null;

            string isbnGanador = conteoISBN.OrderByDescending(pair => pair.Value).First().Key;

            return documentoCRUD.Buscar(isbnGanador);
        }

        // --- Gestión de Ejemplares ---

        public bool altaEjemplar(Ejemplar ej)
        {
            try
            {
                ejemplarCRUD.Insertar(ej);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool bajaEjemplar(string isbn, string codigo)
        {
            try
            {
                ejemplarCRUD.Eliminar(isbn, codigo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Ejemplar> obtenerEjemplares(string isbn)
        {
            // Requiere método auxiliar en Ejemplar_CRUD (ver abajo)
            return ejemplarCRUD.ListarPorDocumento(isbn);
        }

        public bool ejemplaresDisponibles(string isbn)
        {
            List<Ejemplar> lista = ejemplarCRUD.ListarPorDocumento(isbn);
            // Usamos LINQ para ver si alguno está disponible
            return lista.Any(e => e.Estado == EstadoEjemplar.disponible);
        }

        public string informacionEjemplar(string isbn, string codigo)
        {
            Ejemplar ej = ejemplarCRUD.Buscar(isbn, codigo);
            if (ej != null)
            {
                return ej.toString();
            }
            return "Ejemplar no encontrado.";
        }

        public DateTime fechaDisponibilidad(string isbn)
        {
            // 1. Si hay ejemplares disponibles YA, la fecha es ahora mismo.
            if (ejemplaresDisponibles(isbn)) return DateTime.Now;

            // 2. Si no, hay que buscar cuándo se devuelve el primero.
            List<Prestamo> prestamosActivos = prestamoCRUD.ListarTodos();
            DateTime fechaMasProxima = DateTime.MaxValue;
            bool encontrado = false;

            foreach (var p in prestamosActivos)
            {
                // Solo nos interesan los préstamos activos
                if (p.Estado == EstadoPrestamo.enProceso)
                {
                    // Revisamos si este préstamo tiene un ejemplar del libro que buscamos
                    if (p.Ejemplares.Any(e => e.Documento.ISBN == isbn))
                    {
                        encontrado = true;
                        // Nos quedamos con la fecha más cercana (menor)
                        if (p.FechaFin < fechaMasProxima)
                        {
                            fechaMasProxima = p.FechaFin;
                        }
                    }
                }
            }

            // Si se encontró algún préstamo, devolvemos la fecha, si no (ej. no hay ejemplares o todos perdidos), MinValue.
            return encontrado ? fechaMasProxima : DateTime.MinValue;
        }
    }
}
