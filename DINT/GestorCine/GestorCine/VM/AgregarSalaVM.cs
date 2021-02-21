using GestorCine.POJO;
using GestorCine.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GestorCine.VM
{
    class AgregarSalaVM : INotifyPropertyChanged
    {
        public Sala NuevaSala { get; set; }
        private ServicioBD _servicio;

        public AgregarSalaVM()
        {
            _servicio = new ServicioBD();
            NuevaSala = new Sala();
        }

        public bool SalaValida()
        {
            return (NuevaSala.Numero != "" && NuevaSala.Capacidad > 0);
        }

        public void AgregarSala()
        {
            List<string> numeros = _servicio.GetNombresSalas();
            if (!numeros.Contains(NuevaSala.Numero))
            {
                _servicio.InsertarSala(NuevaSala);
            }
            else
            {
                MessageBox.Show("ERROR: Se ha intentado introducir una sala con un nombre que ya existe.", "Error");
            }
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
