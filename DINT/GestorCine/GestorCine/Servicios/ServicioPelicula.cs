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
    class ServicioPelicula
    {
        private readonly SqliteConnection _conexion;
        private SqliteCommand _comando;
        private ServicioApiRest _servicioApi;

        public ServicioPelicula()
        {
            _servicioApi = new ServicioApiRest();
            _conexion = new SqliteConnection("Data Source=cinedatabase.db");
            CrearTablas();
            InsertarDatos();
        }

        private void CrearTablas()
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();
            // Código de creación proporcionado por el proyecto
            _comando.CommandText = @"DROP TABLE IF EXISTS peliculas;
                                    CREATE TABLE peliculas (
                                        idPelicula   INTEGER PRIMARY KEY,
                                        titulo       TEXT,
                                        cartel       TEXT,
                                        año          INTEGER,
                                        genero       TEXT,
                                        calificacion TEXT
                                    );

                                    DROP TABLE IF EXISTS salas;
                                    CREATE TABLE salas (
                                        idSala     INTEGER PRIMARY KEY AUTOINCREMENT,
                                        numero     TEXT,
                                        capacidad  INTEGER,
                                        disponible BOOLEAN DEFAULT (true) 
                                    );

                                    DROP TABLE IF EXISTS sesiones;
                                    CREATE TABLE sesiones (
                                        idSesion INTEGER PRIMARY KEY AUTOINCREMENT,
                                        pelicula INTEGER REFERENCES peliculas (idPelicula),
                                        sala     INTEGER REFERENCES salas (idSala),
                                        hora     TEXT
                                    );

                                    DROP TABLE IF EXISTS ventas;
                                    CREATE TABLE ventas (
                                        idVenta  INTEGER PRIMARY KEY AUTOINCREMENT,
                                        sesion   INTEGER REFERENCES sesiones (idSesion),
                                        cantidad INTEGER,
                                        pago     TEXT
                                    );";
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        private void InsertarDatos()
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            ObservableCollection<Pelicula> peliculas = _servicioApi.ObtenerPeliculas();
            foreach (Pelicula p in peliculas)
            {
                _comando.CommandText = "INSERT INTO peliculas VALUES (@idPelicula , @titulo , @cartel , @anyo , @genero , @calificacion)";
                _comando.Parameters.Add("@idPelicula", SqliteType.Integer);
                _comando.Parameters.Add("@idPelicula", SqliteType.Integer);
                _comando.Parameters.Add("@idPelicula", SqliteType.Integer);
                _comando.Parameters.Add("@idPelicula", SqliteType.Integer);
                _comando.Parameters.Add("@idPelicula", SqliteType.Integer);
            }

            _conexion.Close();
        }

    }
}
