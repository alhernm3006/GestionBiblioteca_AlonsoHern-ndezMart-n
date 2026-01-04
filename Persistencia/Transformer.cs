using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDominio;

namespace Persistencia
{
    internal class Transformer
    {
        public static Ejemplar EjemplarDatoAEjemplar(EjemplarDato dato)
        {
            DocumentoDato docDato = (DocumentoDato)BD.TablaDocumentos[dato.Isbn];
            Documento documento = DocumentoDatoADocumento(docDato);

            PersonalBibliotecaDato perDato = (PersonalBibliotecaDato)BD.TablaPersonal[dato.IdPersonal];
            PersonalAdquisicion trabajador = (PersonalAdquisicion)PersonalBilbiotecaDatoAPersonalBilbioteca(perDato);

            Ejemplar ejemplar = new Ejemplar(documento, dato.Codigo, trabajador);

            if (Enum.TryParse(dato.Estado, out EstadoEjemplar estadoEnum))
            {
                ejemplar.Estado = estadoEnum;
            }
            return ejemplar;
        }

        public static EjemplarDato EjemplarAEjemplarDato(Ejemplar ejemplar)
        {
            return new EjemplarDato(new ClaveEjemplar(ejemplar.Documento.ISBN, ejemplar.Codigo), ejemplar.Estado.ToString(), ejemplar.PersonalAdquisicion.IdUsuario);
        }

        public static AudioLibro AudioLibroDatoAAudioLibro(AudioLibroDato dato)
        {
            AudioLibro audiolibro = null;

            if (BD.TablaDocumentos.Contains(dato.Id))
            {
                DocumentoDato docDato = (DocumentoDato)BD.TablaDocumentos[dato.Id];
                audiolibro = new AudioLibro(docDato.Isbn, docDato.Titulo, docDato.Autor, docDato.Año, docDato.Editorial, dato.Formato, dato.Duracion);

                if (Enum.TryParse(docDato.Estado, out EstadoActivoInactivo estadoEnum))
                {
                    audiolibro.Estado = estadoEnum;
                }
            }
            return audiolibro;
        }

        public static AudioLibroDato AudioLibroAAudioLibroDato(AudioLibro audioLibro)
        {
            return new AudioLibroDato(audioLibro.ISBN, audioLibro.Formato, audioLibro.Duracion);
        }

        public static Documento DocumentoDatoADocumento(DocumentoDato dato)
        {
            Documento documento = null;
            if (BD.TablaLibrosPapel.Contains(dato.Isbn))
            {
                documento = new LibroPapel(dato.Isbn, dato.Titulo, dato.Autor, dato.Año, dato.Editorial);
            }
            else if (BD.TablaAudioLibros.Contains(dato.Isbn))
            {
                AudioLibroDato audioDato = (AudioLibroDato)BD.TablaAudioLibros[dato.Isbn];

                documento = new AudioLibro(dato.Isbn, dato.Titulo, dato.Autor, dato.Año, dato.Editorial, audioDato.Formato, audioDato.Duracion);
            }

            if (Enum.TryParse(dato.Estado, out EstadoActivoInactivo estadoEnum))
            {
                documento.Estado = estadoEnum;
            }
            return documento;
        }

        public static DocumentoDato DocumentoADocumentoDato(Documento doc)
        {
            return new DocumentoDato(doc.ISBN, doc.Titulo, doc.Autor, doc.Año, doc.Editorial, doc.Estado.ToString());
        }


        public static LibroPapel LibroPapelDatoALibroPapel(LibroPapelDato dato)
        {
            LibroPapel libro = null;
            if (BD.TablaLibrosPapel.Contains(dato.Id))
            {
                DocumentoDato docDato = (DocumentoDato)BD.TablaDocumentos[dato.Id];
                libro = new LibroPapel(docDato.Isbn, docDato.Titulo, docDato.Autor, docDato.Año, docDato.Editorial);

                if (Enum.TryParse(docDato.Estado, out EstadoActivoInactivo estadoEnum))
                {
                    libro.Estado = estadoEnum;
                }
            }
            return libro;
        }

        public static LibroPapelDato LibroPapelALibroPapelDato(LibroPapel libroPapel)
        {
            return new LibroPapelDato(libroPapel.ISBN);
        }


        public static Prestamo PrestamoDatoAPrestamo(PrestamoDato dato)
        {
            UsuarioDato uDato = (UsuarioDato)BD.TablaUsuarios[dato.DniUsuario];
            Usuario usuario = UsuarioDatoAUsuario(uDato);

            PersonalBibliotecaDato pDato = (PersonalBibliotecaDato)BD.TablaPersonal[dato.IdPersonal];
            PersonalSala personal = (PersonalSala)PersonalBilbiotecaDatoAPersonalBilbioteca(pDato);

            EstadoPrestamo estadoEnum = (EstadoPrestamo)Enum.Parse(typeof(EstadoPrestamo), dato.Estado);

            return new Prestamo(dato.Id, dato.FechaInicio, dato.FechaFin, estadoEnum, usuario, personal, new List<Ejemplar>());
        }

        public static PrestamoDato PrestamoAPrestamoDato(Prestamo prestamo)
        {
            return new PrestamoDato(prestamo.ID, prestamo.FechaInicio, prestamo.FechaFin, prestamo.Estado.ToString(), prestamo.Usuario.DNI, prestamo.PersonalSala.IdUsuario);
        }


        public static PersonalBiblioteca PersonalBilbiotecaDatoAPersonalBilbioteca(PersonalBibliotecaDato dato)
        {
            switch (dato.Rol.ToLower())
            {
                case "adquisicion":
                    return new PersonalAdquisicion(dato.Id, dato.Nombre, dato.Contraseña);
                case "sala":
                    return new PersonalSala(dato.Id, dato.Nombre, dato.Contraseña);
                default:
                    return null;
            }
        }

        public static PersonalBibliotecaDato PersonalBilbiotecaAPersonalBilbiotecaDato(PersonalBiblioteca personalBiblioteca)
        {
            string rol;
            if (personalBiblioteca is PersonalAdquisicion)
            {
                rol = "adquisicion";
            }
            else
            {
                rol = "sala";
            }
            return new PersonalBibliotecaDato(personalBiblioteca.IdUsuario, personalBiblioteca.Nombre, personalBiblioteca.Contraseña, rol);
        }


        public static UsuarioDato UsuarioAUsuarioDato(Usuario usuario)
        {
            return new UsuarioDato(usuario.DNI, usuario.Nombre, usuario.Estado.ToString());
        }

        public static Usuario UsuarioDatoAUsuario(UsuarioDato dato)
        {
            Usuario u = new Usuario(dato.Id, dato.Nombre);

            if (Enum.TryParse(dato.Estado, out EstadoActivoInactivo estadoEnum))
            {
                u.Estado = estadoEnum;
            }
            return u;
        }
    }
}
