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
        public bool Insertar(Usuario usuario)
        {
            if (!BD.TablaUsuarios.Contains(usuario.DNI))
            {
                UsuarioDato uDato = Transformer.UsuarioAUsuarioDato(usuario);
                BD.TablaUsuarios.Add(uDato);
                return true;
            }
            return false;
        }

        public Usuario Buscar(string dni)
        {
            if (BD.TablaUsuarios.Contains(dni))
            {
                UsuarioDato uDato = (UsuarioDato)BD.TablaUsuarios[dni];

                if (uDato.Estado != "inactivo")
                {
                    return Transformer.UsuarioDatoAUsuario(uDato);
                }
            }
            return null;
        }

        public bool Eliminar(string dni)
        {
            if (BD.TablaUsuarios.Contains(dni))
            {
                UsuarioDato uDato = (UsuarioDato)BD.TablaUsuarios[dni];
                uDato.Estado = "inactivo";
                return true;
            }
            return false;
        }

        public List<Usuario> Listar()
        {
            List<Usuario> resultados = new List<Usuario>();

            foreach (var item in BD.TablaUsuarios)
            {
                UsuarioDato uDato = (UsuarioDato)item;
                resultados.Add(Transformer.UsuarioDatoAUsuario(uDato));
            }
            return resultados;
        }
    }
}
