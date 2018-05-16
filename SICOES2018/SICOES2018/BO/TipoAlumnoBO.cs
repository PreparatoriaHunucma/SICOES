using System;

namespace SICOES2018.BO
{
    public class TipoAlumnoBO
    {
        private int iDTipoAlumno;
        private String nombre;

        public int IDTipoAlumno { get => iDTipoAlumno; set => iDTipoAlumno = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}