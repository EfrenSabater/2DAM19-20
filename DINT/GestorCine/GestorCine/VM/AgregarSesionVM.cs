using GestorCine.POJO;
using GestorCine.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorCine.VM
{
    class AgregarSesionVM : INotifyPropertyChanged
    {
        public Sesion NuevaSesion { get; set; }
        private ServicioBD _servicio;

        public AgregarSesionVM()
        {
            _servicio = new ServicioBD();
            NuevaSesion = new Sesion();
        }

        public bool SesionValida()
        {
            return false;
        }

        public void AgregarSesion()
        {
            _servicio.InsertarSesion(NuevaSesion);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
