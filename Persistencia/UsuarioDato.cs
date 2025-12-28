using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class UsuarioDato: Entity<String>
    {
        private String nombre;
        private String estado;

        public UsuarioDato(String dni, String nombre, String estado) : base(dni)
        {
            this.nombre = nombre;
            this.estado = estado;
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public  String Estado {
            get { return estado; } 
            set { estado = value; } 
        }

    
    }
}
