using GestorCine.POJO;
using Microsoft.Data.Sqlite;
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
        private readonly SqliteConnection _conexion;
        private SqliteCommand _comando;

        public ServicioSesion() 
        {
            _conexion = new SqliteConnection("Data Source=sesiones.db");
            CrearTabla();
            // InsertarDatos();
        }

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

        private void CrearTabla()
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();
            // Código de creación proporcionado por el proyecto
            _comando.CommandText = @"DROP TABLE IF EXISTS sesiones;
                                    CREATE TABLE sesiones (
                                        idSesion INTEGER PRIMARY KEY AUTOINCREMENT,
                                        pelicula INTEGER REFERENCES peliculas (idPelicula),
                                        sala     INTEGER REFERENCES salas (idSala),
                                        hora     TEXT
                                    );";
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        private void InsertarDatos()
        {
            throw new NotImplementedException();
        }
    }
}
