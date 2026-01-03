using ModeloDominio;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LógicaNegocio
{
    public class Admin
    {
        Personal_CRUD p=new Personal_CRUD();
        Ejemplar_CRUD ejemplarCRUD=new Ejemplar_CRUD();
        Libro_CRUD libroCRUD=new Libro_CRUD();
        AudioLibro_CRUD audioCRUD=new AudioLibro_CRUD();
        public Admin() {

           
        }

        public void añadirtrabajador(ModeloDominio.PersonalBiblioteca g){ p.Insertar(g); }
        public bool altaDocumento(Documento doc)
        {
            try
            {
                doc.Estado = EstadoActivoInactivo.activo;
                if (doc is LibroPapel libro)
                {
                    libroCRUD.Insertar(libro);
                }
                else if (doc is AudioLibro audio)
                {
                    audioCRUD.Insertar(audio);
                }
                else
                {
                    return false; // Tipo desconocido
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool altaEjemplar(Ejemplar ej)
        {
            try
            {
                ejemplarCRUD.Insertar(ej);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
