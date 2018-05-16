namespace SICOES2018.BO
{
    public class CalificacionesBO
    {
        private int iDCalificacion, iDAlumno, iDAsignatura, iDMomento;
        private decimal calificacion;

        public int IDCalificacion { get => iDCalificacion; set => iDCalificacion = value; }
        public int IDAlumno { get => iDAlumno; set => iDAlumno = value; }
        public int IDAsignatura { get => iDAsignatura; set => iDAsignatura = value; }
        public int IDMomento { get => iDMomento; set => iDMomento = value; }
        public decimal Calificacion { get => calificacion; set => calificacion = value; }
    }
}