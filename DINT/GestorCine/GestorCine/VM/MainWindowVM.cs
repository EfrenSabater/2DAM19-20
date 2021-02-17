using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorCine.VM
{
    class MainWindowVM : INotifyPropertyChanged
    {

        public MainWindowVM() { }

        // No sé si es necesario
        public GestionarSalas CrearGestionarSalas()
        {
            GestionarSalas ventana = new GestionarSalas();
            return ventana;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
