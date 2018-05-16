using System;

namespace SICOES2018.BO
{
    public class SemestresBO
    {
        private int iDSemestre;
        private String nombre;

        public int IDSemestre { get => iDSemestre; set => iDSemestre = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}