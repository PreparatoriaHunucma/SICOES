using SICOES2018.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SICOES2018.DAO
{
    public class MensajesDAO : ConexionSQL
    {
        SqlCommand cmd;
        string SQLCommand;

        //Para crear un aviso
        public int agregarMensaje(MensajesBO datoMsg)
        {
            cmd = new SqlCommand("INSERT INTO Mensajes (IDRemitente, IDDestinatario, Asunto, Mensaje, Fecha) VALUES (@IDRemitente, @IDDestinatario, @Asunto, @Mensaje, GETDATE())");

            cmd.Parameters.Add("@IDRemitente", SqlDbType.Int).Value = datoMsg.IDRemitente;
            cmd.Parameters.Add("@IDDestinatario", SqlDbType.Int).Value = datoMsg.IDDestinatario;
            cmd.Parameters.Add("@Asunto", SqlDbType.VarChar).Value = datoMsg.Asunto;
            cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar).Value = datoMsg.Mensaje;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        public DataTable LlenarGVMensajes(int IDMaestro)
        {
            SQLCommand = "SELECT msg.IDMensaje, CONCAT(al.ApePatAlumno, ' ', al.ApeMatAlumno, ' ', al.NomAlumno) AS Remitente, msg.Asunto, msg.Fecha FROM Mensajes msg JOIN Alumnos al ON al.IDAlumno = msg.IDRemitente JOIN Maestros ma ON ma.IDMaestro = msg.IDDestinatario WHERE msg.IDDestinatario = " + IDMaestro + " ORDER BY msg.IDMensaje DESC";

            return llenarTablas(SQLCommand);
        }

        public DataTable LlenarGVMensajesAlumno(int IDAlumno)
        {
            SQLCommand = "SELECT msg.IDMensaje, CONCAT(ma.ApePatMaestro, ' ', ma.ApeMatMaestro, ' ', ma.NomMaestro) AS Remitente, msg.Asunto, msg.Fecha FROM Mensajes msg JOIN Alumnos al ON al.IDAlumno = msg.IDDestinatario JOIN Maestros ma ON ma.IDMaestro = msg.IDRemitente WHERE msg.IDDestinatario = " + IDAlumno + " ORDER BY msg.IDMensaje DESC";

            return llenarTablas(SQLCommand);
        }

        public DataTable LlenarGVMaestros(int IDGrupo)
        {
            SQLCommand = "SELECT mg.IDMaestro, ma.NomMaestro, a.NomAsig FROM MaestroGrupos mg JOIN Maestros ma ON ma.IDMaestro = mg.IDMaestro JOIN Asignaturas a ON a.IDAsignatura = mg.IDAsignatura WHERE mg.IDGrupo = " + IDGrupo;

            return llenarTablas(SQLCommand);
        }

        public string buscarDatoMensaje(string Columna, MensajesBO datoMsg)
        {
            cmd = new SqlCommand("SELECT " + Columna + " FROM Mensajes WHERE IDMensaje = @IDMensaje;");

            cmd.Parameters.Add("@IDMensaje", SqlDbType.Int).Value = datoMsg.IDMensaje;

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, Columna);
        }

    }
}