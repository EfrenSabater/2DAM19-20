using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorCine.POJO
{
    class Pelicula : INotifyPropertyChanged
    {
        public enum Generos
        {
            Drama, Comedia, Accion,
            Thriller, Terror, Animacion
        }

        public enum Calificaciones
        {
            NRM_7, NRM_12, NRM_16,
            NRM_18, APTA_TP
        }

        // private int idPelicula;

        private string _titulo;
        public string Titulo
        {
            get => _titulo;
            set
            {
                if (_titulo != value)
                {
                    _titulo = value;
                    NotifyPropertyChanged("Titulo");
                }
            }
        }

        private string _cartel;
        public string Cartel
        {
            get => _cartel;
            set
            {
                if (_cartel != value)
                {
                    _cartel = value;
                    NotifyPropertyChanged("Cartel");
                }
            }
        }

        private int _anyo;
        public int Anyo
        {
            get => _anyo;
            set
            {
                if (_anyo != value)
                {
                    _anyo = value;
                    NotifyPropertyChanged("Anyo");
                }
            }
        }

        private Generos _genero;
        public Generos Genero
        {
            get => _genero;
            set
            {
                if (_genero != value)
                {
                    _genero = value;
                    NotifyPropertyChanged("Genero");
                }
            }
        }

        private Calificaciones _calificacion;
        public Calificaciones Calificacion
        {
            get => _calificacion;
            set
            {
                if (_calificacion != value)
                {
                    _calificacion = value;
                    NotifyPropertyChanged("Calificacion");
                }
            }
        }

        public Pelicula() { }

        public Pelicula(string titulo, string cartel, int anyo, Generos genero, Calificaciones calificacion)
        {
            _titulo = titulo;
            _cartel = cartel;
            _anyo = anyo;
            _genero = genero;
            _calificacion = calificacion;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
