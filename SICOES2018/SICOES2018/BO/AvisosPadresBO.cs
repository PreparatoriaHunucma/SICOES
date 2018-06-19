using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICOES2018.BO
{
    public class AvisosPadresBO
    {
        private int iDAviso;
        private string texto;

        public int IDAviso { get => iDAviso; set => iDAviso = value; }
        public string Texto { get => texto; set => texto = value; }
    }
}