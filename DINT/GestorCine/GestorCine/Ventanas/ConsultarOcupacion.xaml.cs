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
    
    public partial class ConsultarOcupacion : Window
    {
        private ConsultarOcupacionVM _vm;

        public ConsultarOcupacion()
        {
            _vm = new ConsultarOcupacionVM();
            InitializeComponent();
            DataContext = _vm;
        }

        private void CommandBinding_Executed_Actualizar(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.CalcularAforo();
        }

        private void CommandBinding_CanExecute_Actualizar(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _vm.HaySalaSeleccionada();
        }
    }
}
