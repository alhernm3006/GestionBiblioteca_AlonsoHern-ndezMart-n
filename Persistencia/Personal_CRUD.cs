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
        public bool Insertar(PersonalBiblioteca personal)
        {
            if (!BD.TablaPersonal.Contains(personal.IdUsuario))
            {
                BD.TablaPersonal.Add(Transformer.PersonalBilbiotecaAPersonalBilbiotecaDato(personal));
                return true;
            }
            return false;
        }

        public PersonalBiblioteca Buscar(string idUsuario)
        {
            if (BD.TablaPersonal.Contains(idUsuario))
            {
                PersonalBibliotecaDato dato = (PersonalBibliotecaDato)BD.TablaPersonal[idUsuario];
                return Transformer.PersonalBilbiotecaDatoAPersonalBilbioteca(dato);
            }
            return null;
        }

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
