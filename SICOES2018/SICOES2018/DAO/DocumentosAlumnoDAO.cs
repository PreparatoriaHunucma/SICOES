using System.Data;
using System.Data.SqlClient;
using SICOES2018.BO;

namespace SICOES2018.DAO
{
    public class DocumentosAlumnoDAO: ConexionSQL
    {
        SqlCommand cmd;

        //Para crear un registro de documentos [0 = NO ENTREGADO, 1 = ENTREGADO]
        public int agregarRegistroDocumentos(DocumentosAlumnoBO datosDocumentosAlumno)
        {
            cmd = new SqlCommand("INSERT INTO DocumentosAlumno (ActaNacimiento, Fotografias, Curp, Constancia, ComprobanteDomiciliario, BoletaCalificaciones, CertificadoParcial, OficioRevalidacion, ConstanciaMedia, CertificadoSecundaria, Otros) VALUES (@ActaNacimiento, @Fotografias, @Curp, @Constancia, @ComprobanteDomiciliario, @BoletaCalificaciones, @CertificadoParcial, @OficioRevalidacion, @ConstanciaMedia, @CertificadoSecundaria, @Otros)");

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
            cmd.Parameters.Add("@Otros", SqlDbType.VarChar).Value = datosDocumentosAlumno.Otros;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para modificar el estado de los documentos [0 = NO ENTREGADO, 1 = ENTREGADO]
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
            cmd.Parameters.Add("@Otros", SqlDbType.VarChar).Value = datosDocumentosAlumno.Otros;
            cmd.Parameters.Add("@IDDocumentos", SqlDbType.Int).Value = datosDocumentosAlumno.IDDocumentos;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Buscar el dato de una tabla en especifico
        public string buscarUltimoIDDocs(string Columna)
        {
            cmd = new SqlCommand("SELECT TOP (1) ["+Columna+"] FROM DocumentosAlumno order by "+Columna+" desc;");

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, Columna);
        }

        //Buscar el dato de una tabla en especifico
        public string buscarDatoDocs(string Columna, DocumentosAlumnoBO datosDocumentosAlumno)
        {
            cmd = new SqlCommand("SELECT " + Columna + " FROM DocumentosAlumno WHERE IDDocumentos = @IDDocumentos;");

            cmd.Parameters.Add("@IDDocumentos", SqlDbType.Int).Value = datosDocumentosAlumno.IDDocumentos;

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, Columna);
        }

    }
}