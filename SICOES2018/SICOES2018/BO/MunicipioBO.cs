using System;

namespace SICOES2018.BO
{
    public class MunicipioBO
    {
        private int iDMunicipio, iDEstado;
        private String nombre;

        public int IDMunicipio { get => iDMunicipio; set => iDMunicipio = value; }
        public int IDEstado { get => iDEstado; set => iDEstado = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}