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
    class ServicioBD
    {
        private readonly SqliteConnection _conexion;
        private SqliteCommand _comando;
        private ServicioApiRest _servicioApi;

        public ServicioBD()
        {
            _servicioApi = new ServicioApiRest();
            _conexion = new SqliteConnection("Data Source=cinedatabase.db");
            if (Properties.Settings.Default.ultimaConexion.Day != DateTime.Now.Day || Properties.Settings.Default.ultimaConexion == null)
            {
                RellenarPeliculas();
                Properties.Settings.Default.ultimaConexion = DateTime.Now;
            }
            CrearTablas();
            RellenarSalas();
            RellenarSesiones();
        }

        private void CrearTablas()
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();
            // Código de creación proporcionado por el proyecto
            _comando.CommandText = @"DROP TABLE IF EXISTS ventas;
                                     DROP TABLE IF EXISTS sesiones;
                                     DROP TABLE IF EXISTS salas;
                                    CREATE TABLE salas (
                                        idSala     INTEGER PRIMARY KEY AUTOINCREMENT,
                                        numero     TEXT,
                                        capacidad  INTEGER,
                                        disponible BOOLEAN DEFAULT (true) 
                                    );
                                    CREATE TABLE sesiones (
                                        idSesion INTEGER PRIMARY KEY AUTOINCREMENT,
                                        pelicula INTEGER REFERENCES peliculas (idPelicula),
                                        sala     INTEGER REFERENCES salas (idSala),
                                        hora     TEXT
                                    );
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
            _comando.CommandText = @"DROP TABLE IF EXISTS ventas;
                                     DROP TABLE IF EXISTS sesiones;
                                     DROP TABLE IF EXISTS salas;
                                     DROP TABLE IF EXISTS peliculas;
                                     CREATE TABLE peliculas(
                                        idPelicula   INTEGER PRIMARY KEY,
                                        titulo       TEXT,
                                        cartel       TEXT,
                                        año          INTEGER,
                                        genero       TEXT,
                                        calificacion TEXT
                                    );";
            _comando.ExecuteNonQuery();
            _comando.CommandText = "INSERT INTO peliculas(idPelicula, titulo, cartel, año, genero, calificacion) VALUES (@idPelicula, @titulo, @cartel, @anyo, @genero, @calificacion);";
            _comando.Parameters.Add("@idPelicula", SqliteType.Integer);
            _comando.Parameters.Add("@titulo", SqliteType.Text);
            _comando.Parameters.Add("@cartel", SqliteType.Text);
            _comando.Parameters.Add("@anyo", SqliteType.Integer);
            _comando.Parameters.Add("@genero", SqliteType.Text);
            _comando.Parameters.Add("@calificacion", SqliteType.Text);
            foreach (Pelicula p in peliculas)
            {
                _comando.Parameters["@idPelicula"].Value = p.Id;
                _comando.Parameters["@titulo"].Value = p.Titulo;
                _comando.Parameters["@cartel"].Value = p.Cartel;
                _comando.Parameters["@anyo"].Value = p.Año;
                _comando.Parameters["@genero"].Value = p.Genero;
                _comando.Parameters["@calificacion"].Value = p.Calificacion;
                _comando.ExecuteNonQuery();
            }

            _conexion.Close();
        }

        private void RellenarSalas()
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "INSERT INTO salas(numero, capacidad, disponible) VALUES ('1A', 50, true);";
            _comando.ExecuteNonQuery();
            _comando.CommandText = "INSERT INTO salas(numero, capacidad, disponible) VALUES ('1B', 30, true);";
            _comando.ExecuteNonQuery();
            _comando.CommandText = "INSERT INTO salas(numero, capacidad, disponible) VALUES ('2A', 80, false);";
            _comando.ExecuteNonQuery();

            _conexion.Close();
        }

        private void RellenarSesiones()
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "INSERT INTO sesiones(pelicula, sala, hora) VALUES (1, 1, '20:00');";
            _comando.ExecuteNonQuery();
            _comando.CommandText = "INSERT INTO sesiones(pelicula, sala, hora) VALUES (5, 2, '15:00');";
            _comando.ExecuteNonQuery();
            _comando.CommandText = "INSERT INTO sesiones(pelicula, sala, hora) VALUES (1, 3, '18:30');";
            _comando.ExecuteNonQuery();

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
            SqliteCommand _comandoLocal = _conexion.CreateCommand();

            _comandoLocal.CommandText = "SELECT * FROM salas WHERE idSala=@idSala";
            _comandoLocal.Parameters.Add("@idSala", SqliteType.Integer);
            _comandoLocal.Parameters["@idSala"].Value = idSala;
            SqliteDataReader lectorSala = _comandoLocal.ExecuteReader();

            Sala resultado = null;
            if (lectorSala.HasRows)
            {
                lectorSala.Read();
                resultado = new Sala(lectorSala.GetInt32(0), lectorSala.GetString(1), lectorSala.GetInt32(2), lectorSala.GetBoolean(3));
            }

            lectorSala.Close();
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

        public bool ExisteSalaConNumero(string numero)
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "SELECT * FROM salas WHERE numerp=@numero";
            _comando.Parameters.Add("@numero", SqliteType.Text);
            _comando.Parameters["@numero"].Value = numero;
            SqliteDataReader lector = _comando.ExecuteReader();

            bool resultado = false;
            if (lector.HasRows)
            {
                resultado = true;
            }

            lector.Close();
            _conexion.Close();
            return resultado;
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
                    int idPelicula = lector.GetInt32(1);
                    int idSala = lector.GetInt32(2);
                    string hora = lector.GetString(3);
                    Pelicula p = EncontrarPelicula(idPelicula);
                    Sala s = EncontrarSala(idSala);
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
            try
            {
                _comando.CommandText = "INSERT INTO sesiones (pelicula, sala, hora) VALUES (@pelicula , @sala , @hora)";
                _comando.Parameters.Add("@pelicula", SqliteType.Integer);
                _comando.Parameters.Add("@sala", SqliteType.Integer);
                _comando.Parameters.Add("@hora", SqliteType.Text);
                _comando.Parameters["@pelicula"].Value = sesion.Pelicula.Id;
                _comando.Parameters["@sala"].Value = sesion.Sala.IdSala;
                _comando.Parameters["@hora"].Value = sesion.Hora;
                _comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Se ha intentado insertar un valor inválido en sesiones");
            }
            finally
            {
                _conexion.Close();
            }
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
            _comando.Parameters["@pelicula"].Value = sesion.Pelicula.Id;
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
        public ObservableCollection<Pelicula> ObtenerPeliculas()
        {
            ObservableCollection<Pelicula> peliculas = new ObservableCollection<Pelicula>();

            _conexion.Open();
            _comando = _conexion.CreateCommand();

            _comando.CommandText = "SELECT * FROM peliculas";
            SqliteDataReader lector = _comando.ExecuteReader();

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int idPelicula = lector.GetInt32(0);
                    string titulo = lector.GetString(1);
                    string cartel = lector.GetString(2);
                    int anyo = lector.GetInt32(3);
                    string genero = lector.GetString(4);
                    string calificacion = lector.GetString(5);
                    peliculas.Add(new Pelicula(idPelicula, titulo, cartel, anyo, genero, calificacion));
                }
            }

            lector.Close();
            _conexion.Close();
            return peliculas;
        }

        public Pelicula EncontrarPelicula(int idPelicula)
        {
            SqliteCommand _comandoLocal;
            _comandoLocal = _conexion.CreateCommand();

            _comandoLocal.CommandText = "SELECT * FROM peliculas WHERE idPelicula=@idPelicula";
            _comandoLocal.Parameters.Add("@idPelicula", SqliteType.Integer);
            _comandoLocal.Parameters["@idPelicula"].Value = idPelicula;
            SqliteDataReader lectorPelicula = _comandoLocal.ExecuteReader();

            Pelicula resultado = null;
            if (lectorPelicula.HasRows)
            {
                lectorPelicula.Read();
                resultado = new Pelicula(lectorPelicula.GetInt32(0), lectorPelicula.GetString(1), lectorPelicula.GetString(2), lectorPelicula.GetInt32(3), lectorPelicula.GetString(4), lectorPelicula.GetString(5));
            }

            lectorPelicula.Close();
            return resultado;
        }

        public bool ExistePeliculaConTitulo(string titulo)
        {
            _conexion.Open();
            _comando = _conexion.CreateCommand();

            try
            {
                _comando.CommandText = "SELECT * FROM peliculas WHERE titulo=@titulo";
                _comando.Parameters.Add("@titulo", SqliteType.Text);
                _comando.Parameters["@titulo"].Value = titulo;
                SqliteDataReader lector = _comando.ExecuteReader();

                bool resultado = false;
                if (lector.HasRows)
                {
                    resultado = true;
                }
                lector.Close();
                _conexion.Close();
                return resultado;
            }
            catch (Exception e)
            {
                Console.WriteLine("Se ha intentado buscar una pelicula a través de un título NULL");
                _conexion.Close();
                return false;
            }
            finally
            {
                _conexion.Close();
            }
        }

    }
}
