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
        //private int IdSesion;
        public Pelicula Pelicula { get; set; }
        public Sala Sala { get; set; }
        public string Hora { get; set; }

        public Sesion() { }

        public Sesion(Pelicula pelicula, Sala sala, string hora)
        {
            Pelicula = pelicula;
            Sala = sala;
            Hora = hora;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
