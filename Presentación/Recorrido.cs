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
    public partial class Recorrido : Form
    {
        private LógicaNegocio.PersonalBiblioteca personal;
        // Creamos el BindingSource que gestionará la navegación
        private BindingSource miBindingSource = new BindingSource();

        public Recorrido(LógicaNegocio.PersonalBiblioteca p)
        {
            InitializeComponent();
            this.personal = p;
            ConfigurarEnlaceDatos();
        }

        private void ConfigurarEnlaceDatos()
        {
            // 1. Obtener la lista completa de usuarios desde la capa de negocio
            // En PersonalBiblioteca.cs tienes el método obtenerUsuarios()
            List<Usuario> listaUsuarios = personal.getUsuarios();

            // 2. Asignar la lista al BindingSource
            miBindingSource.DataSource = listaUsuarios;

            // 3. Conectar el BindingNavigator visual con nuestro BindingSource lógico
            // 'bindingNavigator1' viene definido en tu Recorrido.Designer.cs
            bindingNavigator1.BindingSource = miBindingSource;

            // 4. Enlazar los TextBox a las propiedades del objeto Usuario
            // Sintaxis: .Add("PropiedadDelControl", FuenteDeDatos, "PropiedadDelObjeto")

            // textBox1 mostrará el DNI (según tu designer label1 es DNI)
            textBox1.DataBindings.Add("Text", miBindingSource, "DNI");

            // textBox2 mostrará el Nombre (según tu designer label2 es Nombre)
            textBox2.DataBindings.Add("Text", miBindingSource, "Nombre");
        }
    }
}
