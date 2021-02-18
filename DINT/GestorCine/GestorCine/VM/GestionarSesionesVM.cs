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
    class GestionarSesionesVM : INotifyPropertyChanged
    {

        public ObservableCollection<Sesion> ListaSesiones { get; set; }
        public Sesion NuevaSesion;
        public Sesion SesionSeleccionada;
        public ServicioSesion _servicio;

        public GestionarSesionesVM() { }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
