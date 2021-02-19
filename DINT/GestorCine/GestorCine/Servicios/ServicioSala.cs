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
            // TODO: IMPLEMENTAR ACCESO A BD
            ObservableCollection<Sala> salas = new ObservableCollection<Sala>()
            {
                new Sala("1A", 50, true),
                new Sala("1B", 35, true),
                new Sala("2A", 70, true)
            };

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
            throw new NotImplementedException();
        }
    }
}
