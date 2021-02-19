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
        public int IdSala { get; set; }
        public string Numero { get; set; }
        public int Capacidad { get; set; }
        public bool Disponible { get; set; }
        
        public Sala() { }

        public Sala(string numero, int capacidad, bool disponible)
        {
            Numero = numero;
            Capacidad = capacidad;
            Disponible = disponible;
        }

        public Sala(int id, string numero, int capacidad, bool disponible)
        {
            IdSala = id;
            Numero = numero;
            Capacidad = capacidad;
            Disponible = disponible;
        }

        public Sala(Sala sala)
        {
            IdSala = sala.IdSala;
            Numero = sala.Numero;
            Capacidad = sala.Capacidad;
            Disponible = sala.Disponible;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
