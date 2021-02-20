using GestorCine.POJO;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;

namespace GestorCine.Servicios
{
    class ServicioSesion
    {
        private readonly SqliteConnection _conexion;
        private SqliteCommand _comando;

        public ServicioSesion() 
        {
            _conexion = new SqliteConnection("Data Source=cinedatabase.db");
            InsertarDatos();
        }

        public ObservableCollection<Sesion> ObtenerSesiones()
        {
            ObservableCollection<Sesion> sesiones = new ObservableCollection<Sesion>();

            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "SELECT * FROM sesiones";
            SqliteDataReader lector = _comando.ExecuteReader();

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int idSesion = lector.GetInt32(0);
                    Pelicula p = null;
                    Sala s = null;
                    string hora = lector.GetString(3);
                    sesiones.Add(new Sesion(idSesion, p, s, hora));
                }
            }

            return sesiones;
        }

        public void InsertarSesion(Sesion sesion)
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "INSERT INTO sesiones (pelicula, sala, hora) VALUES (@pelicula , @sala , @hora)";
            _comando.Parameters.Add("@pelicula", SqliteType.Integer);
            _comando.Parameters.Add("@sala", SqliteType.Integer);
            _comando.Parameters.Add("@hora", SqliteType.Text);
            _comando.Parameters["@pelicula"].Value = sesion.Pelicula.IdPelicula;
            _comando.Parameters["@sala"].Value = sesion.Sala.IdSala;
            _comando.Parameters["@hora"].Value = sesion.Hora;
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        public void ActualizarSesion(Sesion sesion)
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "UPDATE sesiones SET pelicula=@pelicula , sala=@sala , hora=@hora " +
                                   "WHERE idSesion=@idSesion";
            _comando.Parameters.Add("@pelicula", SqliteType.Integer);
            _comando.Parameters.Add("@sala", SqliteType.Integer);
            _comando.Parameters.Add("@hora", SqliteType.Text);
            _comando.Parameters.Add("@idSesion", SqliteType.Integer);
            _comando.Parameters["@pelicula"].Value = sesion.Pelicula.IdPelicula;
            _comando.Parameters["@sala"].Value = sesion.Sala.IdSala;
            _comando.Parameters["@hora"].Value = sesion.Hora;
            _comando.Parameters["@idSesion"].Value = sesion.IdSesion;
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        public void EliminarSesion(Sesion sesion)
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "DELETE FROM sesiones WHERE idSesion=@idSesion";
            _comando.Parameters.Add("@idSesion", SqliteType.Integer);
            _comando.Parameters["@idSesion"].Value = sesion.IdSesion;
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        /*
        public PersonalizableAttribute EncuentraPelicula(int idPelicula)
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "SELECT * FROM "
        }*/

        private void InsertarDatos()
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "DELETE FROM sesiones";
            _comando.ExecuteNonQuery();
            _comando.CommandText = "INSERT INTO sesiones(pelicula, sala, hora) VALUES (1, 1, '20:00')";
            _comando.ExecuteNonQuery();
            _comando.CommandText = "INSERT INTO sesiones(pelicula, sala, hora) VALUES (2, 2, '23:00')";
            _comando.ExecuteNonQuery();
            _comando.CommandText = "INSERT INTO sesiones(pelicula, sala, hora) VALUES (1, 1, '15:00')";
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }
    }
}
