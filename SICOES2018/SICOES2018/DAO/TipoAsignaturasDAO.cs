using SICOES2018.BO;
using System.Data;
using System.Data.SqlClient;

namespace SICOES2018.DAO
{
    public class TipoAsignaturasDAO : ConexionSQL
    {
        SqlCommand cmd;

        //Para crear un tipo de asignatura
        public int agregarTipoAlumno(TipoAsignaturasBO datosTipoAsignatura)
        {
            cmd = new SqlCommand("INSERT INTO TipoAsignaturas (Nombre) VALUES (@Nombre)");

            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = datosTipoAsignatura.Nombre;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para modificar el texto del tipo de asignatura
        public int modificarInfoTipoAlumno(TipoAsignaturasBO datosTipoAsignatura)
        {
            cmd = new SqlCommand("UPDATE TipoAsignaturas SET Nombre = @Nombre WHERE IDTipoAsig = @IDTipoAsig");

            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = datosTipoAsignatura.Nombre;
            cmd.Parameters.Add("@IDTipoAsig", SqlDbType.Int).Value = datosTipoAsignatura.IDTipoAsig;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

    }
}