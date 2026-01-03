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


        public void Insertar(Ejemplar ejemplar)
        {
            ClaveEjemplar clave = new ClaveEjemplar(ejemplar.Documento.ISBN, ejemplar.Codigo);

            if (BD.TablaEjemplares.Contains(clave))
            {
                throw new Exception("Ya existe este ejemplar.");
            }
            else
            {
                BD.TablaEjemplares.Add(Transformer.EjemplarAEjemplarDato(ejemplar));
            }
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
                EjemplarDato dato = (EjemplarDato)BD.TablaEjemplares[clave];
                if (dato.Estado == "prestado")
                {
                    throw new Exception("No se puede eliminar un ejemplar que está prestado actualmente.");
                }
                else
                {
                    dato.Estado = "archivado";
                }
            }
            else
            {
                throw new Exception("El ejemplar no existe.");
            }
        }

        public List<Ejemplar> ListarPorDocumento(string isbn)
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

        public void ActualizarEstado(string isbn, string codigo, EstadoEjemplar nuevoEstado)
        {
            ClaveEjemplar clave = new ClaveEjemplar(isbn, codigo);

            if (BD.TablaEjemplares.Contains(clave))
            {
                EjemplarDato eDato = (EjemplarDato)BD.TablaEjemplares[clave];
                eDato.Estado = nuevoEstado.ToString();
            }
            else
            {
                throw new Exception("No se puede actualizar el estado: El ejemplar no existe.");
            }
        }

        

    }
}
