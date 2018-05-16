using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SICOES2018.BO;

namespace SICOES2018.DAO
{
    public class DocumentosAlumnoDAO: ConexionSQL
    {
        SqlCommand cmd;
        //Para modificar el estado del aviso segun el alumno [0 = NO VISTO, 1 = VISTO]
        public int modificarDocumentos(DocumentosAlumnoBO datosDocumentosAlumno)
        {
            cmd = new SqlCommand("UPDATE DocumentosAlumno SET ActaNacimiento, Fotografias, Curp, Constancia, ComprobanteDomiciliario, BoletaCalificaciones, , CertificadoParcial, OficioRevalidacion, ConstanciaMedia, CertificadoSecundaria, Otros = @ActaNacimiento WHERE IDDocumentos = @IDDocumentos");

            cmd.Parameters.Add("@ActaNacimiento", SqlDbType.TinyInt).Value = datosDocumentosAlumno.ActaNacimiento;

            cmd.Parameters.Add("@IDDocumentos", SqlDbType.Int).Value = datosDocumentosAlumno.IDDocumentos;
            cmd.CommandType = CommandType.Text;

            return ejecutarComando(cmd);
        }


    }
}