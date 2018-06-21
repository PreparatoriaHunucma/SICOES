using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICOES2018.BO
{
    public class FechaCalificacionBO
    {
        private int iDFechaCalif, iDMomento, iDPeriodo;
        private DateTime fechaInicioCalif, fechaFinCalif;

        public int IDFechaCalif { get => iDFechaCalif; set => iDFechaCalif = value; }
        public int IDMomento { get => iDMomento; set => iDMomento = value; }
        public int IDPeriodo { get => iDPeriodo; set => iDPeriodo = value; }
        public DateTime FechaInicioCalif { get => fechaInicioCalif; set => fechaInicioCalif = value; }
        public DateTime FechaFinCalif { get => fechaFinCalif; set => fechaFinCalif = value; }
    }
}