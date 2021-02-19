using GestorCine.POJO;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorCine.Servicios
{
    class ServicioApiRest
    {
        public ServicioApiRest() { }

        public ObservableCollection<Pelicula> ObtenerPeliculas()
        {
            var client = new RestClient(Properties.Settings.Default.apiDireccion);
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<ObservableCollection<Pelicula>>(response.Content);
        }
    }
}
