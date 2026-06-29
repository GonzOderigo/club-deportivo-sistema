using System;
using MySql.Data.MySqlClient;

namespace ClubDeportivo
{
    public class Socio : Persona
    {
        public int      NroSocio               { get; private set; }
        public string   Estado                 { get; set; }
        public bool     AptoFisico             { get; set; }
        public DateTime? FechaVencimientoCuota { get; set; }

        public Socio(string nombre, string apellido, string dni, bool aptoFisico)
            : base(nombre, apellido, dni)
        {
            Estado     = "activo";
            AptoFisico = aptoFisico;
        }

        public override void Registrar(MySqlConnection con)
        {
            MySqlCommand cmd = new MySqlCommand("sp_RegistrarSocio", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("p_nombre",     Nombre);
            cmd.Parameters.AddWithValue("p_apellido",   Apellido);
            cmd.Parameters.AddWithValue("p_dni",        Dni);
            cmd.Parameters.AddWithValue("p_aptoFisico", AptoFisico ? 1 : 0);
            cmd.Parameters.Add("p_resultado", MySqlDbType.Int32).Direction =
                System.Data.ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            if (Convert.ToInt32(cmd.Parameters["p_resultado"].Value) != 0)
                throw new InvalidOperationException("Ya existe un socio con ese DNI.");
        }

        public void ActualizarEstado(string nuevoEstado) => Estado = nuevoEstado;

        public bool VerificarVencimiento() =>
            FechaVencimientoCuota.HasValue && FechaVencimientoCuota.Value.Date < DateTime.Today;
    }
}
