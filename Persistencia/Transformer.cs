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

            return new Ejemplar(dato, dato.Codigo, dato.Trabajador); 

        }

        public static EjemplarDato EjemplarAEjemplarDato(Ejemplar id)

        {

            return new EjemplarDato(new ClaveEjemplar(id.Documento.ISBN,id.Codigo),id.Estado.ToString(),id.PersonalAdquisicion.NSS); 

        }

        public static AudioLibro AudioLibroDatoAAudioLibro(AudioLibroDato audioLibro)

        {

            return new AudioLibro(audioLibro.Durecion,audioLibro.Formato); 

        }

        public static AudioLibroDato AudioLibroAAudioLibroDato(AudioLibro audioLibro)

        {

            return new AudioLibroDato(); 

        }
      /*  public static Documento DocumentoDatoADocumento(DocumentoDato documentoDato)

        {

            return new Documento(documentoDato.Isbn, documentoDato.Titulo, documentoDato.Autor, documentoDato.Año, documentoDato.Editorial);

        }*/
        public static DocumentoDato DocumentoADocumentoDato(Documento documento)

        {

            return new DocumentoDato(//poner cosas); 

        }

        public static LibroPapel LibroPapelDatoALibroPapel(LibroPapelDato libroPapelDato)

        {

            return new LibroPapel(//poner cosas); 

        }

        public static LibroPapelDato LibroPapelALibroPapelDato(LibroPapel libroPapel)

        {

            return new LibroPapelDato(//poner cosas); 

        }

        public static Prestamo PrestamoDatoAPrestamo(PrestamoDato prestamoDato)

        {

            return new Prestamo(prestamoDato.Id,prestamoDato.FechaInicio,prestamoDato.FechaFin,prestamoDato.Estado,prestamoDato.DniUsuario,prestamoDato.NssTrabajador,new List<Ejemplar>()); 

        }

        public static PrestamoDato PrestamoAPrestamoDato(Prestamo prestamo)

        {

            return new PrestamoDato(//poner cosas); 

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

    }

}







