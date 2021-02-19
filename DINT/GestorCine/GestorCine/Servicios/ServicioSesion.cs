using GestorCine.POJO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorCine.Servicios
{
    class ServicioSesion
    {
        public ServicioSesion() { }

        public ObservableCollection<Sesion> ObetenerSesiones()
        {
            // TODO: IMPLEMENTAR ACCESO A BD
            ObservableCollection<Sesion> sesiones = new ObservableCollection<Sesion>()
            {
                new Sesion(new Pelicula(), new Sala("1A", 50, true), "20:00"),
                new Sesion(new Pelicula(), new Sala("1B", 35, true), "15:30"),
                new Sesion(new Pelicula(), new Sala("2A", 70, true), "18:15")
            };

            return sesiones;
        }
    }
}
