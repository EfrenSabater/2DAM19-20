using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorCine.POJO
{
    class Sala : INotifyPropertyChanged
    {
        //private int _idSala;

        private string _numero;
        public string Numero
        {
            get => _numero;
            set
            {
                if (_numero != value)
                {
                    _numero = value;
                    NotifyPropertyChanged("Numero");
                }
            }
        }

        private int _capacidad;
        public int Capacidad
        {
            get => _capacidad;
            set
            {
                if (_capacidad != value)
                {
                    _capacidad = value;
                    NotifyPropertyChanged("Capacidad");
                }
            }
        }

        private bool _disponible;
        public bool Disponible
        {
            get => _disponible;
            set
            {
                if (_disponible != value)
                {
                    _disponible = value;
                    NotifyPropertyChanged("Disponible");
                }
            }
        }

        public Sala() { }

        public Sala(string numero, int capacidad, bool disponible)
        {
            _numero = numero;
            _capacidad = capacidad;
            _disponible = disponible;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
