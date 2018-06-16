using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICOES2018.BO
{
    public class SolicitudBajaBO
    {
        private int iDSolicitud, iDAlumno, iDPeriodo;
        private string tipoBaja, motivo, noOficio;

        public int IDSolicitud { get => iDSolicitud; set => iDSolicitud = value; }
        public int IDAlumno { get => iDAlumno; set => iDAlumno = value; }
        public string NoOficio { get => noOficio; set => noOficio = value; }
        public string TipoBaja { get => tipoBaja; set => tipoBaja = value; }
        public string Motivo { get => motivo; set => motivo = value; }
        public int IDPeriodo { get => iDPeriodo; set => iDPeriodo = value; }
    }
}