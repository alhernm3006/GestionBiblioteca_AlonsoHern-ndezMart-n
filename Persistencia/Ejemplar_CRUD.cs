using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class Ejemplar_CRUD
    {
        public void Insertar(Ejemplar ejemplar)
        {
            ClaveEjemplar clave = new ClaveEjemplar(ejemplar.Documento.ISBN, ejemplar.Codigo);

            if (BD.TablaEjemplares.Contains(clave))
                throw new Exception("Ya existe este ejemplar.");

            BD.TablaEjemplares.Add(Transformer.EjemplarAEjemplarDato(ejemplar));
        }

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

        public void Eliminar(string isbn, string codigo)
        {
            ClaveEjemplar clave = new ClaveEjemplar(isbn, codigo);

            if (BD.TablaEjemplares.Contains(clave))
            {
                // Opcional: Verificar si el libro está prestado antes de borrarlo
                EjemplarDato dato = (EjemplarDato)BD.TablaEjemplares[clave];
                if (dato.Estado == "prestado")
                {
                    throw new Exception("No se puede eliminar un ejemplar que está prestado actualmente.");
                }

                BD.TablaEjemplares.Remove(clave);
            }
            else
            {
                throw new Exception("El ejemplar no existe.");
            }
        }
    }
}
