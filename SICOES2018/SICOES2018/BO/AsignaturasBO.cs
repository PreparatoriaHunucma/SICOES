using System;

namespace SICOES2018.BO
{
    public class AsignaturasBO
    {
        private int iDAsignatura, iDSemestreAsig, iDTipoAsig, iDModalidadAsig, iDPlanEstudios, creditosAsig, horasPre, horasNoPre, duracion;
        private String nomAsig, requisitosAsig;
        private short status;

        public int IDAsignatura { get => iDAsignatura; set => iDAsignatura = value; }
        public int IDSemestreAsig { get => iDSemestreAsig; set => iDSemestreAsig = value; }
        public int IDTipoAsig { get => iDTipoAsig; set => iDTipoAsig = value; }
        public int IDModalidadAsig { get => iDModalidadAsig; set => iDModalidadAsig = value; }
        public int IDPlanEstudios { get => iDPlanEstudios; set => iDPlanEstudios = value; }
        public int CreditosAsig { get => creditosAsig; set => creditosAsig = value; }
        public int HorasPre { get => horasPre; set => horasPre = value; }
        public int HorasNoPre { get => horasNoPre; set => horasNoPre = value; }
        public int Duracion { get => duracion; set => duracion = value; }
        public string NomAsig { get => nomAsig; set => nomAsig = value; }
        public string RequisitosAsig { get => requisitosAsig; set => requisitosAsig = value; }
        public short Status { get => status; set => status = value; }
    }
}