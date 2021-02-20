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
        public int IdSesion { get; set; }
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

        public Sesion(int idSesion, Pelicula pelicula, Sala sala, string hora)
        {
            IdSesion = idSesion;
            Pelicula = pelicula;
            Sala = sala;
            Hora = hora;
        }

        public Sesion(Sesion sesion)
        {
            IdSesion = sesion.IdSesion;
            Pelicula = sesion.Pelicula;
            Sala = sesion.Sala;
            Hora = sesion.Hora;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
