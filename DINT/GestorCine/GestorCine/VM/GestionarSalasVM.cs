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
        private ServicioBD _servicio;

        public GestionarSalasVM()
        {
            _servicio = new ServicioBD();
            RefreshLista();
        }

        public bool HaySalaSeleccionada()
        {
            return SalaSeleccionada != null;
        }

        // Click en Modificar Sala
        public void ModificarSala()
        {
            NuevaSala = new Sala(SalaSeleccionada);
        }

        // Click en Guardar
        public void GuardarCambios()
        {
            _servicio.ActualizarSala(NuevaSala);
            NuevaSala = null;
            RefreshLista();
        }

        // Click en Cancelar
        public void CancelarCambios()
        {
            NuevaSala = null;
        }

        public void RefreshLista()
        {
            ListaSalas = _servicio.ObtenerSalas();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
