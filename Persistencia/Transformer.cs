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

        // PRE: 'dato' no debe ser nulo. El ISBN del documento y el ID del personal referenciados en 'dato' deben existir en la base de datos.
        // POS: Devuelve una instancia completa de Ejemplar reconstruida a partir de los datos.
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

        // PRE: 'ejemplar' no debe ser nulo.
        // POS: Devuelve un objeto EjemplarDato con la información necesaria para persistir el ejemplar.
        public static EjemplarDato EjemplarAEjemplarDato(Ejemplar ejemplar)
        {
            return new EjemplarDato(new ClaveEjemplar(ejemplar.Documento.ISBN, ejemplar.Codigo), ejemplar.Estado.ToString(), ejemplar.PersonalAdquisicion.IdPersonal);
        }

        // PRE: 'dato' no debe ser nulo.
        // POS: Devuelve un objeto AudioLibro si el ID existe en la tabla de documentos y se puede reconstruir.
        //      Devuelve null si el ID no se encuentra en BD.TablaDocumentos.
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

        // PRE: 'audioLibro' no debe ser nulo.
        // POS: Devuelve un objeto AudioLibroDato con la información específica del audiolibro para su persistencia.
        public static AudioLibroDato AudioLibroAAudioLibroDato(AudioLibro audioLibro)
        {
            return new AudioLibroDato(audioLibro.ISBN, audioLibro.Formato, audioLibro.Duracion);
        }

        // PRE: 'dato' no debe ser nulo.
        // POS: Devuelve un objeto Documentoque puede ser Libro o AudioLibro dependiendo de en qué tabla específica se encuentre el ISBN.
        //      Asigna el estado correspondiente.
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

        // PRE: 'doc' no debe ser nulo.
        // POS: Devuelve un objeto DocumentoDato con la información general del documento.
        public static DocumentoDato DocumentoADocumentoDato(Documento doc)
        {
            return new DocumentoDato(doc.ISBN, doc.Titulo, doc.Autor, doc.Año, doc.Editorial, doc.Estado.ToString());
        }

        // PRE: 'dato' no debe ser nulo.
        // POS: Devuelve un objeto LibroPapel reconstruido si el ID existe en la tabla de libros papel.
        //      Devuelve null si no se encuentra en dicha tabla.
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

        // PRE: 'libroPapel' no debe ser nulo.
        // POS: Devuelve un objeto LibroPapelDato con el ISBN del libro.
        public static LibroPapelDato LibroPapelALibroPapelDato(LibroPapel libroPapel)
        {
            return new LibroPapelDato(libroPapel.ISBN);
        }

        // PRE: 'dato' no debe ser nulo. El DNI del usuario y el ID del personal deben existir en la base de datos.
        // POS: Devuelve un objeto Prestamo reconstruido, incluyendo el Usuario, el Personal y el Estado parseado.
        //      La lista de ejemplares se inicializa vacía.
        public static Prestamo PrestamoDatoAPrestamo(PrestamoDato dato)
        {
            UsuarioDato uDato = (UsuarioDato)BD.TablaUsuarios[dato.DniUsuario];
            Usuario usuario = UsuarioDatoAUsuario(uDato);

            PersonalBibliotecaDato pDato = (PersonalBibliotecaDato)BD.TablaPersonal[dato.IdPersonal];
            PersonalSala personal = (PersonalSala)PersonalBilbiotecaDatoAPersonalBilbioteca(pDato);

            EstadoPrestamo estadoEnum = (EstadoPrestamo)Enum.Parse(typeof(EstadoPrestamo), dato.Estado);

            return new Prestamo(dato.Id, dato.FechaInicio, dato.FechaFin, estadoEnum, usuario, personal, new List<Ejemplar>());
        }


        // PRE: 'prestamo' no debe ser nulo.
        // POS: Devuelve un objeto PrestamoDato con la información necesaria para persistir el préstamo.
        public static PrestamoDato PrestamoAPrestamoDato(Prestamo prestamo)
        {
            return new PrestamoDato(prestamo.ID, prestamo.FechaInicio, prestamo.FechaFin, prestamo.Estado.ToString(), prestamo.Usuario.DNI, prestamo.PersonalSala.IdPersonal);
        }

        // PRE: 'dato' no debe ser nulo. 'dato.Rol' debe ser "adquisicion" o "sala" .
        // POS: Devuelve una instancia de PersonalAdquisicion o PersonalSala según el rol.
        //      Devuelve null si el rol no es reconocido.
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

        // PRE: 'personalBiblioteca' no debe ser nulo.
        // POS: Devuelve un objeto PersonalBibliotecaDato con el rol asignado ("adquisicion" o "sala") según el tipo de instancia.
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
            return new PersonalBibliotecaDato(personalBiblioteca.IdPersonal, personalBiblioteca.Nombre, personalBiblioteca.Contraseña, rol);
        }

        // PRE: 'usuario' no debe ser nulo.
        // POS: Devuelve un objeto UsuarioDato para su persistencia.
        public static UsuarioDato UsuarioAUsuarioDato(Usuario usuario)
        {
            return new UsuarioDato(usuario.DNI, usuario.Nombre, usuario.Estado.ToString());
        }

        // PRE: 'dato' no debe ser nulo.
        // POS: Devuelve un objeto Usuario reconstruido con su estado correspondiente.
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
