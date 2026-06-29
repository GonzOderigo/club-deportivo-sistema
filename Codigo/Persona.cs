using System;
using MySql.Data.MySqlClient;

namespace ClubDeportivo
{
    // Clase base abstracta que representa a cualquier persona registrada en el sistema.
    // Define los atributos comunes y obliga a las subclases a implementar Registrar().
    public abstract class Persona : IRegistrable
    {
        public string Nombre   { get; set; }
        public string Apellido { get; set; }
        public string Dni      { get; set; }

        protected Persona(string nombre, string apellido, string dni)
        {
            Nombre   = nombre;
            Apellido = apellido;
            Dni      = dni;
        }

        // Método abstracto: cada subclase lo implementa según su tabla y stored procedure.
        public abstract void Registrar(MySqlConnection con);
    }
}
