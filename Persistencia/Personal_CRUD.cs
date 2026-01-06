using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class Personal_CRUD
    {
        // PRE: El objeto 'personal' no debe ser nulo.
        // POS: Devuelve true si el personal se inserta correctamente en la base de datos.
        //      Devuelve false si ya existe un miembro del personal con el mismo IdUsuario.
        public bool Insertar(PersonalBiblioteca personal)
        {
            if (!BD.TablaPersonal.Contains(personal.IdPersonal))
            {
                BD.TablaPersonal.Add(Transformer.PersonalBilbiotecaAPersonalBilbiotecaDato(personal));
                return true;
            }
            return false;
        }

        // PRE: 'idUsuario' no debe ser nulo ni vacío.
        // POS: Devuelve el objeto PersonalBiblioteca correspondiente al ID si existe en la base de datos.
        //      Devuelve null si no se encuentra ningún personal con ese ID.
        public PersonalBiblioteca Buscar(string idUsuario)
        {
            if (BD.TablaPersonal.Contains(idUsuario))
            {
                PersonalBibliotecaDato dato = (PersonalBibliotecaDato)BD.TablaPersonal[idUsuario];
                return Transformer.PersonalBilbiotecaDatoAPersonalBilbioteca(dato);
            }
            return null;
        }

        // PRE: 'nss' no debe ser nulo.
        // POS: Devuelve true si encuentra el identificador y elimina físicamente el registro de la base de datos.
        //      Devuelve false si el identificador no existe en la tabla.
        public bool Eliminar(string nss)
        {
            if (BD.TablaPersonal.Contains(nss))
            {
                BD.TablaPersonal.Remove(nss);
                return true;
            }
            return false;
        }
    }
}
