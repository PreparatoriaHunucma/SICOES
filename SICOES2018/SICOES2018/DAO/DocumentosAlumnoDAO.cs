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
            cmd = new SqlCommand("UPDATE DocumentosAlumno SET ActaNacimiento = @ActaNacimiento, Fotografias = @Fotografias, Curp = @Curp, Constancia = @Constancia, ComprobanteDomiciliario = @ComprobanteDomiciliario, BoletaCalificaciones = @BoletaCalificaciones, CertificadoParcial = @CertificadoParcial, OficioRevalidacion = @OficioRevalidacion, ConstanciaMedia = @ConstanciaMedia, CertificadoSecundaria = @CertificadoSecundaria, Otros = @Otros WHERE IDDocumentos = @IDDocumentos");

            cmd.Parameters.Add("@ActaNacimiento", SqlDbType.TinyInt).Value = datosDocumentosAlumno.ActaNacimiento;
            cmd.Parameters.Add("@Fotografias", SqlDbType.TinyInt).Value = datosDocumentosAlumno.Fotografias;
            cmd.Parameters.Add("@Curp", SqlDbType.TinyInt).Value = datosDocumentosAlumno.Curp;
            cmd.Parameters.Add("@Constancia", SqlDbType.TinyInt).Value = datosDocumentosAlumno.Constancia;
            cmd.Parameters.Add("@ComprobanteDomiciliario", SqlDbType.TinyInt).Value = datosDocumentosAlumno.CompromanteDomiciliario;
            cmd.Parameters.Add("@BoletaCalificaciones", SqlDbType.TinyInt).Value = datosDocumentosAlumno.BoletaCalificaciones;
            cmd.Parameters.Add("@CertificadoParcial", SqlDbType.TinyInt).Value = datosDocumentosAlumno.CertificadoParcial;
            cmd.Parameters.Add("@OficioRevalidacion", SqlDbType.TinyInt).Value = datosDocumentosAlumno.OficioRevalidacion;
            cmd.Parameters.Add("@ConstanciaMedia", SqlDbType.TinyInt).Value = datosDocumentosAlumno.ConstanciaMedia;
            cmd.Parameters.Add("@CertificadoSecundaria", SqlDbType.TinyInt).Value = datosDocumentosAlumno.CertificadoSecundaria;
            cmd.Parameters.Add("@Otros", SqlDbType.TinyInt).Value = datosDocumentosAlumno.Otros1;
            cmd.Parameters.Add("@IDDocumentos", SqlDbType.Int).Value = datosDocumentosAlumno.IDDocumentos;
            cmd.CommandType = CommandType.Text;

            return ejecutarComando(cmd);
        }


    }
}