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
        public Admin() {

           
        }

        public void añadirtrabajador(ModeloDominio.PersonalBiblioteca g){ p.Insertar(g); }
    }
}
