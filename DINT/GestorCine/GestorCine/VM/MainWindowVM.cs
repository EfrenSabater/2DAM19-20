using GestorCine.POJO;
using GestorCine.Servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorCine.VM
{
    class MainWindowVM : INotifyPropertyChanged
    {
        private ServicioPelicula _servicio;

        // MainWindow sólo se encarga de crear cinedatabase.db gracias a ServicioPelicula, que llama a ServicioApiRest
        public MainWindowVM() 
        {
            _servicio = new ServicioPelicula();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
