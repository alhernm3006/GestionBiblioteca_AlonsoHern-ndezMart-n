using ModeloDominio;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LógicaNegocio
{
        public class PersonalSala : PersonalBiblioteca
        {
            public PersonalSala(){ }

        // PRE: prestamo no debe ser nulo y tiene que contener un usuario y ejemplares válidos y activo/disponibles
        // POS: se registra el préstamo en el sistema de persistencia.
        public void realizarPrestamo(Prestamo prestamo)
            {
                if (prestamo.Usuario.Estado != EstadoActivoInactivo.activo)
                {
                    throw new Exception("El usuario no está activo y no puede realizar préstamos.");
                }

                foreach (var ej in prestamo.Ejemplares)
                {
                    Ejemplar estadoReal = ejemplarCRUD.Buscar(ej.Documento.ISBN, ej.Codigo);

                    if (estadoReal == null)
                        throw new Exception($"El ejemplar {ej.Codigo} no existe.");

                    if (estadoReal.Estado != EstadoEjemplar.disponible)
                        throw new Exception($"El ejemplar {ej.Codigo} del libro '{ej.Documento.Titulo}' no está disponible (Estado: {estadoReal.Estado}).");
                }
                prestamoCRUD.Insertar(prestamo);

                foreach (var ej in prestamo.Ejemplares)
                {
                    ejemplarCRUD.ActualizarEstado(ej.Documento.ISBN, ej.Codigo, EstadoEjemplar.prestado);
                    ej.Estado = EstadoEjemplar.prestado;
                }
            }

        //PRE:
        //POS: devuelve un prestamo si existe y nulo en caso contrario
        public Prestamo buscarPrestamo(String codigo)
        {
            return prestamoCRUD.Buscar(codigo);
        }

        //PRE: isbn y codigo no deben de ser nulos ni vacíos, y tienen que existir y estar prestados 
        //POS: marca un ejemplar como devuelto
        public void devolverEjemplar(string isbn, string codigo)
            {
                Ejemplar ej = ejemplarCRUD.Buscar(isbn, codigo);
                if (ej == null) throw new Exception("El ejemplar no existe.");

                ejemplarCRUD.ActualizarEstado(isbn, codigo, EstadoEjemplar.disponible);
                prestamoCRUD.RegistrarDevolucionEjemplar(isbn, codigo);
            }

        //PRE: idPrestamo tiene que ser un id válido existente
        //POS: devuelve el estado del prestamo
        public EstadoPrestamo consultarEstadoPrestamo(string idPrestamo)
            {
                Prestamo p = prestamoCRUD.Buscar(idPrestamo);
                if (p == null) throw new Exception("El préstamo con ese ID no existe.");

                return p.Estado;
            }

        //PRE:
        //POS: devuelve una lista con los prestamos existentes y nulo en caso contrario
        public List<Prestamo> obtenerPrestamos()
            {
                return prestamoCRUD.ListarTodos();
            }

        //PRE:
        //POS: devuelve una lista con los prestamos vencidos
        public List<Prestamo> obtenerPrestamosVencidos()
            {
                List<Prestamo> todos = prestamoCRUD.ListarTodos();
                List<Prestamo> vencidos = new List<Prestamo>();

                foreach (var p in todos)
                {
                    if (p.Estado == EstadoPrestamo.enProceso && DateTime.Now > p.FechaFin)
                    {
                        vencidos.Add(p);
                    }
                }
                return vencidos;
            }

        //PRE:
        //POS: devuelve una lista con los ejemplares no devueltos del id del préstamo pasado
        public List<Ejemplar> ejemplaresNoDevueltos(string idPrestamo)
            {
                List<Ejemplar> pendientes = new List<Ejemplar>();
                Prestamo p = prestamoCRUD.Buscar(idPrestamo);

                if (p != null && p.Estado == EstadoPrestamo.enProceso)
                {
                    foreach (var ej in p.Ejemplares)
                    {
                        Ejemplar estadoActual = ejemplarCRUD.Buscar(ej.Documento.ISBN, ej.Codigo);
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

