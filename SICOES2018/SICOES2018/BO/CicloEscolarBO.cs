using System;

namespace SICOES2018.BO
{
    public class CicloEscolarBO
    {
        private int iDCicloEscolar;
        private String nombre;
        private DateTime fechaInicio, fechaFin;
        private short status;

        public int IDCicloEscolar { get => iDCicloEscolar; set => iDCicloEscolar = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
        public short Status { get => status; set => status = value; }
    }
}