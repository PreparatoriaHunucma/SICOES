using SICOES2018.BO;
using System.Data;
using System.Data.SqlClient;

namespace SICOES2018.DAO
{
    public class TiposAlumnoDAO : ConexionSQL
    {
        SqlCommand cmd;
        string SQLCommand;

        //Para crear un tipo de alumno
        public int agregarTipoAlumno(TipoAlumnoBO datosTipoAlumno)
        {
            cmd = new SqlCommand("INSERT INTO TipoAlumno (Nombre) VALUES (@Nombre)");

            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = datosTipoAlumno.Nombre;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para modificar el texto del tipo de alumno
        public int modificarInfoTipoAlumno(TipoAlumnoBO datosTipoAlumno)
        {
            cmd = new SqlCommand("UPDATE TipoAlumno SET Nombre = @Nombre WHERE IDTipoAlumno = @IDTipoAlumno");

            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = datosTipoAlumno.Nombre;
            cmd.Parameters.Add("@IDTipoAlumno", SqlDbType.Int).Value = datosTipoAlumno.IDTipoAlumno;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }
        //Para llenar los GridView y DDL de los paises
        public DataTable llenarTablasDDL()
        {
            SQLCommand = "SELECT * FROM TipoAlumno";
            return llenarTablas(SQLCommand);
        }

    }
}