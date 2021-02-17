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

        //private int _idVenta;

        private Sesion _sesion;
        public Sesion Sesion
        {
            get => _sesion;
            set
            {
                if (_sesion != value)
                {
                    _sesion = value;
                    NotifyPropertyChanged("Sesion");
                }
            }
        }

        private int _cantidad;
        public int Cantidad
        {
            get => _cantidad;
            set
            {
                if (_cantidad != value)
                {
                    _cantidad = value;
                    NotifyPropertyChanged("Cantidad");
                }
            }
        }

        private MediosPago _pago;
        public MediosPago Pago
        {
            get => _pago;
            set
            {
                if (_pago != value)
                {
                    _pago = value;
                    NotifyPropertyChanged("Pago");
                }
            }
        }

        public Venta() { }

        public Venta(Sesion sesion, int cantidad, MediosPago pago)
        {
            _sesion = sesion;
            _cantidad = cantidad;
            _pago = pago;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
