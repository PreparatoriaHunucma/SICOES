using System;

namespace SICOES2018.BO
{
    public class ModalidadAsignaturasBO
    {
        private int iDModalidadAsig;
        private String nombre;

        public int IDModalidadAsig { get => iDModalidadAsig; set => iDModalidadAsig = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}