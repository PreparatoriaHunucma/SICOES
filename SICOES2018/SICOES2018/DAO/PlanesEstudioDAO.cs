using SICOES2018.BO;
using System.Data;
using System.Data.SqlClient;

namespace SICOES2018.DAO
{
    public class PlanesEstudioDAO : ConexionSQL
    {
        SqlCommand cmd;

        //Para crear un plan de estudio
        public int agregarPlanEstudio(PlanesEstudioBO datosPlanes)
        {
            cmd = new SqlCommand("INSERT INTO PlanesEstudio (Nombre, Status) VALUES (@Nombre, @Status)");

            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = datosPlanes.Nombre;
            cmd.Parameters.Add("@Status", SqlDbType.TinyInt).Value = datosPlanes.Status;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para modificar el estado del plan de estudio
        public int modificarEstadoPlanEstudio(PlanesEstudioBO datosPlanes)
        {
            cmd = new SqlCommand("UPDATE PlanesEstudio SET Status = @Status WHERE IDPlanEstudios = @IDPlanEstudios");

            cmd.Parameters.Add("@Status", SqlDbType.TinyInt).Value = datosPlanes.Status;
            cmd.Parameters.Add("@IDPlanEstudios", SqlDbType.Int).Value = datosPlanes.IDPlanEstudios;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para modificar el texto del aviso (Preferentemente antes de que sea visto por el alumno)
        public int modificarInfoPlanEstudio(PlanesEstudioBO datosPlanes)
        {
            cmd = new SqlCommand("UPDATE PlanesEstudio SET Nombre = @Nombre WHERE IDPlanEstudios = @IDPlanEstudios");

            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = datosPlanes.Nombre;
            cmd.Parameters.Add("@IDPlanEstudios", SqlDbType.Int).Value = datosPlanes.IDPlanEstudios;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

    }
}