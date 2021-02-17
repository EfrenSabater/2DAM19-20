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
    class GestionarSalasVM : INotifyPropertyChanged
    {
        public ObservableCollection<Sala> ListaSalas { get; set; }
        public Sala NuevaSala { get; set; }
        public Sala SalaSeleccionada { get; set; }
        private ServicioSala _servicio;

        public GestionarSalasVM()
        {
            _servicio = new ServicioSala();
            NuevaSala = new Sala();
            ListaSalas = _servicio.ObtenerSalas();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
