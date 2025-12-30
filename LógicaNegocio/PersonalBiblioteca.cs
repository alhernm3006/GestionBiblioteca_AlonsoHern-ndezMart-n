
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using ModeloDominio;

namespace LógicaNegocio
{
    public class PersonalBiblioteca
    {
        
        
            // Los CRUDs deben ser PUBLIC para usarse aquí
            protected Usuario_CRUD usuarioCRUD = new Usuario_CRUD();
            protected Prestamo_CRUD prestamoCRUD = new Prestamo_CRUD();
            protected Ejemplar_CRUD ejemplarCRUD = new Ejemplar_CRUD();

            public PersonalBiblioteca()
            {
               
            }

            public bool iniciarSesion(string usuario, string contraseña)
            {
                // Lógica simulada
                return !string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(contraseña);
            }

            public void cerrarSesion() { }

            // --- Gestión de Usuarios ---

            public bool altaUsuario(Usuario u)
            {
                try
                {
                    usuarioCRUD.Insertar(u);
                    return true;
                }
                catch (Exception) { return false; }
            }

            public bool bajaUsuario(string dni)
            {
                try
                {
                    usuarioCRUD.Eliminar(dni);
                    return true;
                }
                catch (Exception) { return false; }
            }

            public Usuario getUsuario(string dni)
            {
                return usuarioCRUD.Buscar(dni);
            }

            public List<Usuario> obtenerUsuarios()
            {
                // REQUISITO: Usuario_CRUD necesita un método public List<Usuario> ListarTodos()
                return usuarioCRUD.ListarTodos();
            }

            // --- Consultas ---

            public List<Ejemplar> obtenerEjemplaresPrestados(string dni)
            {
                // REQUISITO: Prestamo_CRUD necesita public List<Prestamo> ListarPorUsuario(string dni)
                // Se asume que el objeto Prestamo devuelto viene con su lista de Ejemplares llena.
                List<Prestamo> prestamosUsuario = prestamoCRUD.ListarPorUsuario(dni);

                List<Ejemplar> ejemplares = new List<Ejemplar>();

                foreach (Prestamo p in prestamosUsuario)
                {
                    if (p.Estado == EstadoPrestamo.enProceso)
                    {
                        ejemplares.AddRange(p.Ejemplares);
                    }
                }
                return ejemplares;
            }

            public List<Ejemplar> obtenerEjemplaresFueraPlazo(string dni)
            {
                List<Prestamo> prestamosUsuario = prestamoCRUD.ListarPorUsuario(dni);
                List<Ejemplar> fueraPlazo = new List<Ejemplar>();

                foreach (Prestamo p in prestamosUsuario)
                {
                    if (p.Estado == EstadoPrestamo.enProceso && DateTime.Now > p.FechaFin)
                    {
                        fueraPlazo.AddRange(p.Ejemplares);
                    }
                }
                return fueraPlazo;
            }
        }
    }
