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
        public void Insertar(PersonalBiblioteca personal)
        {
            if (BD.TablaPersonal.Contains(personal.NSS))
                throw new Exception("El personal ya existe.");

            BD.TablaPersonal.Add(Transformer.PersonalBilbiotecaAPersonalBilbiotecaDato(personal));
        }

        public PersonalBiblioteca Buscar(string nss)
        {
            if (BD.TablaPersonal.Contains(nss))
            {
                PersonalBibliotecaDato dato = (PersonalBibliotecaDato)BD.TablaPersonal[nss];
                return Transformer.PersonalBilbiotecaDatoAPersonalBilbioteca(dato);
            }
            return null;
        }
        public void Eliminar(string nss)
        {
            if (BD.TablaPersonal.Contains(nss))
            {
                BD.TablaPersonal.Remove(nss);
            }
            else
            {
                throw new Exception("El personal con ese NSS no existe.");
            }
        }
    }
}
