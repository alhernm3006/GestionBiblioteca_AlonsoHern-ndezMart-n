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
        // PRE: El objeto 'prestamo' no debe ser nulo. .
        // POS: Devuelve true si el préstamo se inserta correctamente en la base de datos.
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

        // PRE: 'idPrestamo' no debe ser nulo.
        // POS: Devuelve el objeto Prestamo completo si existe en la base de datos
        //      Devuelve null si el préstamo no existe.
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

        // PRE: 'idPrestamo' no debe ser nulo.
        // POS: Elimina el préstamo de la tabla principal.
        public void Eliminar(string idPrestamo)
        {
            if (!BD.TablaPrestamos.Contains(idPrestamo))
            {
                throw new Exception("El préstamo no existe.");
            }


            var lineasABorrar = new List<Prestamo_EjemplarDato>();

            foreach (var item in BD.TablaPrestamosEjemplares)
            {
              
                if (item.Id.Id == idPrestamo)
                {
                    lineasABorrar.Add((Prestamo_EjemplarDato)item);
                }
            }

          
            foreach (var linea in lineasABorrar)
            {
                BD.TablaPrestamosEjemplares.Remove(linea.Id);
            }

          
            BD.TablaPrestamos.Remove(idPrestamo);
        }

        // PRE: 
        // POS: Devuelve una lista con todos los préstamos almacenados en el sistema.
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

        // PRE: 'dni' no debe ser nulo.
        // POS: Devuelve una lista de todos los préstamos asociados al usuario con el DNI especificado.
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

        // PRE: 'isbn' y 'codigo' no deben ser nulos.
        // POS: Busca en las líneas de detalle si el ejemplar pertenece a un préstamo activo.
        //      Si lo encuentra, actualiza la fecha de devolución real, a la fecha actual.

        public void RegistrarDevolucionEjemplar(string isbn, string codigo)
        {
            
            foreach (var item in BD.TablaPrestamosEjemplares)
            {
                Prestamo_EjemplarDato peDato = (Prestamo_EjemplarDato)item;

               
                if (peDato.Id.Ejemplar.ISBN == isbn && peDato.Id.Ejemplar.Codigo == codigo)
                {
                  
                    if (BD.TablaPrestamos.Contains(peDato.Id.Id))
                    {
                        PrestamoDato pDato = (PrestamoDato)BD.TablaPrestamos[peDato.Id.Id];

                        if (pDato.Estado == EstadoPrestamo.enProceso.ToString())
                        {
                           
                            peDato.FechaDevolucion = DateTime.Now;

                          
                            return;
                        }
                    }
                }
            }
        }
    }
}
