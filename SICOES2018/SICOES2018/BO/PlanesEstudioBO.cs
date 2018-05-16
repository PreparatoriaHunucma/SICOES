using System;

namespace SICOES2018.BO
{
    public class PlanesEstudioBO
    {
        private int iDPlanEstudios;
        private String nombre;
        private short status;

        public int IDPlanEstudios { get => iDPlanEstudios; set => iDPlanEstudios = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public short Status { get => status; set => status = value; }
    }
}