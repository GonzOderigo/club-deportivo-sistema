using System;
using MySql.Data.MySqlClient;

namespace ClubDeportivo
{
    // Hereda los atributos comunes (Nombre, Apellido, Dni) de Persona.
    // No agrega atributos propios. Implementa Registrar() con sp_RegistrarNoSocio.
    public class NoSocio : Persona
    {
        public NoSocio(string nombre, string apellido, string dni)
            : base(nombre, apellido, dni) { }

        public override void Registrar(MySqlConnection con)
        {
            MySqlCommand cmd = new MySqlCommand("sp_RegistrarNoSocio", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("p_nombre",   Nombre);
            cmd.Parameters.AddWithValue("p_apellido", Apellido);
            cmd.Parameters.AddWithValue("p_dni",      Dni);
            cmd.Parameters.Add("p_resultado", MySqlDbType.Int32).Direction =
                System.Data.ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            if (Convert.ToInt32(cmd.Parameters["p_resultado"].Value) != 0)
                throw new InvalidOperationException("Ya existe un no socio con ese DNI.");
        }
    }
}
