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
        // PRE: El objeto 'usuario' no debe ser nulo y debe ser del tipo Usuario.
        // POS: Devuelve true si el usuario es insertado en la base de datos.
        //      Devuelve false si ya existe un usuario con el mismo DNI en la tabla.
       
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

        // PRE: 'dni' debe ser string.
        // POS: Devuelve el objeto Usuario si existe en la base de datos y su estado es distinto de "inactivo".
        //      Devuelve null si el usuario no existe o si ha sido dado de baja (estado "inactivo").
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

        // PRE: 'dni' debe ser string.
        // POS: Devuelve true si encuentra al usuario y cambia su estado a "inactivo" .
        //      Devuelve false si el usuario no existe en la base de datos.
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

        // PRE: 
        // POS: Devuelve una lista con todos los usuarios almacenados en la base de datos, incluyendo los activos y los inactivos.
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
