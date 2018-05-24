using SICOES2018.BO;
using System.Data;
using System.Data.SqlClient;

namespace SICOES2018.DAO
{
    public class PeriodoEscolarDAO : ConexionSQL
    {
        SqlCommand cmd;
        string SQLCommand;

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
            cmd = new SqlCommand("UPDATE PeriodoEscolar SET FechaInicio = @FechaInicio, FechaFin = @FechaFin WHERE IDPeriodo = @IDPeriodo");

            cmd.Parameters.Add("@FechaInicio", SqlDbType.Date).Value = datosPeriodo.FechaInicio;
            cmd.Parameters.Add("@FechaFin", SqlDbType.Date).Value = datosPeriodo.FechaFin;
            cmd.Parameters.Add("@IDPeriodo", SqlDbType.Int).Value = datosPeriodo.IDPeriodo;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para llenar los GridView de los ciclos
        public DataTable LlenarGridViewPeriodo1(int IDCiclo)
        {
            SQLCommand = "SELECT pe.IDPeriodo, pe.Nombre, ce.Nombre AS NombreCiclo FROM PeriodoEscolar pe JOIN CicloEscolar ce ON ce.IDCicloEscolar = pe.IDCicloEscolar WHERE pe.Nombre = 'Primer Periodo' AND ce.IDCicloEscolar = " + IDCiclo;
            return llenarTablas(SQLCommand);
        }

        //Para llenar los GridView de los ciclos
        public DataTable LlenarGridViewPeriodo2(int IDCiclo)
        {
            SQLCommand = "SELECT pe.IDPeriodo, pe.Nombre, ce.Nombre AS NombreCiclo FROM PeriodoEscolar pe JOIN CicloEscolar ce ON ce.IDCicloEscolar = pe.IDCicloEscolar WHERE pe.Nombre = 'Segundo Periodo' AND ce.IDCicloEscolar = " + IDCiclo;
            return llenarTablas(SQLCommand);
        }

        //Buscar el dato de una tabla en especifico
        public string buscarDatoPeriodo(string Columna, PeriodoEscolarBO datosPeriodo)
        {
            cmd = new SqlCommand("SELECT " + Columna + " FROM PeriodoEscolar WHERE IDPeriodo = @IDPeriodo;");

            cmd.Parameters.Add("@IDPeriodo", SqlDbType.Int).Value = datosPeriodo.IDPeriodo;

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, Columna);
        }

    }
}