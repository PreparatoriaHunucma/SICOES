using System;

namespace SICOES2018.BO
{
    public class DatosEscuelaBO
    {
        private int iDEscuela, iDMunicipio, iDDepartamentos;
        private String nombreEsc, claveEsc, calleEsc, numeroEsc, coloniaEsc, codigoPostalEsc, telEsc, emailEsc;

        public int IDEscuela { get => iDEscuela; set => iDEscuela = value; }
        public int IDMunicipio { get => iDMunicipio; set => iDMunicipio = value; }
        public int IDDepartamentos { get => iDDepartamentos; set => iDDepartamentos = value; }
        public string NombreEsc { get => nombreEsc; set => nombreEsc = value; }
        public string ClaveEsc { get => claveEsc; set => claveEsc = value; }
        public string CalleEsc { get => calleEsc; set => calleEsc = value; }
        public string NumeroEsc { get => numeroEsc; set => numeroEsc = value; }
        public string ColoniaEsc { get => coloniaEsc; set => coloniaEsc = value; }
        public string CodigoPostalEsc { get => codigoPostalEsc; set => codigoPostalEsc = value; }
        public string TelEsc { get => telEsc; set => telEsc = value; }
        public string EmailEsc { get => emailEsc; set => emailEsc = value; }
    }
}