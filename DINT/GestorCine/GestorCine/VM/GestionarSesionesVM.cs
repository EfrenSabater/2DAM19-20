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
        private ServicioBD _servicio;

        public GestionarSesionesVM() 
        {
            _servicio = new ServicioBD();
            NuevaSesion = new Sesion();
            ListaSesiones = _servicio.ObtenerSesiones();
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
