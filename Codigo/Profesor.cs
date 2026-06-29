using System;

namespace ClubDeportivo
{
    public class Profesor : Persona
    {
        public int    NroProfesor     { get; private set; }
        public string Especialidad    { get; set; }
        public string HorarioAsignado { get; set; }
        public decimal Sueldo         { get; set; }

        public Profesor(string nombre, string apellido, string dni,
                        string especialidad, string horarioAsignado, decimal sueldo)
            : base(nombre, apellido, dni)
        {
            Especialidad    = especialidad;
            HorarioAsignado = horarioAsignado;
            Sueldo          = sueldo;
        }

        // Registrar no aplica al flujo del sistema actual (fuera del alcance codificado).
        // Se implementa para cumplir el contrato de la clase abstracta Persona : IRegistrable.
        public override void Registrar(MySql.Data.MySqlClient.MySqlConnection con)
        {
            throw new NotImplementedException(
                "El registro de profesores no está implementado en este módulo.");
        }
    }
}
