using System;

namespace SICOES2018.BO
{
    public class DocumentosAlumnoBO
    {
        private int iDDocumentos;
        private short actaNacimiento, fotografias, curp, constancia, compromanteDomiciliario, boletaCalificaciones, certificadoParcial, oficioRevalidacion, constanciaMedia, certificadoSecundaria;
        private String Otros;

        public int IDDocumentos { get => iDDocumentos; set => iDDocumentos = value; }
        public short ActaNacimiento { get => actaNacimiento; set => actaNacimiento = value; }
        public short Fotografias { get => fotografias; set => fotografias = value; }
        public short Curp { get => curp; set => curp = value; }
        public short Constancia { get => constancia; set => constancia = value; }
        public short CompromanteDomiciliario { get => compromanteDomiciliario; set => compromanteDomiciliario = value; }
        public short BoletaCalificaciones { get => boletaCalificaciones; set => boletaCalificaciones = value; }
        public short CertificadoParcial { get => certificadoParcial; set => certificadoParcial = value; }
        public short OficioRevalidacion { get => oficioRevalidacion; set => oficioRevalidacion = value; }
        public short ConstanciaMedia { get => constanciaMedia; set => constanciaMedia = value; }
        public short CertificadoSecundaria { get => certificadoSecundaria; set => certificadoSecundaria = value; }
        public string Otros1 { get => Otros; set => Otros = value; }
    }
}