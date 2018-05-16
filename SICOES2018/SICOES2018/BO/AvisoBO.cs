using System;

namespace SICOES2018.BO
{
    public class AvisoBO
    {
        private int iDAviso, iDMaestro, iDAlumno;
        private String textoAviso;
        private short estadoAviso;

        public int IDAviso { get => iDAviso; set => iDAviso = value; }
        public int IDMaestro { get => iDMaestro; set => iDMaestro = value; }
        public int IDAlumno { get => iDAlumno; set => iDAlumno = value; }
        public string TextoAviso { get => textoAviso; set => textoAviso = value; }
        public short EstadoAviso { get => estadoAviso; set => estadoAviso = value; }
    }
}