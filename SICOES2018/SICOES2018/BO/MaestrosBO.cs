using System;

namespace SICOES2018.BO
{
    public class MaestrosBO
    {
        private int iDMaestro, iDTipoMaestro, idMunicipioMaestro;
        private String nomMaestro, apePatMaestro, apeMatMaestro, telMaestro, correoMaestro, fotoMaestro, curriculumMaestro, gradoAcademicoMaestro, direccionMaestro, usuarioMaestro, contrasenhaMaestro;
        private long cedulaMaestro;
        private DateTime ingresoMaestro;
        private short statusMaestro;

        public int IDMaestro { get => iDMaestro; set => iDMaestro = value; }
        public int IDTipoMaestro { get => iDTipoMaestro; set => iDTipoMaestro = value; }
        public int IdMunicipioMaestro { get => idMunicipioMaestro; set => idMunicipioMaestro = value; }
        public string NomMaestro { get => nomMaestro; set => nomMaestro = value; }
        public string ApePatMaestro { get => apePatMaestro; set => apePatMaestro = value; }
        public string ApeMatMaestro { get => apeMatMaestro; set => apeMatMaestro = value; }
        public string TelMaestro { get => telMaestro; set => telMaestro = value; }
        public string CorreoMaestro { get => correoMaestro; set => correoMaestro = value; }
        public string FotoMaestro { get => fotoMaestro; set => fotoMaestro = value; }
        public string CurriculumMaestro { get => curriculumMaestro; set => curriculumMaestro = value; }
        public string GradoAcademicoMaestro { get => gradoAcademicoMaestro; set => gradoAcademicoMaestro = value; }
        public string DireccionMaestro { get => direccionMaestro; set => direccionMaestro = value; }
        public string UsuarioMaestro { get => usuarioMaestro; set => usuarioMaestro = value; }
        public string ContrasenhaMaestro { get => contrasenhaMaestro; set => contrasenhaMaestro = value; }
        public long CedulaMaestro { get => cedulaMaestro; set => cedulaMaestro = value; }
        public DateTime IngresoMaestro { get => ingresoMaestro; set => ingresoMaestro = value; }
        public short StatusMaestro { get => statusMaestro; set => statusMaestro = value; }
    }
}