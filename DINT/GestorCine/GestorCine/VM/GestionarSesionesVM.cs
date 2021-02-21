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
        public ObservableCollection<Pelicula> ListaPeliculas { get; set; }
        public ObservableCollection<Sala> ListaSalas { get; set; }
        public Sesion NuevaSesion { get; set; }
        public Sesion SesionSeleccionada { get; set; }
        private ServicioBD _servicio;

        public GestionarSesionesVM() 
        {
            _servicio = new ServicioBD();
            ListaSesiones = _servicio.ObtenerSesiones();
            ListaPeliculas = _servicio.ObtenerPeliculas();
            ListaSalas = _servicio.ObtenerSalas();
        }

        // Click en Modificar Sesion
        public void ModificarSesion()
        {
            NuevaSesion = new Sesion(SesionSeleccionada);
        }

        // Click en Eliminar Sesion
        public void EliminarSesion()
        {
            _servicio.EliminarSesion(SesionSeleccionada);
            NuevaSesion = null;
            RefreshLista();
        }

        // Click en Guardar
        public void GuardarCambios()
        {
            _servicio.ActualizarSesion(NuevaSesion);
            NuevaSesion = null;
            RefreshLista();
        }

        // Click en Cancelar
        public void CancelarCambios()
        {
            NuevaSesion = null;
        }

        public void RefreshLista()
        {
            ListaSesiones = _servicio.ObtenerSesiones();
        }

        public bool HaySesionSeleccionada()
        {
            return SesionSeleccionada != null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
