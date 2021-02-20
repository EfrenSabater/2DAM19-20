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
using System.Windows.Shapes;

namespace GestorCine.Ventanas
{
    public partial class AgregarSesion : Window
    {
        private AgregarSesionVM _vm;

        public AgregarSesion()
        {
            _vm = new AgregarSesionVM();
            InitializeComponent();
            DataContext = _vm;
        }

        private void CommandBinding_Executed_Agregar(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.AgregarSesion();
            DialogResult = true;
        }

        private void CommandBinding_CanExecute_Agregar(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _vm.SesionValida();
        }

        private void cancelarButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
