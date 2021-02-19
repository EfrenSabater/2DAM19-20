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
    
    public partial class GestionarSesiones : Window
    {

        private GestionarSesionesVM _vm;

        public GestionarSesiones()
        {
            _vm = new GestionarSesionesVM();
            InitializeComponent();
            DataContext = _vm;
        }
    }
}
