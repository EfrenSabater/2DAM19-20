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
    
    public partial class AgregarSala : Window
    {
        private AgregarSalaVM _vm;

        public AgregarSala()
        {
            _vm = new AgregarSalaVM();
            InitializeComponent();
            DataContext = _vm;
        }

        private void CommandBinding_Executed_AgregarSala(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.AgregarSala();
        }

        private void CommandBinding_CanExecute_AgregarSala(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _vm.SalaValida();
        }
    }
}
