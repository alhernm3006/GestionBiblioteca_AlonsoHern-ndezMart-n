using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class Usuario_CRUD
    {
        public void Insertar(Usuario usuario)
        {
            if (BD.TablaUsuarios.Contains(usuario.DNI))
            {
                throw new Exception("El usuario ya existe en la BD.");
            }
         
            UsuarioDato uDato = Transformer.UsuarioAUsuarioDato(usuario);
            BD.TablaUsuarios.Add(uDato);
        }

        public Usuario Buscar(string dni)
        {
            if (BD.TablaUsuarios.Contains(dni))
            {
                UsuarioDato uDato = (UsuarioDato)BD.TablaUsuarios[dni];

                // AGREGAR ESTA COMPROBACIÓN:
                // Si el usuario está inactivo, devolvemos null como si no existiera
                if (uDato.Estado == "inactivo")
                {
                    return null;
                }
                return Transformer.UsuarioDatoAUsuario(uDato);
            }
            return null;
        }

        public void Eliminar(string dni)
        {
            if (BD.TablaUsuarios.Contains(dni))
            {
                UsuarioDato uDato = (UsuarioDato)BD.TablaUsuarios[dni];
                uDato.Estado = "inactivo";
            }
        }
        public List<Usuario> ListarTodos()
        {
            List<Usuario> resultados = new List<Usuario>();

            // Iteramos sobre la tabla interna BD (accesible solo aquí en Persistencia)
            foreach (var item in BD.TablaUsuarios)
            {
                // Convertimos el dato de persistencia a objeto de dominio
                UsuarioDato uDato = (UsuarioDato)item;
                resultados.Add(Transformer.UsuarioDatoAUsuario(uDato));
            }

            return resultados;
        }
    }
}
