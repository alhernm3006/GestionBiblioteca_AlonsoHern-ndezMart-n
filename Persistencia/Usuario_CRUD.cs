using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class Usuario_CRUD
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
                return Transformer.UsuarioDatoAUsuario(uDato);
            }
            return null;
        }

        public void Eliminar(string dni)
        {
            if (BD.TablaUsuarios.Contains(dni))
            {
                BD.TablaUsuarios.Remove(dni);
            }
        }
    }
}
