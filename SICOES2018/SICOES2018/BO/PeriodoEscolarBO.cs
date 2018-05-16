using System;

namespace SICOES2018.BO
{
    public class PeriodoEscolarBO
    {
        private int iDPeriodo, iDCicloEscolar;
        private String nombre;
        private DateTime fechaInicio, fechaFin;

        public int IDPeriodo { get => iDPeriodo; set => iDPeriodo = value; }
        public int IDCicloEscolar { get => iDCicloEscolar; set => iDCicloEscolar = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
    }
}