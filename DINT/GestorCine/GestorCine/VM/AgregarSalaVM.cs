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
    class AgregarSalaVM : INotifyPropertyChanged
    {
        public Sala NuevaSala { get; set; }
        private ServicioSala _servicio;

        public AgregarSalaVM()
        {
            _servicio = new ServicioSala();
            NuevaSala = new Sala();
        }

        public bool SalaValida()
        {
            return NuevaSala.Capacidad > 3;
        }

        public void AgregarSala()
        {
            _servicio.InsertarSala(NuevaSala);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
