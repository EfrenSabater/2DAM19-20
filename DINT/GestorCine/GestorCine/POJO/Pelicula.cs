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
        /*public enum Generos
        {
            Drama, Comedia, Accion,
            Thriller, Terror, Animacion
        }*/

        /*
        public enum Calificaciones
        {
            NRM_7, NRM_12, NRM_16,
            NRM_18, APTA_TP
        }*/

        public int IdPelicula { get; set; }
        public string Titulo { get; set; }
        public string Cartel { get; set; }
        public int Anyo { get; set; }
        public string Genero { get; set; }
        public string Calificacion { get; set; }

        public Pelicula() { }

        public Pelicula(int idPelicula, string titulo, string cartel, int anyo, string genero, string calificacion)
        {
            IdPelicula = idPelicula;
            Titulo = titulo;
            Cartel = cartel;
            Anyo = anyo;
            Genero = genero;
            Calificacion = calificacion;
        }

        /*
        public Pelicula(int idPelicula, string titulo, string cartel, int anyo, string genero, string calificacion)
        {
            IdPelicula = idPelicula;
            Titulo = titulo;
            Cartel = cartel;
            Anyo = anyo;
            Genero = StringToGenero(genero);
            Calificacion = StringToCalificacion(calificacion);
        }*/

        /*
        private Generos StringToGenero(string genero)
        {
            switch (genero)
            {
                case "Drama":
                    return Generos.Drama;
                case "Comedia":
                    return Generos.Comedia;
                case "Acción":
                    return Generos.Accion;
                case "Thriller":
                    return Generos.Thriller;
                case "Terror":
                    return Generos.Terror;
                default:
                    return Generos.Animacion;
            }
        }*/

        /*
        private Calificaciones StringToCalificacion(string calificacion)
        {
            switch (calificacion)
            {
                case "NRM 7":
                    return Calificaciones.NRM_7;
                case "NRM 12":
                    return Calificaciones.NRM_12;
                case "NRM 16":
                    return Calificaciones.NRM_16;
                case "NRM 18":
                    return Calificaciones.NRM_18;
                default:
                    return Calificaciones.APTA_TP;
            }
        }*/

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
