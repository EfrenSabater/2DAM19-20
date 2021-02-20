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
        private ServicioBD _servicio;

        public AgregarSalaVM()
        {
            _servicio = new ServicioBD();
            NuevaSala = new Sala();
        }

        public bool SalaValida()
        {
            return (NuevaSala.Numero != "" && NuevaSala.Capacidad > 0);
        }

        public void AgregarSala()
        {
            _servicio.InsertarSala(NuevaSala);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
