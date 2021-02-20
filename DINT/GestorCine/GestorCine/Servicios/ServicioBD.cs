﻿using GestorCine.POJO;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorCine.Servicios
{
    class ServicioBD
    {
        private readonly SqliteConnection _conexion;
        private SqliteCommand _comando;
        private ServicioApiRest _servicioApi;

        public ServicioBD()
        {
            _servicioApi = new ServicioApiRest();
            _conexion = new SqliteConnection("Data Source=cinedatabase.db");
            CrearTablas();
            RellenarPeliculas();
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

        private void RellenarPeliculas()
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            ObservableCollection<Pelicula> peliculas = _servicioApi.ObtenerPeliculas();
            foreach (Pelicula p in peliculas)
            {
                _comando.CommandText = "INSERT INTO peliculas VALUES (@idPelicula , @titulo , @cartel , @anyo , @genero , @calificacion)";
                _comando.Parameters.Add("@idPelicula", SqliteType.Integer);
                _comando.Parameters.Add("@titulo", SqliteType.Text);
                _comando.Parameters.Add("@cartel", SqliteType.Text);
                _comando.Parameters.Add("@anyo", SqliteType.Integer);
                _comando.Parameters.Add("@genero", SqliteType.Text);
                _comando.Parameters.Add("@calificacion", SqliteType.Text);
                _comando.Parameters["@idPelicula"].Value = p.IdPelicula;
                _comando.Parameters["@titulo"].Value = p.Titulo;
                _comando.Parameters["@cartel"].Value = p.Cartel;
                _comando.Parameters["@anyo"].Value = p.Anyo;
                _comando.Parameters["@genero"].Value = p.Genero;
                _comando.Parameters["@calificacion"].Value = p.Calificacion;
                _comando.ExecuteNonQuery();
            }

            _conexion.Close();
        }

        /* ***************************** */
        /*  MÉTODOS PARA LA TABLA salas  */
        /* ***************************** */
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

        public void InsertarSala(Sala sala)
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "INSERT INTO salas (numero, capacidad, disponible) VALUES (@numero , @capacidad , @disponible)";
            _comando.Parameters.Add("@numero", SqliteType.Text);
            _comando.Parameters.Add("@capacidad", SqliteType.Integer);
            _comando.Parameters.Add("@disponible", SqliteType.Integer);
            _comando.Parameters["@numero"].Value = sala.Numero;
            _comando.Parameters["@capacidad"].Value = sala.Capacidad;
            _comando.Parameters["@disponible"].Value = sala.Disponible;
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        public Sala EncontrarSala(int idSala)
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "SELECT * FROM salas WHERE idSala=@idSala";
            _comando.Parameters.Add("@idSala", SqliteType.Integer);
            _comando.Parameters["@idSala"].Value = idSala;
            SqliteDataReader lector = _comando.ExecuteReader();

            Sala resultado = null;
            if (lector.HasRows)
            {
                resultado = new Sala(lector.GetInt32(0), lector.GetString(1), lector.GetInt32(2), lector.GetBoolean(3));
            }

            lector.Close();
            _conexion.Close();
            return resultado;
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

        /* ******************************** */
        /*  MÉTODOS PARA LA TABLA sesiones  */
        /* ******************************** */
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
                    Pelicula p = EncontrarPelicula(lector.GetInt32(1));
                    Sala s = EncontrarSala(lector.GetInt32(2));
                    string hora = lector.GetString(3);
                    sesiones.Add(new Sesion(idSesion, p, s, hora));
                }
            }

            lector.Close();
            _conexion.Close();
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

        /* ********************************* */
        /*  MÉTODOS PARA LA TABLA peliculas  */
        /* ********************************* */
        public Pelicula EncontrarPelicula(int idPelicula)
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "SELECT * FROM peliculas WHERE idPelicula=@idPelicula";
            _comando.Parameters.Add("@idPelicula", SqliteType.Integer);
            _comando.Parameters["@idPelicula"].Value = idPelicula;
            SqliteDataReader lector = _comando.ExecuteReader();

            Pelicula resultado = null;
            if (lector.HasRows)
            {
                resultado = new Pelicula(lector.GetInt32(0), lector.GetString(1), lector.GetString(2), lector.GetInt32(3), lector.GetString(4), lector.GetString(5));
            }

            lector.Close();
            _conexion.Close();
            return resultado;
        }

        
    }
}
