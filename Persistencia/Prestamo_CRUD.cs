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
        public void Insertar(Prestamo prestamo)
        {
            if (BD.TablaPrestamos.Contains(prestamo.ID))
                throw new Exception("El préstamo ya existe.");

            // 1. Guardar el Préstamo principal
            BD.TablaPrestamos.Add(Transformer.PrestamoAPrestamoDato(prestamo));

            // 2. Guardar las relaciones Préstamo-Ejemplar
            // Nota: Se asume que prestamo.Ejemplares tiene la lista de libros prestados
            foreach (Ejemplar ej in prestamo.Ejemplares)
            {
                ClaveEjemplar cEjemplar = new ClaveEjemplar(ej.Documento.ISBN, ej.Codigo);
                ClavePrestamoEjemplar cPrestamo = new ClavePrestamoEjemplar(prestamo.ID, cEjemplar);

                // Crear el dato de la relación (fechas se toman del préstamo)
                Prestamo_EjemplarDato relacion = new Prestamo_EjemplarDato(
                    cPrestamo,
                    prestamo.FechaFin, // Fecha prevista
                    prestamo.FechaFin  // Fecha devolución real (inicialmente igual o nula según lógica)
                );

                BD.TablaPrestamosEjemplares.Add(relacion);
            }
        }

        public Prestamo Buscar(string idPrestamo)
        {
            if (BD.TablaPrestamos.Contains(idPrestamo))
            {
                PrestamoDato dato = (PrestamoDato)BD.TablaPrestamos[idPrestamo];
                Prestamo prestamo = Transformer.PrestamoDatoAPrestamo(dato);

                // --- CORRECCIÓN: Rellenar la lista de ejemplares ---

                // Necesitamos Ejemplar_CRUD para recuperar el objeto Ejemplar completo
                Ejemplar_CRUD ejemplarCRUD = new Ejemplar_CRUD();

                // Recorremos la tabla intermedia (Prestamos-Ejemplares)
                foreach (var item in BD.TablaPrestamosEjemplares)
                {
                    Prestamo_EjemplarDato linea = (Prestamo_EjemplarDato)item;

                    // Si la línea coincide con el ID del préstamo actual
                    if (linea.Id.Id == idPrestamo)
                    {
                        // Extraemos las claves del ejemplar
                        string isbn = linea.Id.Ejemplar.ISBN;
                        string codigo = linea.Id.Ejemplar.Codigo;

                        // Buscamos el objeto Ejemplar real
                        Ejemplar ej = ejemplarCRUD.Buscar(isbn, codigo);

                        // Si existe, lo añadimos a la lista del préstamo
                        if (ej != null)
                        {
                            prestamo.Ejemplares.Add(ej);
                        }
                    }
                }
                // ---------------------------------------------------

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
                // Reutilizamos Buscar para que traiga los ejemplares ya cargados
                PrestamoDato pDato = (PrestamoDato)item;
                lista.Add(this.Buscar(pDato.Id));
            }
            return lista;
        }

        public List<Prestamo> ListarPorUsuario(string dni)
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
