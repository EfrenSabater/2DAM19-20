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
        //private int IdSala;
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

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
