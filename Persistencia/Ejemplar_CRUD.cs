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
