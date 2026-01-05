using ModeloDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentación
{
    public partial class RecorridoUsuario : Form
    {
        private LógicaNegocio.PersonalBiblioteca personal;
        private BindingSource miBindingSource = new BindingSource();

        //PRE:  p es PersonalBiblioteca válido
        //POS:  Inicializa el formulario y llama a ConfigurarEnlaceDatos()
        public RecorridoUsuario(LógicaNegocio.PersonalBiblioteca p)
        {
            InitializeComponent();
            this.personal = p;
            ConfigurarEnlaceDatos();
        }

        //PRE:
        //POS:  Obtiene los usuarios activos. Configura el BindingSource y el BindingNavigator.
        private void ConfigurarEnlaceDatos()
        {
            List<Usuario> listaUsuarios = personal.getUsuarios().Where(u => u.Estado == EstadoActivoInactivo.activo).ToList();
            miBindingSource.DataSource = listaUsuarios;
            bindingNavigator1.BindingSource = miBindingSource;
            textBox1.DataBindings.Add("Text", miBindingSource, "DNI");
            textBox2.DataBindings.Add("Text", miBindingSource, "Nombre");
        }
    }
}
