using System;
using MySql.Data.MySqlClient;

namespace ClubDeportivo
{
    // Clase de conexión a la base de datos MySQL.
    public class Conexion
    {
        private static Conexion? _instancia;       // única instancia de la clase
        private MySqlConnection _conexion;         // objeto de conexión a MySQL

        // Cadena de conexión: servidor, base de datos, usuario y contraseña
        private const string ConnectionString =
            "Server=localhost;Database=ClubDeportivo;Uid=root;Pwd=rootpass;CharSet=utf8mb4;";

        // Constructor privado: impide crear instancias desde afuera
        private Conexion()
        {
            _conexion = new MySqlConnection(ConnectionString);
        }

        // Propiedad estática que devuelve la única instancia.
        // Si no existe todavía, la crea (instanciación perezosa).
        public static Conexion Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new Conexion();
                return _instancia;
            }
        }

        // Devuelve la conexión abierta. Si estaba cerrada o rota, la vuelve a abrir.
        public MySqlConnection ObtenerConexion()
        {
            if (_conexion.State == System.Data.ConnectionState.Closed ||
                _conexion.State == System.Data.ConnectionState.Broken)
            {
                _conexion.Open();
            }
            return _conexion;
        }

        // Cierra la conexión si estaba abierta (se llama al salir del sistema)
        public void CerrarConexion()
        {
            if (_conexion != null &&
                _conexion.State == System.Data.ConnectionState.Open)
            {
                _conexion.Close();
            }
        }
    }
}
