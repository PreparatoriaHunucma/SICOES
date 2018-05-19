using System;

namespace SICOES2018.BO
{
    public class EscuelasProcedenciaAlumnosBO
    {
        private int iDEscProAlumno;
        private String nombreEscPro, claveEscPro;

        public int IDEscProAlumno { get => iDEscProAlumno; set => iDEscProAlumno = value; }
        public string NombreEscPro { get => nombreEscPro; set => nombreEscPro = value; }
        public string ClaveEscPro { get => claveEscPro; set => claveEscPro = value; }
    }
}