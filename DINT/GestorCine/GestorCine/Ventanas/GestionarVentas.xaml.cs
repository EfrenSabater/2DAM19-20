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
    public partial class GestionarVentas : Window
    {
        private GestionarVentasVM _vm;

        public GestionarVentas()
        {
            _vm = new GestionarVentasVM();
            InitializeComponent();
            DataContext = _vm;
        }

        private void CommandBinding_Executed_Agregar(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.AgregarVenta();
        }

        private void CommandBinding_CanExecute_Agregar(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _vm.VentaValida();
        }

        private void limpiarButton_Click(object sender, RoutedEventArgs e)
        {
            _vm.LimpiarVenta();
        }

        private void consultarSalasButton_Click(object sender, RoutedEventArgs e)
        {
            ConsultarOcupacion ventana = new ConsultarOcupacion();
            ventana.Owner = this;
            ventana.Show();
        }

        /*
        private void actualizarButton_Click(object sender, RoutedEventArgs e)
        {
            _vm.ActualizarLista();
        }*/
    }
}
