using GestorCine.POJO;
using GestorCine.Servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
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
            ListaSalas = _servicio.ObtenerSalas();
        }

        public bool HaySalaSeleccionada()
        {
            return SalaSeleccionada != null;
        }

        public void ModificarSala()
        {
            NuevaSala = new Sala(SalaSeleccionada);
        }

        public void GuardarCambios()
        {
            _servicio.ActualizarSala(NuevaSala);
            NuevaSala = null;
            ListaSalas = _servicio.ObtenerSalas();
        }

        public void CancelarCambios()
        {
            NuevaSala = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
