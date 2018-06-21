using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICOES2018.BO
{
    public class CalificacionesAlumnoBO
    {
        private int iDCalificacionAlum, iDAlumno, iDAsignatura, iDMomento, iDGrupo, inasistencias;
        private decimal calificacion;

        public int IDAlumno { get => iDAlumno; set => iDAlumno = value; }
        public int IDAsignatura { get => iDAsignatura; set => iDAsignatura = value; }
        public int IDMomento { get => iDMomento; set => iDMomento = value; }
        public decimal Calificacion { get => calificacion; set => calificacion = value; }
        public int IDGrupo { get => iDGrupo; set => iDGrupo = value; }
        public int Inasistencias { get => inasistencias; set => inasistencias = value; }
        public int IDCalificacionAlum { get => iDCalificacionAlum; set => iDCalificacionAlum = value; }
    }
}