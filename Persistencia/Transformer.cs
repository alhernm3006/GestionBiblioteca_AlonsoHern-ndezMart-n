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

            // 1. Recuperar el Documento completo usando el ISBN
            // Primero obtenemos los datos crudos de la tabla
            DocumentoDato docDato = (DocumentoDato)BD.TablaDocumentos[dato.Isbn];
            // Luego lo convertimos al objeto de dominio (usando el método que corregimos antes)
            Documento documento = DocumentoDatoADocumento(docDato);

            // 2. Recuperar el PersonalAdquisicion usando el NSS
            // En EjemplarDato el campo se llama 'Nss', no 'Trabajador'
            PersonalBibliotecaDato perDato = (PersonalBibliotecaDato)BD.TablaPersonal[dato.Nss];
            // Convertimos y aseguramos que sea del tipo correcto (PersonalAdquisicion)
            PersonalAdquisicion trabajador = (PersonalAdquisicion)PersonalBilbiotecaDatoAPersonalBilbioteca(perDato);

            // 3. Crear el Ejemplar
            Ejemplar ejemplar = new Ejemplar(documento, dato.Codigo, trabajador);

            // 4. Restaurar el Estado
            // El constructor lo pone en "archivado" por defecto, así que lo sobreescribimos con el valor real
            if (Enum.TryParse(dato.Estado, out EstadoEjemplar estadoEnum))
            {
                ejemplar.Estado = estadoEnum;
            }

            return ejemplar;

        }

        public static EjemplarDato EjemplarAEjemplarDato(Ejemplar id)

        {

            return new EjemplarDato(new ClaveEjemplar(id.Documento.ISBN,id.Codigo),id.Estado.ToString(),id.PersonalAdquisicion.NSS); 

        }

        public static AudioLibro AudioLibroDatoAAudioLibro(AudioLibroDato audioLibrodato)

        {

            if (audioLibrodato == null) return null;

            // 1. Recuperar los datos generales (Título, Autor, etc.) de la TablaDocumentos
            // Usamos el Id del audioLibro (que es el ISBN) para buscar.
            if (!BD.TablaDocumentos.Contains(audioLibrodato.Id))
            {
                throw new Exception($"No se encontró el documento base para el audiolibro {audioLibrodato.Id}");
            }

            DocumentoDato docDato = (DocumentoDato)BD.TablaDocumentos[audioLibrodato.Id];

            // 2. Crear el objeto AudioLibro combinando ambos datos
            AudioLibro audio = new AudioLibro(
                docDato.Isbn,       // Del DocumentoDato
                docDato.Titulo,     // Del DocumentoDato
                docDato.Autor,      // Del DocumentoDato
                docDato.Año,        // Del DocumentoDato
                docDato.Editorial,  // Del DocumentoDato
                audioLibrodato.Formato,   // Del AudioLibroDato
                audioLibrodato.Duracion   // Del AudioLibroDato (ojo con el nombre de la propiedad en tu clase)
            );

            // 3. Restaurar el estado
            if (Enum.TryParse(docDato.Estado, out EstadoActivoInactivo estadoEnum))
            {
                audio.Estado = estadoEnum;
            }

            return audio;

        }

        public static AudioLibroDato AudioLibroAAudioLibroDato(AudioLibro audioLibro)

        {

            return new AudioLibroDato(audioLibro.ISBN, audioLibro.Formato, audioLibro.Duracion);

        }


       public static Documento DocumentoDatoADocumento(DocumentoDato documentoDato)

        {

            // 1. Recuperar el estado (común a todos)
            EstadoActivoInactivo estadoEnum = EstadoActivoInactivo.inactivo; // Valor por defecto
            Enum.TryParse(documentoDato.Estado, out estadoEnum);

            // 2. Comprobar si es un Libro en Papel
            if (BD.TablaLibrosPapel.Contains(documentoDato.Isbn))
            {
                // Creamos el LibroPapel con los datos básicos
                LibroPapel libro = new LibroPapel(
                    documentoDato.Isbn,
                    documentoDato.Titulo,
                    documentoDato.Autor,
                    documentoDato.Año,
                    documentoDato.Editorial
                );
                libro.Estado = estadoEnum;
                return libro;
            }
            // 3. Comprobar si es un AudioLibro
            else if (BD.TablaAudioLibros.Contains(documentoDato.Isbn))
            {
                // Para el AudioLibro necesitamos recuperar los datos extra (Duración y Formato)
                AudioLibroDato audioDato = (AudioLibroDato)BD.TablaAudioLibros[documentoDato.Isbn];

                AudioLibro audio = new AudioLibro(
                    documentoDato.Isbn,
                    documentoDato.Titulo,
                    documentoDato.Autor,
                    documentoDato.Año,
                    documentoDato.Editorial,
                    audioDato.Formato,
                    audioDato.Duracion
                );
                audio.Estado = estadoEnum;
                return audio;
            }

            return null; // O lanzar una excepción si no se encuentra el tipo

        }
        public static DocumentoDato DocumentoADocumentoDato(Documento doc)

        {

            return new DocumentoDato(doc.ISBN, doc.Titulo, doc.Autor, doc.Año, doc.Editorial);

        }

        public static LibroPapel LibroPapelDatoALibroPapel(LibroPapelDato libroPapelDato)

        {

            // 1. Recuperar los datos generales (Título, Autor, etc.) de la TablaDocumentos usando el ISBN
            // El 'Id' del LibroPapelDato es el ISBN.
            DocumentoDato docDato = (DocumentoDato)BD.TablaDocumentos[libroPapelDato.Id];

            // 2. Crear el objeto LibroPapel usando los datos recuperados
            LibroPapel libro = new LibroPapel(
                docDato.Isbn,
                docDato.Titulo,
                docDato.Autor,
                docDato.Año,
                docDato.Editorial
            );

            // 3. Restaurar el estado (Activo/Inactivo)
            // El constructor por defecto lo pone "inactivo", así que debemos poner el que tenía en la BD.
            if (Enum.TryParse(docDato.Estado, out EstadoActivoInactivo estadoEnum))
            {
                libro.Estado = estadoEnum;
            }

            return libro;

        }

        public static LibroPapelDato LibroPapelALibroPapelDato(LibroPapel libroPapel)

        {

            return new LibroPapelDato(libroPapel.ISBN); 

        }

        public static Prestamo PrestamoDatoAPrestamo(PrestamoDato prestamoDato)

        {

            EstadoPrestamo estadoEnum = (EstadoPrestamo)Enum.Parse(typeof(EstadoPrestamo), prestamoDato.Estado);

            // 2. Recuperar el objeto Usuario completo usando el DNI
            // (Nota: Necesitas tener implementado el método UsuarioDatoAUsuario o crearlo aquí)
            UsuarioDato uDato = (UsuarioDato)BD.TablaUsuarios[prestamoDato.DniUsuario];
            Usuario usuario = new Usuario(uDato.Id, uDato.Nombre); // O usa Transformer.UsuarioDatoAUsuario(uDato) si ya lo hiciste

            // 3. Recuperar el trabajador (PersonalSala) usando el NSS
            PersonalBibliotecaDato pDato = (PersonalBibliotecaDato)BD.TablaPersonal[prestamoDato.NssTrabajador];
            PersonalSala personal = (PersonalSala)PersonalBilbiotecaDatoAPersonalBilbioteca(pDato);

            // 4. Crear el Préstamo pasando los OBJETOS, no los strings
            return new Prestamo(
                prestamoDato.Id,
                prestamoDato.FechaInicio,
                prestamoDato.FechaFin,
                estadoEnum,
                usuario,   // Pasamos el objeto Usuario recuperado
                personal,  // Pasamos el objeto PersonalSala recuperado
                new List<Ejemplar>() // Lista vacía por ahora (deberías rellenarla buscando en TablaPrestamosEjemplares si es necesario)
            );
        }

        public static PrestamoDato PrestamoAPrestamoDato(Prestamo prestamo)

        {

            return new PrestamoDato(prestamo.ID,prestamo.FechaInicio,prestamo.FechaFin,prestamo.Estado.ToString(),prestamo.Usuario.DNI,prestamo.PersonalSala.NSS); 

        }

        public static PersonalBiblioteca PersonalBilbiotecaDatoAPersonalBilbioteca(PersonalBibliotecaDato dato)
        {
            switch (dato.Rol.ToLower())
            {
                case "adquisicion":
                    return new PersonalAdquisicion(dato.Id, dato.Usuario);
                case "sala":
                    return new PersonalSala(dato.Id, dato.Usuario); // El constructor de PersonalSala toma 'nombre' que es el 'usuario' en la base
                default:
                    throw new ArgumentException("Rol de PersonalBibliotecaDato no reconocido.");
            }
        }

        public static PersonalBibliotecaDato PersonalBilbiotecaAPersonalBilbiotecaDato(PersonalBiblioteca personalBiblioteca)
        {
            string rol;
            if (personalBiblioteca is PersonalAdquisicion)
            {
                rol = "adquisicion";
            }
            else if (personalBiblioteca is PersonalSala)
            {
                rol = "sala";
            }
            else
            {
                throw new ArgumentException("Rol de PersonalBiblioteca no reconocido.");
            }

            return new PersonalBibliotecaDato(personalBiblioteca.NSS, personalBiblioteca.Usuario, rol);
        }

        internal static UsuarioDato UsuarioAUsuarioDato(Usuario usuario)
        {
            if (usuario == null) return null;
            return new UsuarioDato(usuario.DNI, usuario.Nombre, usuario.Estado.ToString());
        }
     
            public static Usuario UsuarioDatoAUsuario(UsuarioDato dato)
        {
            if (dato == null) return null;
            Usuario u = new Usuario(dato.Id, dato.Nombre); 
            
            if (Enum.TryParse(dato.Estado, out EstadoActivoInactivo estadoEnum))
            {
                u.Estado = estadoEnum;
            }
            return u;
        }
    }

}







