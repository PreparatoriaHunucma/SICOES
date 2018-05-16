using System;

namespace SICOES2018.BO
{
    public class EstadoBO
    {
        private int iDEstado, iDPais;
        private String nombre;

        public int IDEstado { get => iDEstado; set => iDEstado = value; }
        public int IDPais { get => iDPais; set => iDPais = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}