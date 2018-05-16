namespace SICOES2018.BO
{
    public class TipoMaestroBO
    {
        private int iDTipoMaestro;
        private short directivo, secreAdmin, secreAcade, controlEsc, docente;

        public int IDTipoMaestro { get => iDTipoMaestro; set => iDTipoMaestro = value; }
        public short Directivo { get => directivo; set => directivo = value; }
        public short SecreAdmin { get => secreAdmin; set => secreAdmin = value; }
        public short SecreAcade { get => secreAcade; set => secreAcade = value; }
        public short ControlEsc { get => controlEsc; set => controlEsc = value; }
        public short Docente { get => docente; set => docente = value; }
    }
}