using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICOES2018.BO
{
    public class MensajesBO
    {
        private int iDMensaje, iDRemitente, iDDestinatario;
        private string asunto, mensaje;
        private DateTime fecha;

        public int IDMensaje { get => iDMensaje; set => iDMensaje = value; }
        public int IDRemitente { get => iDRemitente; set => iDRemitente = value; }
        public int IDDestinatario { get => iDDestinatario; set => iDDestinatario = value; }
        public string Asunto { get => asunto; set => asunto = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
}