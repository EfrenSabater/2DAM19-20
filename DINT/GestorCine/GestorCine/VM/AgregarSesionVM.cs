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
    class AgregarSesionVM : INotifyPropertyChanged
    {
        public Sesion NuevaSesion { get; set; }
        public ObservableCollection<Pelicula> ListaPeliculas { get; set; }
        public ObservableCollection<Sala> ListaSalas { get; set; }
        private ServicioBD _servicio;

        public AgregarSesionVM()
        {
            _servicio = new ServicioBD();
            ListaPeliculas = _servicio.ObtenerPeliculas();
            ListaSalas = _servicio.ObtenerSalas();
            NuevaSesion = new Sesion();
        }

        public bool SesionValida()
        {
            return (NuevaSesion.Pelicula != null && NuevaSesion.Sala != null && NuevaSesion.Hora != null);
        }

        public void AgregarSesion()
        {
            _servicio.InsertarSesion(NuevaSesion);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
