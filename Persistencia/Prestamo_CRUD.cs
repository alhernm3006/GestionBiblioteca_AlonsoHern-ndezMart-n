using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class Prestamo_CRUD
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

                // AQUÍ deberías rellenar la lista prestamo.Ejemplares buscando en 
                // BD.TablaPrestamosEjemplares aquellos que coincidan con el idPrestamo.
                // Como Tabla es una colección genérica, tendrías que iterar (poco eficiente pero funcional)

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
    }
}
