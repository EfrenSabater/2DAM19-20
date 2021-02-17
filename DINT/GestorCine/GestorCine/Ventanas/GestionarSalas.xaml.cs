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
    }
}
