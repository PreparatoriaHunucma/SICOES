using SICOES2018.BO;
using System.Data;
using System.Data.SqlClient;

namespace SICOES2018.DAO
{
    public class CicloEscolarDAO : ConexionSQL
    {
        SqlCommand cmd;
        string SQLCommand;
        //Para agregar un nuevo ciclo escolar
        public int agregarCicloEscolar(CicloEscolarBO datosCicloEsc)
        {
            cmd = new SqlCommand("INSERT INTO CicloEscolar (Nombre, FechaInicio, FechaFin, Status) VALUES (@Nombre, @FechaInicio, @FechaFin, @Status)");

            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = datosCicloEsc.Nombre;
            cmd.Parameters.Add("@FechaInicio", SqlDbType.Date).Value = datosCicloEsc.FechaInicio.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@FechaFin", SqlDbType.Date).Value = datosCicloEsc.FechaFin.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@Status", SqlDbType.TinyInt).Value = datosCicloEsc.Status;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para modificar el estado del vizualizacion del ciclo escolar
        public int modificarEstadoCicloEscolar(CicloEscolarBO datosCicloEsc)
        {
            cmd = new SqlCommand("UPDATE CicloEscolar SET Status = @Status WHERE IDCicloEscolar = @IDCicloEscolar");

            cmd.Parameters.Add("@Status", SqlDbType.TinyInt).Value = datosCicloEsc.Status;
            cmd.Parameters.Add("@IDCicloEscolar", SqlDbType.Int).Value = datosCicloEsc.IDCicloEscolar;
            cmd.CommandType = CommandType.Text;

            return ejecutarComando(cmd);
        }

        //Para modificar la informacion del ciclo escolar
        public int modificarInfoCicloEscolar(CicloEscolarBO datosCicloEsc)
        {
            cmd = new SqlCommand("UPDATE CicloEscolar SET Nombre = @Nombre, FechaInicio = @FechaInicio, FechaFin = @FechaFin WHERE IDCicloEscolar = @IDCicloEscolar");

            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = datosCicloEsc.Nombre;
            cmd.Parameters.Add("@FechaInicio", SqlDbType.Date).Value = datosCicloEsc.FechaInicio;
            cmd.Parameters.Add("@FechaFin", SqlDbType.Date).Value = datosCicloEsc.FechaFin;
            cmd.Parameters.Add("@IDCicloEscolar", SqlDbType.Int).Value = datosCicloEsc.IDCicloEscolar;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para llenar los GridView de los ciclos
        public DataTable LlenarGridView()
        {
            SQLCommand = "SELECT IDCicloEscolar, Nombre, CONVERT(varchar, FechaInicio, 103) AS FechaInicio, CONVERT(varchar, FechaFin, 103) AS FechaFin, (CASE WHEN Status = '1' THEN 'Ciclo en curso' ELSE 'Ciclo concluído' END) AS Estado FROM CicloEscolar ORDER BY IDCicloEscolar DESC";
            return llenarTablas(SQLCommand);
        }

        //Buscar el dato de una tabla en especifico
        public string buscarDatoCiclo(string Columna, CicloEscolarBO datosCicloEsc )
        {
            cmd = new SqlCommand("SELECT " + Columna + " FROM CicloEscolar WHERE IDCicloEscolar = @IDCicloEscolar;");

            cmd.Parameters.Add("@IDCicloEscolar", SqlDbType.Int).Value = datosCicloEsc.IDCicloEscolar;

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, Columna);
        }

    }
}