using System;

namespace SICOES2018.BO
{
    public class GruposBO
    {
        private int iDGrupo, iDPeriodo, iDPlanEstudio, iDSemestre;
        private String nombreGrupo;
        private short status;

        public int IDGrupo { get => iDGrupo; set => iDGrupo = value; }
        public int IDPeriodo { get => iDPeriodo; set => iDPeriodo = value; }
        public int IDPlanEstudio { get => iDPlanEstudio; set => iDPlanEstudio = value; }
        public int IDSemestre { get => iDSemestre; set => iDSemestre = value; }
        public string NombreGrupo { get => nombreGrupo; set => nombreGrupo = value; }
        public short Status { get => status; set => status = value; }
    }
}