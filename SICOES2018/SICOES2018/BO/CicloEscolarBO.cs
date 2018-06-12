using System;

namespace SICOES2018.BO
{
    public class CicloEscolarBO
    {
        private int iDCicloEscolar;
        private String nombre;
        private DateTime fechaInicio, fechaFin, fechaInicioDocs, fechaFinDocs;
        private short status;

        public int IDCicloEscolar { get => iDCicloEscolar; set => iDCicloEscolar = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
        public short Status { get => status; set => status = value; }
        public DateTime FechaInicioDocs { get => fechaInicioDocs; set => fechaInicioDocs = value; }
        public DateTime FechaFinDocs { get => fechaFinDocs; set => fechaFinDocs = value; }
    }
}