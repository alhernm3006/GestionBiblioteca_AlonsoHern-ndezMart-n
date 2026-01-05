using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class UsuarioDato: Entity<String>
    {
        private String nombre;
        private String estado;

        // PRE: 'dni' debe ser string. 'nombre' y 'estado' deben ser string.
        // POS: Crea una nuevo UsuarioDato con identificador DNI. Nombre y estado.
        public UsuarioDato(String dni, String nombre, String estado) : base(dni)
        {
            
            this.nombre = nombre;
           
            this.estado = estado;
        }

        public String Nombre
        {
            // POS: Devuelve el nombre del usuario.
            get { return nombre; }
            // POS: Asigna un nuevo valor al nombre del usuario.
            set { nombre = value; }
        }

        public  String Estado {
            // POS: Devuelve el estado del usuario
            get { return estado; } 
            // POS: Asigna un nuevo valor al estado del usuario.
            set { estado = value; } 
        }
    }
}
