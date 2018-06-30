using SICOES2018.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SICOES2018.DAO
{
    public class FechaCalificacionDAO : ConexionSQL
    {
        SqlCommand cmd;

        //Para crear un aviso
        public int agregarAviso(FechaCalificacionBO datoFechaCalif)
        {
            cmd = new SqlCommand("INSERT INTO FechaCalificacion (IDPeriodo, IDMomento, FechaInicioCalif, FechaFinCalif) VALUES (@IDPeriodo, @IDMomento, @FechaInicioCalif, @FechaFinCalif)");

            cmd.Parameters.Add("@IDPeriodo", SqlDbType.Int).Value = datoFechaCalif.IDPeriodo;
            cmd.Parameters.Add("@IDMomento", SqlDbType.Int).Value = datoFechaCalif.IDMomento;
            cmd.Parameters.Add("@FechaInicioCalif", SqlDbType.Date).Value = datoFechaCalif.FechaInicioCalif.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@FechaFinCalif", SqlDbType.Date).Value = datoFechaCalif.FechaFinCalif.ToString("yyyy-MM-dd");

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }
        public string buscarUltimoIDPeriodo()
        {
            cmd = new SqlCommand("SELECT TOP (1) IDPeriodo FROM PeriodoEscolar order by IDPeriodo desc;");

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, "IDPeriodo");
        }

        //Para modificar el estado del aviso segun el alumno [0 = NO VISTO, 1 = VISTO]
        public int modificarInfoFechaCalif(FechaCalificacionBO datoFechaCalif)
        {
            cmd = new SqlCommand("UPDATE FechaCalificacion SET FechaInicioCalif = @FechaInicioCalif, FechaFinCalif = @FechaFinCalif WHERE IDPeriodo = @IDPeriodo AND IDMomento = @IDMomento");

            cmd.Parameters.Add("@IDPeriodo", SqlDbType.Int).Value = datoFechaCalif.IDPeriodo;
            cmd.Parameters.Add("@IDMomento", SqlDbType.Int).Value = datoFechaCalif.IDMomento;
            cmd.Parameters.Add("@FechaInicioCalif", SqlDbType.Date).Value = datoFechaCalif.FechaInicioCalif.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@FechaFinCalif", SqlDbType.Date).Value = datoFechaCalif.FechaFinCalif.ToString("yyyy-MM-dd");

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }
        public string buscarDatoFechaCalif(string Columna, FechaCalificacionBO datoPeriodo, int IDMomento)
        {
            cmd = new SqlCommand("SELECT " + Columna + " FROM FechaCalificacion WHERE IDPeriodo = @IDPeriodo AND IDMomento = " + IDMomento);

            cmd.Parameters.Add("@IDPeriodo", SqlDbType.Int).Value = datoPeriodo.IDPeriodo;

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, Columna);
        }

    }
}