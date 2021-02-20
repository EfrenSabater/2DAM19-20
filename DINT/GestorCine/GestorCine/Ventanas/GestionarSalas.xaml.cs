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
using System.Windows.Shapes;

namespace GestorCine
{
    public partial class GestionarSalas : Window
    {
        private GestionarSalasVM _vm;
        public GestionarSalas()
        {
            _vm = new GestionarSalasVM();
            InitializeComponent();
            DataContext = _vm;
        }

        private void CommandBinding_Executed_Agregar(object sender, ExecutedRoutedEventArgs e)
        {
            AgregarSala ventana = new AgregarSala();
            ventana.Owner = this;
            
            if (ventana.ShowDialog() == true)
            {
                _vm.RefreshLista();
            }
        }

        private void CommandBinding_Executed_Modificar(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.ModificarSala();
        }

        private void CommandBinding_CanExecute_Modificar(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _vm.HaySalaSeleccionada();
        }

        private void guardarCambiosButton_Click(object sender, RoutedEventArgs e)
        {
            _vm.GuardarCambios();
        }

        private void cancelarCambiosButton_Click(object sender, RoutedEventArgs e)
        {
            _vm.CancelarCambios();
        }
    }
}
