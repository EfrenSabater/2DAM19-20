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

        // private int IdPelicula;
        public string Titulo { get; set; }
        public string Cartel { get; set; }
        public int Anyo { get; set; }
        public Generos Genero { get; set; }
        public Calificaciones Calificacion { get; set; }

        public Pelicula() { }

        public Pelicula(string titulo, string cartel, int anyo, Generos genero, Calificaciones calificacion)
        {
            Titulo = titulo;
            Cartel = cartel;
            Anyo = anyo;
            Genero = genero;
            Calificacion = calificacion;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
