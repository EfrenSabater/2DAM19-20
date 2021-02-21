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
        /*
        public enum MediosPago
        {
            Efectivo, Tarjeta, Bizum
        }*/

        public int IdVenta { get; set; }
        public Sesion Sesion { get; set; }
        public int Cantidad { get; set; }
        public string Pago { get; set; }

        public Venta() { }

        public Venta(Sesion sesion, int cantidad, string pago)
        {
            Sesion = sesion;
            Cantidad = cantidad;
            Pago = pago;
        }

        public Venta(int idVenta, Sesion sesion, int cantidad, string pago)
        {
            IdVenta = IdVenta;
            Sesion = sesion;
            Cantidad = cantidad;
            Pago = pago;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
