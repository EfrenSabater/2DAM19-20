using GestorCine.POJO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorCine.Servicios
{
    class ServicioSala
    {
        public ServicioSala() { }

        public ObservableCollection<Sala> ObtenerSalas()
        {
            // TODO: IMPLEMENTAR ACCESO A BD
            ObservableCollection<Sala> salas = new ObservableCollection<Sala>()
            {
                new Sala("1A", 50, true),
                new Sala("1B", 35, true),
                new Sala("2A", 70, true)
            };

            return salas;
        }
    }
}
