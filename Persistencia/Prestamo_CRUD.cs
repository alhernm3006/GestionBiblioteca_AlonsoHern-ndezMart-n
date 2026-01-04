using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class Prestamo_CRUD
    {
        public bool Insertar(Prestamo prestamo)
        {
            if (!BD.TablaPrestamos.Contains(prestamo.ID))
            {
                BD.TablaPrestamos.Add(Transformer.PrestamoAPrestamoDato(prestamo));

                foreach (Ejemplar ej in prestamo.Ejemplares)
                {
                    ClaveEjemplar cEjemplar = new ClaveEjemplar(ej.Documento.ISBN, ej.Codigo);
                    ClavePrestamoEjemplar cPrestamo = new ClavePrestamoEjemplar(prestamo.ID, cEjemplar);

                    Prestamo_EjemplarDato relacion = new Prestamo_EjemplarDato(cPrestamo, prestamo.FechaFin, prestamo.FechaFin);
                    BD.TablaPrestamosEjemplares.Add(relacion);
                }
                return true;
            }
            return false;
        }

        public Prestamo Buscar(string idPrestamo)
        {
            if (BD.TablaPrestamos.Contains(idPrestamo))
            {
                PrestamoDato dato = (PrestamoDato)BD.TablaPrestamos[idPrestamo];
                Prestamo prestamo = Transformer.PrestamoDatoAPrestamo(dato);

                foreach (var item in BD.TablaPrestamosEjemplares)
                {
                    Prestamo_EjemplarDato peDato = (Prestamo_EjemplarDato)item;
                    if (peDato.Id.Id == idPrestamo)
                    {
                        Ejemplar_CRUD eCRUD = new Ejemplar_CRUD();
                        Ejemplar ej = eCRUD.Buscar(peDato.Id.Ejemplar.ISBN, peDato.Id.Ejemplar.Codigo);
                        prestamo.Ejemplares.Add(ej);
                    }
                }
                return prestamo;
            }
            return null;
        }

        public void Eliminar(string idPrestamo)
        {
            if (!BD.TablaPrestamos.Contains(idPrestamo))
            {
                throw new Exception("El préstamo no existe.");
            }

            // 1. Borrar las líneas de detalle en TablaPrestamosEjemplares
            // Como no podemos modificar una colección mientras la recorremos con foreach,
            // primero buscamos los elementos a borrar y los guardamos en una lista temporal.

            var lineasABorrar = new List<Prestamo_EjemplarDato>();

            foreach (var item in BD.TablaPrestamosEjemplares)
            {
                // La clave compuesta tiene el Id del prestamo dentro
                if (item.Id.Id == idPrestamo)
                {
                    lineasABorrar.Add((Prestamo_EjemplarDato)item);
                }
            }

            // Ahora sí los borramos
            foreach (var linea in lineasABorrar)
            {
                BD.TablaPrestamosEjemplares.Remove(linea.Id);
            }

            // 2. Borrar el préstamo de la tabla principal
            BD.TablaPrestamos.Remove(idPrestamo);
        }

        public List<Prestamo> ListarTodos()
        {
            List<Prestamo> lista = new List<Prestamo>();
            foreach (var item in BD.TablaPrestamos)
            {
                PrestamoDato pDato = (PrestamoDato)item;
                lista.Add(this.Buscar(pDato.Id));
            }
            return lista;
        }

        public List<Prestamo> PrestamosUsuario(string dni)
        {
            List<Prestamo> lista = new List<Prestamo>();
            foreach (var item in BD.TablaPrestamos)
            {
                PrestamoDato pDato = (PrestamoDato)item;
                if (pDato.DniUsuario == dni)
                {
                    lista.Add(this.Buscar(pDato.Id));
                }
            }
            return lista;
        }

        public void RegistrarDevolucionEjemplar(string isbn, string codigo)
        {
            // Recorremos la tabla de relaciones Prestamo-Ejemplar
            foreach (var item in BD.TablaPrestamosEjemplares)
            {
                Prestamo_EjemplarDato peDato = (Prestamo_EjemplarDato)item;

                // 1. Buscamos coincidencias por ISBN y Código
                if (peDato.Id.Ejemplar.ISBN == isbn && peDato.Id.Ejemplar.Codigo == codigo)
                {
                    // 2. Verificamos que el préstamo padre exista y esté ACTIVO (enProceso)
                    // Esto es crucial porque el libro pudo prestarse anteriormente y esas líneas viejas no se tocan.
                    if (BD.TablaPrestamos.Contains(peDato.Id.Id))
                    {
                        PrestamoDato pDato = (PrestamoDato)BD.TablaPrestamos[peDato.Id.Id];

                        if (pDato.Estado == EstadoPrestamo.enProceso.ToString())
                        {
                            // 3. Establecemos la fecha de devolución real al momento actual
                            peDato.FechaDevolucion = DateTime.Now;

                            // Ya encontramos el préstamo activo para este libro, terminamos.
                            return;
                        }
                    }
                }
            }
        }
    }
}
