using LógicaNegocio;
using ModeloDominio;
using System;
using System.Collections.Generic;
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
            admin.añadirtrabajador(new ModeloDominio.PersonalAdquisicion("usr1", "1234"));
            admin.añadirtrabajador(new ModeloDominio.PersonalSala("usr2", "1234"));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormInicio());
        }
    }
}
