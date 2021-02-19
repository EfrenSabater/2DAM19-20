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
    class ServicioSala
    {
        private readonly SqliteConnection _conexion;
        private SqliteCommand _comando;

        public ServicioSala() 
        {
            _conexion = new SqliteConnection("Data Source=salas.db");
            CrearTabla();
            InsertarDatos();
        }

        public ObservableCollection<Sala> ObtenerSalas()
        {
            ObservableCollection<Sala> salas = new ObservableCollection<Sala>();

            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "SELECT * FROM salas";
            SqliteDataReader lector = _comando.ExecuteReader();

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int idSala = lector.GetInt32(0);
                    string numero = lector.GetString(1);
                    int capacidad = lector.GetInt32(2);
                    bool disponible = lector.GetBoolean(3);
                    salas.Add(new Sala(idSala, numero, capacidad, disponible));
                }
            }

            lector.Close();
            _conexion.Close();

            return salas;
        }

        private void CrearTabla()
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();
            // Código de creación proporcionado por el proyecto
            _comando.CommandText = @"DROP TABLE IF EXISTS salas;
                                    CREATE TABLE salas (
                                        idSala     INTEGER PRIMARY KEY AUTOINCREMENT,
                                        numero     TEXT,
                                        capacidad  INTEGER,
                                        disponible BOOLEAN DEFAULT (true) 
                                    );";
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        private void InsertarDatos()
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "DELETE FROM salas";
            _comando.ExecuteNonQuery();
            _comando.CommandText = "INSERT INTO salas(numero, capacidad, disponible) VALUES ('1A', 50, true)";
            _comando.ExecuteNonQuery();
            _comando.CommandText = "INSERT INTO salas(numero, capacidad, disponible) VALUES ('1B', 35, true)";
            _comando.ExecuteNonQuery();
            _comando.CommandText = "INSERT INTO salas(numero, capacidad, disponible) VALUES ('2A', 70, true)";
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        public void ActualizarSala(Sala sala)
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "UPDATE salas SET capacidad=@capacidad , disponible=@disponible " +
                                   "WHERE idSala=@idSala";
            _comando.Parameters.Add("@capacidad", SqliteType.Integer);
            _comando.Parameters.Add("@disponible", SqliteType.Integer);
            _comando.Parameters.Add("@idSala", SqliteType.Integer);
            _comando.Parameters["@capacidad"].Value = sala.Capacidad;
            _comando.Parameters["@disponible"].Value = sala.Disponible;
            _comando.Parameters["@idSala"].Value = sala.IdSala;
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }
    }
}
