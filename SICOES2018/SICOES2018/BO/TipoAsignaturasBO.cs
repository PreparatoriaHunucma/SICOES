using System;

namespace SICOES2018.BO
{
    public class TipoAsignaturasBO
    {
        private int iDTipoAsig;
        private String nombre;

        public int IDTipoAsig { get => iDTipoAsig; set => iDTipoAsig = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}