﻿using GestorCine.POJO;
using GestorCine.Servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorCine.VM
{
    class GestionarVentasVM : INotifyPropertyChanged
    {
        public ObservableCollection<Sesion> ListaSesiones { get; set; }
        public Venta NuevaVenta { get; set; }
        // NO FUNCIONA EL MÉTODO DE ORDENAR
        // public bool OrderByPeliculas { get; set; }
        private ServicioBD _servicio;

        public GestionarVentasVM()
        {
            _servicio = new ServicioBD();
            NuevaVenta = new Venta();
            // OrderByPeliculas = true;
            ListaSesiones = _servicio.ObtenerSesiones();
        }

        public void AgregarVenta()
        {
            _servicio.InsertarVenta(NuevaVenta);
            NuevaVenta = new Venta();
        }

        public bool VentaValida()
        {
            return (NuevaVenta.Sesion != null && NuevaVenta.Cantidad > 0);
        }

        public void LimpiarVenta()
        {
            NuevaVenta = new Venta();
        }

        /* NO SE UTILIZA PORQUE NO FUNCIONA EL ORDENAR
        public void ActualizarLista()
        {
            ListaSesiones = _servicio.ObtenerSesionesOrderBy(OrderByPeliculas);
        }*/

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
