using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using ModeloDominio;

namespace LógicaNegocio
{
        public class PersonalSala : PersonalBiblioteca
        {

            public PersonalSala()
            {
             
            }

            public void realizarPrestamo(Prestamo prestamo)
            {
                // 1. Validar estado del usuario
                if (prestamo.Usuario.Estado != EstadoActivoInactivo.activo)
                {
                    throw new Exception("El usuario no está activo y no puede realizar préstamos.");
                }

                // 2. Validar disponibilidad de TODOS los ejemplares antes de procesar nada
                foreach (var ej in prestamo.Ejemplares)
                {
                    // Recuperamos el estado actual real desde persistencia
                    Ejemplar estadoReal = ejemplarCRUD.Buscar(ej.Documento.ISBN, ej.Codigo);

                    if (estadoReal == null)
                        throw new Exception($"El ejemplar {ej.Codigo} no existe.");

                    if (estadoReal.Estado != EstadoEjemplar.disponible)
                        throw new Exception($"El ejemplar {ej.Codigo} del libro '{ej.Documento.Titulo}' no está disponible (Estado: {estadoReal.Estado}).");
                }

                // 3. Persistir el Préstamo (Cabecera y líneas de detalle)
                // El CRUD se encarga de guardar el objeto Prestamo y sus relaciones en BD.TablaPrestamosEjemplares
                prestamoCRUD.Insertar(prestamo);

                // 4. Actualizar el estado de los ejemplares a 'prestado'
                foreach (var ej in prestamo.Ejemplares)
                {
                    // Usamos el método público que creamos en Ejemplar_CRUD para no tocar BD directa
                    ejemplarCRUD.ActualizarEstado(ej.Documento.ISBN, ej.Codigo, EstadoEjemplar.prestado);

                    // Actualizamos también el objeto local por coherencia
                    ej.Estado = EstadoEjemplar.prestado;
                }
            }

        public Prestamo buscarPrestamo(String codigo)
        {
            return prestamoCRUD.Buscar(codigo);
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
        public void devolverEjemplar(string isbn, string codigo)
            {
                // 1. Buscar el ejemplar para validar que existe
                Ejemplar ej = ejemplarCRUD.Buscar(isbn, codigo);
                if (ej == null) throw new Exception("El ejemplar no existe.");

                // 2. Marcar el ejemplar como disponible en la BD
                ejemplarCRUD.ActualizarEstado(isbn, codigo, EstadoEjemplar.disponible);

                // 3. Registrar la fecha de devolución en la línea del préstamo correspondiente
                // Esto cierra la línea en la tabla intermedia
                prestamoCRUD.RegistrarDevolucionEjemplar(isbn, codigo);
            }

            public string consultarPrestamo(string idPrestamo)
            {
                Prestamo p = prestamoCRUD.Buscar(idPrestamo);

                if (p != null)
                {
                    return $"ID: {p.ID}\n" +
                           $"Usuario: {p.Usuario.Nombre} (DNI: {p.Usuario.DNI})\n" +
                           $"Fecha Inicio: {p.FechaInicio.ToShortDateString()}\n" +
                           $"Fecha Fin: {p.FechaFin.ToShortDateString()}\n" +
                           $"Estado: {p.Estado}\n" +
                           $"Ejemplares: {p.Ejemplares.Count}";
                }
                return "Préstamo no encontrado.";
            }

            public EstadoPrestamo consultarEstadoPrestamo(string idPrestamo)
            {
                Prestamo p = prestamoCRUD.Buscar(idPrestamo);
                if (p == null) throw new Exception("El préstamo con ese ID no existe.");

                return p.Estado;
            }

            public List<Prestamo> obtenerPrestamos()
            {
                // Recupera todos los préstamos usando el método puente del CRUD
                return prestamoCRUD.ListarTodos();
            }

            public List<Prestamo> obtenerPrestamosVencidos()
            {
                // Obtenemos todos y filtramos en memoria (Lógica de Negocio)
                List<Prestamo> todos = prestamoCRUD.ListarTodos();
                List<Prestamo> vencidos = new List<Prestamo>();

                foreach (var p in todos)
                {
                    // Criterio: Está en proceso Y la fecha actual es mayor a la fecha límite
                    if (p.Estado == EstadoPrestamo.enProceso && DateTime.Now > p.FechaFin)
                    {
                        vencidos.Add(p);
                    }
                }
                return vencidos;
            }

            public List<Ejemplar> ejemplaresNoDevueltos(string idPrestamo)
            {
                // Retorna los ejemplares de un préstamo específico que aún siguen prestados
                List<Ejemplar> pendientes = new List<Ejemplar>();

                // Buscamos el préstamo completo
                Prestamo p = prestamoCRUD.Buscar(idPrestamo);

                if (p != null && p.Estado == EstadoPrestamo.enProceso)
                {
                    foreach (var ej in p.Ejemplares)
                    {
                        // Consultamos el estado actual de cada ejemplar en la BD
                        Ejemplar estadoActual = ejemplarCRUD.Buscar(ej.Documento.ISBN, ej.Codigo);

                        // Si sigue figurando como "prestado", es que no se ha devuelto
                        if (estadoActual.Estado == EstadoEjemplar.prestado)
                        {
                            pendientes.Add(estadoActual);
                        }
                    }
                }
                return pendientes;
            }
        }
    }

