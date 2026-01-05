using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class Ejemplar_CRUD
    {
        // PRE: El objeto 'ejemplar' no debe ser nulo.
        // POS: Devuelve true si el ejemplar se inserta correctamente en la base de datos.
        //      Devuelve false si ya existe un ejemplar con la misma clave .
        public bool Insertar(Ejemplar ejemplar)
        {
            ClaveEjemplar clave = new ClaveEjemplar(ejemplar.Documento.ISBN, ejemplar.Codigo);

            if (!BD.TablaEjemplares.Contains(clave))
            {
                BD.TablaEjemplares.Add(Transformer.EjemplarAEjemplarDato(ejemplar));
                return true;
            }
            return false;
        }

        // PRE: 'isbn' y 'codigo' no deben ser nulos.
        // POS: Devuelve el objeto Ejemplar si existe en la base de datos.
        //      Devuelve null si no se encuentra la clave compuesta por ISBN y código.
        public Ejemplar Buscar(string isbn, string codigo)
        {
            ClaveEjemplar clave = new ClaveEjemplar(isbn, codigo);
            if (BD.TablaEjemplares.Contains(clave))
            {
                EjemplarDato dato = (EjemplarDato)BD.TablaEjemplares[clave];
                return Transformer.EjemplarDatoAEjemplar(dato);
            }
            return null;
        }

        // PRE: 'isbn' y 'codigo' no deben ser nulos.
        // POS: Devuelve true si el ejemplar existe en la base de datos.
        //      Si el ejemplar existe y su estado NO es "prestado", cambia su estado a "archivado" .
        //      Devuelve false si el ejemplar no existe.
        public bool Eliminar(string isbn, string codigo)
        {
            ClaveEjemplar clave = new ClaveEjemplar(isbn, codigo);

            if (BD.TablaEjemplares.Contains(clave))
            {
                EjemplarDato dato = (EjemplarDato)BD.TablaEjemplares[clave];
                if (dato.Estado != "prestado")
                {
                    dato.Estado = "archivado";
                }
                return true;
            }
            return false;
        }

        // PRE: 'isbn' no debe ser nulo.
        // POS: Devuelve una lista con todos los ejemplares asociados al ISBN proporcionado.
        //      Si no hay ejemplares, devuelve una lista vacía.
        public List<Ejemplar> ListarEjemplares(string isbn)
        {
            List<Ejemplar> resultados = new List<Ejemplar>();

            foreach (var item in BD.TablaEjemplares)
            {
                EjemplarDato eDato = (EjemplarDato)item;

                if (eDato.Isbn == isbn)
                {
                    resultados.Add(Transformer.EjemplarDatoAEjemplar(eDato));
                }
            }
            return resultados;
        }

        // PRE: 'isbn' y 'codigo' no deben ser nulos.
        // POS: Devuelve true si encuentra el ejemplar y actualiza su estado al nuevo valor indicado.
        //      Devuelve false si el ejemplar no existe.
        public bool ActualizarEstado(string isbn, string codigo, EstadoEjemplar nuevoEstado)
        {
            ClaveEjemplar clave = new ClaveEjemplar(isbn, codigo);

            if (BD.TablaEjemplares.Contains(clave))
            {
                EjemplarDato eDato = (EjemplarDato)BD.TablaEjemplares[clave];
                eDato.Estado = nuevoEstado.ToString();
                return true;
            }
            return false;
        }
    }
}
