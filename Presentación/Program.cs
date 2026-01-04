using LógicaNegocio;
using ModeloDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentación
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Admin admin = new LógicaNegocio.Admin();
            ModeloDominio.PersonalAdquisicion adquisicion = new ModeloDominio.PersonalAdquisicion("usr1", "Pepe Pepín", "1234");
            admin.añadirtrabajador(adquisicion);
            ModeloDominio.PersonalSala sala = new ModeloDominio.PersonalSala("usr2", "Jose Juan", "1234");
            admin.añadirtrabajador(sala);
            Documento d1 = new LibroPapel("d", "1", "r", 5, "3");
            admin.altaDocumento(d1);
            Documento d2 = new LibroPapel("4", "5", "j", 5, "3");
            admin.altaDocumento(d2);
            
            admin.altaEjemplar(new Ejemplar(d1,"3",adquisicion));
            admin.altaEjemplar(new Ejemplar(d1, "5", adquisicion));
            admin.altaEjemplar(new Ejemplar(d2, "3", adquisicion));

            admin.altaUsuario(new Usuario("111A", "Pepe"));
            admin.altaUsuario(new Usuario("121B", "Pepito"));
            admin.altaUsuario(new Usuario("345U", "Ramón"));
            admin.altaUsuario(new Usuario("963Z", "Usuario"));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormInicio());
           
        }
    }
}
