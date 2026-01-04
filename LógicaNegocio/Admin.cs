using ModeloDominio;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LógicaNegocio
{
    public class Admin
    {
        Personal_CRUD p=new Personal_CRUD();
        Ejemplar_CRUD ejemplarCRUD=new Ejemplar_CRUD();
        Libro_CRUD libroCRUD=new Libro_CRUD();
        AudioLibro_CRUD audioCRUD=new AudioLibro_CRUD();
        Usuario_CRUD usuarioCRUD = new Usuario_CRUD();
        public Admin() {}

        public void añadirtrabajador(ModeloDominio.PersonalBiblioteca g){ p.Insertar(g); }
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
        public bool altaEjemplar(Ejemplar ej)
        {
            ej.Estado = EstadoEjemplar.disponible;
            return ejemplarCRUD.Insertar(ej);
        }

        public bool altaUsuario(Usuario u)
        {
            u.Estado = EstadoActivoInactivo.activo;
            return usuarioCRUD.Insertar(u);
        }
    }
}
