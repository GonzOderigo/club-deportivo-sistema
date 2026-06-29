using System;

namespace ClubDeportivo
{
    public class Carnet
    {
        public int      NroCarnet        { get; private set; }
        public int      NroSocio         { get; set; }
        public DateTime FechaEmision     { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public Carnet(int nroSocio, DateTime fechaEmision, DateTime fechaVencimiento)
        {
            NroSocio         = nroSocio;
            FechaEmision     = fechaEmision;
            FechaVencimiento = fechaVencimiento;
        }

        public bool EstaVigente() => FechaVencimiento.Date >= DateTime.Today;
    }
}
