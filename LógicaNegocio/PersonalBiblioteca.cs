
using ModeloDominio;
using Persistencia;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

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

        public PersonalBiblioteca() { this.idPersonal = ""; this.contraseña = ""; }

        //PRE: se debe haber inicializado previamente
        //POS: devuelve el id del personal
        public String IdPersonal { get { return idPersonal; } }

        //PRE: se debe haber inicializado previamente
        //POS: devuelve la contraseña del personal
        public String Contraseña { get { return contraseña; } }

        // PRE: idPersonal, contraseña y rol no deben ser nulos ni vacíos.
        // POS: devuelve true si se han introducido correctamente las credenciales, false en caso contrario
        public bool iniciarSesion(string idPersonal, string contraseña, String rol)
        {
            this.idPersonal = idPersonal;
            this.contraseña = contraseña;
            ModeloDominio.PersonalBiblioteca p = personalCRUD.Buscar(idPersonal);
            if (p != null && p.Contraseña == contraseña)
            {
                switch (rol)
                {
                    case "Sala": return p is ModeloDominio.PersonalSala;
                    case "Adquisición": return p is ModeloDominio.PersonalAdquisicion;
                }
            }
            return false;
        }

        // PRE: u no debe ser nulo
        // POS: establece el estado del usuario como activo y devuelve true si se inserta y false en caso contrario.
        public bool altaUsuario(Usuario u)
        {
            u.Estado = EstadoActivoInactivo.activo;
            return usuarioCRUD.Insertar(u);
        }

        // PRE: 
        // POS: devuelve true si se elimina el usuario y false en caso contrario
        public bool bajaUsuario(string dni)
        {
            return usuarioCRUD.Eliminar(dni);
        }

        //PRE:
        //POS: devuelve el usuario con el dni pasado si existe y nulo en caso contrario
        public Usuario getUsuario(string dni)
        {
            return usuarioCRUD.Buscar(dni);
        }

        //PRE:
        //POS: devuelve una lista con los usuarios existentes y nulo en caso contrario
        public List<Usuario> getUsuarios()
        {
            return usuarioCRUD.Listar();
        }

        //PRE:
        //POS: devuelve una lista con los documentos existentes y nulo en caso contrario
        public List<Documento> getDocumentos()
        {
            return documentoCRUD.ListarTodos();
        }

        //PRE:
        //POS: devuelve una lista con los ejemplares existentes con el isbn pasado y nulo en caso contrario
        public List<Ejemplar> getEjemplares(string isbn)
        {
            return ejemplarCRUD.ListarEjemplares(isbn);
        }

        //PRE:
        //POS: devuelve una lista con los ejemplares que son prestados al usuario con dni pasado
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

        //PRE:
        //POS: devuelve una lista con los ejemplares fuera de plazo del usuario con dni pasado
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

        //PRE:
        //POS: devuelve el objeto PersonalBiblioteca con el id pasado y false en caso contrario
        public ModeloDominio.PersonalBiblioteca getPersonal(String idPersonal)
        {
            return personalCRUD.Buscar(idPersonal);
        }
    }
}
