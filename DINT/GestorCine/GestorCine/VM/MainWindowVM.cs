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
        public ObservableCollection<Pelicula> peliculas;
        private ServicioApiRest _servicioApi;

        public MainWindowVM() 
        {
            _servicioApi = new ServicioApiRest();
            peliculas = _servicioApi.ObtenerPeliculas();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
