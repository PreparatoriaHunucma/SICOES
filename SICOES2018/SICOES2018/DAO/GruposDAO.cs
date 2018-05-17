using SICOES2018.BO;
using System.Data;
using System.Data.SqlClient;

namespace SICOES2018.DAO
{
    public class GruposDAO : ConexionSQL
    {
        SqlCommand cmd;

        //Para crear un grupo
        public int agregarGrupo(GruposBO datosGrupo)
        {
            cmd = new SqlCommand("INSERT INTO Grupos (NombreGrupo, IDPeriodo, IDPlanEstudio, IDSemestre, Status) VALUES (@NombreGrupo, @IDPeriodo, @IDPlanEstudio, @IDSemestre, @Status)");

            cmd.Parameters.Add("@NombreGrupo", SqlDbType.VarChar).Value = datosGrupo.NombreGrupo;
            cmd.Parameters.Add("@IDPeriodo", SqlDbType.Int).Value = datosGrupo.IDPeriodo;
            cmd.Parameters.Add("@IDPlanEstudio", SqlDbType.Int).Value = datosGrupo.IDPlanEstudio;
            cmd.Parameters.Add("@IDSemestre", SqlDbType.Int).Value = datosGrupo.IDSemestre;
            cmd.Parameters.Add("@Status", SqlDbType.TinyInt).Value = datosGrupo.Status;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para modificar el estado del grupo
        public int modificarEstadoGrupo(GruposBO datosGrupo)
        {
            cmd = new SqlCommand("UPDATE Grupos SET Status = @Status WHERE IDGrupo = @IDGrupo");

            cmd.Parameters.Add("@Status", SqlDbType.TinyInt).Value = datosGrupo.Status;
            cmd.Parameters.Add("@IDGrupo", SqlDbType.Int).Value = datosGrupo.IDGrupo;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para modificar la informacion del grupo
        public int modificarInfoAviso(GruposBO datosGrupo)
        {
            cmd = new SqlCommand("UPDATE Aviso SET NombreGrupo = @NombreGrupo, IDPeriodo = @IDPeriodo, IDPlanEstudio = @IDPlanEstudio, IDSemestre = @IDSemestre WHERE IDGrupo = @IDGrupo");

            cmd.Parameters.Add("@NombreGrupo", SqlDbType.VarChar).Value = datosGrupo.NombreGrupo;
            cmd.Parameters.Add("@IDPeriodo", SqlDbType.Int).Value = datosGrupo.IDPeriodo;
            cmd.Parameters.Add("@IDPlanEstudio", SqlDbType.Int).Value = datosGrupo.IDPlanEstudio;
            cmd.Parameters.Add("@IDSemestre", SqlDbType.Int).Value = datosGrupo.IDSemestre;
            cmd.Parameters.Add("@IDGrupo", SqlDbType.Int).Value = datosGrupo.IDGrupo;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }
    }
}