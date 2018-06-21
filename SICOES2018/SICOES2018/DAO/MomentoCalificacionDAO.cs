using SICOES2018.BO;
using System.Data;
using System.Data.SqlClient;

namespace SICOES2018.DAO
{
    public class MomentoCalificacionDAO : ConexionSQL
    {
        SqlCommand cmd;
        string SQLCommand;

        //Para crear un momento
        public int agregarMomento(MomentoCalificacionBO datosMomento)
        {
            cmd = new SqlCommand("INSERT INTO MomentoCalificacion (Nombre) VALUES (@Nombre)");

            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = datosMomento.Nombre;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para modificar la informacion del momento
        public int modificarInfoMomento(MomentoCalificacionBO datosMomento)
        {
            cmd = new SqlCommand("UPDATE MomentoCalificacion SET Nombre = @Nombre WHERE IDMomento = @IDMomento");

            cmd.Parameters.Add("@Nombre", SqlDbType.Text).Value = datosMomento.Nombre;
            cmd.Parameters.Add("@IDMomento", SqlDbType.Int).Value = datosMomento.IDMomento;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        public DataTable LlenarDDL()
        {
            SQLCommand = "select * from MomentoCalificacion";
            return llenarTablas(SQLCommand);
        }
        public DataTable LlenarDDLMomentoEspecifico(int IDMomento)
        {
            SQLCommand = "select * from MomentoCalificacion WHERE IDMomento =" + IDMomento;
            return llenarTablas(SQLCommand);
        }

        public DataTable Obtener3Momentos()
        {
            SQLCommand = "select top(3) IDMomento from MomentoCalificacion";
            return llenarTablas(SQLCommand);
        }
        public DataTable ObtenerTodosMomentosMomentos()
        {
            SQLCommand = "select IDMomento from MomentoCalificacion";
            return llenarTablas(SQLCommand);
        }

    }
}