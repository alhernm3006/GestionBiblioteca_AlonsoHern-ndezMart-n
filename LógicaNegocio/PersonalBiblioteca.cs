
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
        private Usuario_CRUD usuarioCRUD = new Usuario_CRUD();
        protected Prestamo_CRUD prestamoCRUD = new Prestamo_CRUD();
        protected Ejemplar_CRUD ejemplarCRUD = new Ejemplar_CRUD();
        private Documento_CRUD documentoCRUD = new Documento_CRUD();

        private String idPersonal;
        private String contraseña;

        public PersonalBiblioteca() { }
        public String IdPersonal { get { return idPersonal; } }
        public String Contraseña { get { return contraseña; } }

        public bool iniciarSesion(string idPersonal, string contraseña, String rol)
        {
            this.idPersonal = idPersonal;
            this.contraseña = contraseña;
            ModeloDominio.PersonalBiblioteca p = personalCRUD.Buscar(idPersonal);
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


        public bool altaUsuario(Usuario u)
        {
            u.Estado = EstadoActivoInactivo.activo;
            return usuarioCRUD.Insertar(u);
        }

        public bool bajaUsuario(string dni)
        {
            return usuarioCRUD.Eliminar(dni);
        }

        public Usuario getUsuario(string dni)
        {
            return usuarioCRUD.Buscar(dni);
        }

        public List<Usuario> getUsuarios()
        {
            return usuarioCRUD.Listar();
        }

        public List<Documento> getDocumentos()
        {
            return documentoCRUD.ListarTodos();
        }

        public List<Ejemplar> getEjemplares(string isbn)
        {
            return ejemplarCRUD.ListarEjemplares(isbn);
        }

        public List<Ejemplar> getEjemplaresPrestados(string dni)
        {
            List<Prestamo> prestamosUsuario = prestamoCRUD.PrestamosUsuario(dni);

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

        public List<Ejemplar> getEjemplaresFueraPlazo(string dni)
        {
            List<Prestamo> prestamosUsuario = prestamoCRUD.PrestamosUsuario(dni);
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

        public ModeloDominio.PersonalBiblioteca getPersonal(String idPersonal)
        {
            return personalCRUD.Buscar(idPersonal);
        }
    }
}
