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
    class ConsultarOcupacionVM : INotifyPropertyChanged
    {
        public ObservableCollection<Sala> ListaSalas { get; set; }
        public Sala SalaSeleccionada { get; set; }
        public int AforoRestante { get; set; }
        public int AforoOcupado { get; set; }
        private ServicioBD _servicio;

        public ConsultarOcupacionVM()
        {
            _servicio = new ServicioBD();
            ListaSalas = _servicio.ObtenerSalas();
            AforoOcupado = -1;
            AforoRestante = -1;
        }

        public void CalcularAforo()
        {
            AforoOcupado = _servicio.CalcularAforoOcupado(SalaSeleccionada.IdSala);
            AforoRestante = SalaSeleccionada.Capacidad - AforoOcupado;
        }

        public bool HaySalaSeleccionada()
        {
            return SalaSeleccionada != null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
