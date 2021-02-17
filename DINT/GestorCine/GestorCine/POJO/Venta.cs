using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorCine.POJO
{
    class Venta : INotifyPropertyChanged
    {
        public enum MediosPago
        {
            Efectivo, Tarjeta, Bizum
        }

        //private int IdVenta;
        public Sesion Sesion { get; set; }
        public int Cantidad { get; set; }
        public MediosPago Pago { get; set; }

        public Venta() { }

        public Venta(Sesion sesion, int cantidad, MediosPago pago)
        {
            Sesion = sesion;
            Cantidad = cantidad;
            Pago = pago;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
