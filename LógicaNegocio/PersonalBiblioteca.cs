
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using ModeloDominio;
using System.CodeDom;

namespace LógicaNegocio
{
    public class PersonalBiblioteca
    {
            private Personal_CRUD personalCRUD = new Personal_CRUD();
            protected Usuario_CRUD usuarioCRUD = new Usuario_CRUD();
            protected Prestamo_CRUD prestamoCRUD = new Prestamo_CRUD();
            protected Ejemplar_CRUD ejemplarCRUD = new Ejemplar_CRUD();
            private String nombre;
            private String contraseña;
       
           

            public PersonalBiblioteca() {}

            public bool iniciarSesion(string idUsuario, string contraseña, String rol)
            {
                this.nombre = idUsuario;
                this.contraseña = contraseña;
                ModeloDominio.PersonalBiblioteca p = personalCRUD.Buscar(idUsuario);
                if (p != null)
                {
                    switch (rol)
                    {
                        case "Sala": return p is ModeloDominio.PersonalSala;
                        case "Adquisición": return p is ModeloDominio.PersonalAdquisicion;
                    }
                }
                return false;
              }

            public void cerrarSesion() { }

        // --- Gestión de Usuarios ---
        public List<Documento> obtenerDocumentos()
        {
            // Utilizamos el CRUD protegido que ya existe en esta clase
            Documento_CRUD documentoCRUD = new Documento_CRUD();
            return documentoCRUD.ListarTodos();
        }

        public List<Ejemplar> obtenerEjemplares(string isbn)
        {
            // Utilizamos el CRUD protegido
            Ejemplar_CRUD ejemplarCRUD = new Ejemplar_CRUD();
            return ejemplarCRUD.ListarPorDocumento(isbn);
        }
        public bool altaUsuario(Usuario u)
            {
                try
                {
                    u.Estado = EstadoActivoInactivo.activo;
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

        public String Nombre {  get { return nombre; } }
        public String Contraseña { get { return contraseña; } }

    }
    }
