using SICOES2018.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SICOES2018.DAO
{
    public class SolicitudBajaDAO : ConexionSQL
    {
        SqlCommand cmd;

        //Para crear un aviso
        public int agregarAviso(SolicitudBajaBO datosSolicitud)
        {
            cmd = new SqlCommand("INSERT INTO SolicitudBaja (TipoBaja, Motivo, IDAlumno) VALUES (@TipoBaja, @Motivo, @IDAlumno)");

            cmd.Parameters.Add("@TipoBaja", SqlDbType.VarChar).Value = datosSolicitud.TipoBaja;
            cmd.Parameters.Add("@Motivo", SqlDbType.VarChar).Value = datosSolicitud.Motivo;
            cmd.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = datosSolicitud.IDAlumno;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        public string buscarUltimoIDAlumno(string Columna)
        {
            cmd = new SqlCommand("SELECT TOP (1) [" + Columna + "] FROM SolicitudBaja order by " + Columna + " desc;");

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, Columna);
        }


        //Para modificar el estado del aviso segun el alumno [0 = NO VISTO, 1 = VISTO]
        public int modificarEstadoAviso(SolicitudBajaBO datosSolicitud)
        {
            cmd = new SqlCommand("UPDATE SolicitudBaja SET NoOficio = @NoOficio WHERE IDSolicitud = @IDSoliciud");

            cmd.Parameters.Add("@NoOficio", SqlDbType.VarChar).Value = datosSolicitud.NoOficio;
            cmd.Parameters.Add("@IDSoliciud", SqlDbType.Int).Value = datosSolicitud.IDSolicitud;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

    }
}