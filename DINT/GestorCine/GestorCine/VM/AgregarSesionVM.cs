using GestorCine.POJO;
using GestorCine.Servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            int sesionesDeSala = _servicio.CuentaSesionesDeSala(NuevaSesion.Sala.IdSala);
            if (!(sesionesDeSala >= 3))
            {
                _servicio.InsertarSesion(NuevaSesion);
            }
            else
            {
                MessageBox.Show("ERROR: La sala proporcionada ya está en otras tres sesiones.", "Error");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
