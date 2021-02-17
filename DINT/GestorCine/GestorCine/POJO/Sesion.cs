using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorCine.POJO
{
    class Sesion : INotifyPropertyChanged
    {
        //private int _idSesion;

        private Pelicula _pelicula;
        public Pelicula Pelicula
        {
            get => _pelicula;
            set
            {
                if (_pelicula != value)
                {
                    _pelicula = value;
                    NotifyPropertyChanged("Pelicula");
                }
            }
        }

        private Sala _sala;
        public Sala Sala
        {
            get => _sala;
            set
            {
                if (_sala != value)
                {
                    _sala = value;
                    NotifyPropertyChanged("Sala");
                }
            }
        }

        private string _hora;
        public string Hora
        {
            get => _hora;
            set
            {
                if (_hora != value)
                {
                    _hora = value;
                    NotifyPropertyChanged("Hora");
                }
            }
        }

        public Sesion() { }

        public Sesion(Pelicula pelicula, Sala sala, string hora)
        {
            _pelicula = pelicula;
            _sala = sala;
            _hora = hora;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
