using SICOES2018.BO;
using System.Data;
using System.Data.SqlClient;

namespace SICOES2018.DAO
{
    public class PeriodoEscolarDAO : ConexionSQL
    {
        SqlCommand cmd;

        //Para crear un periodo
        public int agregarPeriodo(PeriodoEscolarBO datosPeriodo)
        {
            cmd = new SqlCommand("INSERT INTO PeriodoEscolar (Nombre, FechaInicio, FechaFin, IDCicloEscolar) VALUES (@Nombre, @FechaInicio, @FechaFin, @IDCicloEscolar)");

            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = datosPeriodo.Nombre;
            cmd.Parameters.Add("@FechaInicio", SqlDbType.Date).Value = datosPeriodo.FechaInicio;
            cmd.Parameters.Add("@FechaFin", SqlDbType.Date).Value = datosPeriodo.FechaFin;
            cmd.Parameters.Add("@IDCicloEscolar", SqlDbType.Int).Value = datosPeriodo.IDCicloEscolar;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para modificar el periodo
        public int modificarInfoPeriodo(PeriodoEscolarBO datosPeriodo)
        {
            cmd = new SqlCommand("UPDATE PeriodoEscolar SET Nombre = @Nombre, FechaInicio = @FechaInicio, FechaFin = @FechaFin, IDCicloEscolar = @IDCicloEscolar WHERE IDPeriodo = @IDPeriodo");

            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = datosPeriodo.Nombre;
            cmd.Parameters.Add("@FechaInicio", SqlDbType.Date).Value = datosPeriodo.FechaInicio;
            cmd.Parameters.Add("@FechaFin", SqlDbType.Date).Value = datosPeriodo.FechaFin;
            cmd.Parameters.Add("@IDCicloEscolar", SqlDbType.Int).Value = datosPeriodo.IDCicloEscolar;
            cmd.Parameters.Add("@IDPeriodo", SqlDbType.Int).Value = datosPeriodo.IDPeriodo;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }
    }
}