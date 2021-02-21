using GestorCine.Ventanas;
using GestorCine.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestorCine
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowVM _vm;

        public MainWindow()
        {
            _vm = new MainWindowVM();
            InitializeComponent();
        }

        private void gestionarSalasButton_Click(object sender, RoutedEventArgs e)
        {
            GestionarSalas ventana = new GestionarSalas();
            ventana.Owner = this;
            ventana.Show();
        }

        private void gestionarSesionesButton_Click(object sender, RoutedEventArgs e)
        {
            GestionarSesiones ventana = new GestionarSesiones();
            ventana.Owner = this;
            ventana.Show();
        }

        private void gestionarVentasButton_Click(object sender, RoutedEventArgs e)
        {
            GestionarVentas ventana = new GestionarVentas();
            ventana.Owner = this;
            ventana.Show();
        }
    }
}
