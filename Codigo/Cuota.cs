using System;

namespace ClubDeportivo
{
    public class Cuota
    {
        public int      NroCuota         { get; private set; }
        public int      NroSocio         { get; set; }
        public string   Tipo             { get; set; }   // "mensual" | "diaria"
        public decimal  Monto            { get; set; }
        public string   MedioPago        { get; set; }   // "efectivo" | "tarjeta"
        public int      CantCuotas       { get; set; }   // 1 | 3 | 6 (solo tarjeta)
        public DateTime FechaPago        { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string   Estado           { get; set; }   // "pagada" | "vencida"

        public Cuota(int nroSocio, string tipo, decimal monto,
                     string medioPago, int cantCuotas, DateTime fechaPago)
        {
            NroSocio   = nroSocio;
            Tipo       = tipo;
            Monto      = monto;
            MedioPago  = medioPago;
            CantCuotas = cantCuotas;
            FechaPago  = fechaPago;
            Estado     = "pagada";

            FechaVencimiento = tipo == "mensual"
                ? fechaPago.AddMonths(1)
                : fechaPago.AddDays(1);
        }

        public bool EstaVencida() => FechaVencimiento.Date < DateTime.Today;
    }
}
