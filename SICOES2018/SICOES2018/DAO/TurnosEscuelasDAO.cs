using SICOES2018.BO;
using System.Data;
using System.Data.SqlClient;

namespace SICOES2018.DAO
{
    public class TurnosEscuelasDAO : ConexionSQL
    {
        SqlCommand cmd;
        string SQLCommand;
        //Para crear un turno escolar
        public int agregarTurnoEscuela(TurnosEscuelasBO datosTurnos)
        {
            cmd = new SqlCommand("INSERT INTO TurnosEscuelas (Nombre) VALUES (@Nombre)");

            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = datosTurnos.Nombre;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para modificar el texto del turno
        public int modificarInfoTurno(TurnosEscuelasBO datosTurnos)
        {
            cmd = new SqlCommand("UPDATE TurnosEscuelas SET Nombre = @Nombre WHERE IDTurno = @IDTurno");

            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = datosTurnos.Nombre;
            cmd.Parameters.Add("@IDTurno", SqlDbType.Int).Value = datosTurnos.IDTurno;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        public DataTable llenarDDL()
        {
            SQLCommand = "SELECT * FROM TurnosEscuelas";
            return llenarTablas(SQLCommand);
        }

    }
}