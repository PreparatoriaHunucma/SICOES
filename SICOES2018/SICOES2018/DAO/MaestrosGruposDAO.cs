using SICOES2018.BO;
using System.Data;
using System.Data.SqlClient;

namespace SICOES2018.DAO
{
    public class MaestrosGruposDAO : ConexionSQL
    {
        SqlCommand cmd;

        //Para crear un aviso
        public int agregarMaestroGrupo(MaestroGruposBO datosMaestroGrupo)
        {
            cmd = new SqlCommand("INSERT INTO MaestroGrupos (IDMaestro, IDGrupo, IDAsignatura, IDPeriodo) VALUES (@IDMaestro, @IDGrupo, @IDAsignatura, @IDPeriodo)");

            cmd.Parameters.Add("@IDMaestro", SqlDbType.Int).Value = datosMaestroGrupo.IDMaestro;
            cmd.Parameters.Add("@IDGrupo", SqlDbType.Int).Value = datosMaestroGrupo.IDGrupo;
            cmd.Parameters.Add("@IDAsignatura", SqlDbType.Int).Value = datosMaestroGrupo.IDAsignatura;
            cmd.Parameters.Add("@IDPeriodo", SqlDbType.Int).Value = datosMaestroGrupo.IDPeriodo;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para modificar el registro de la asignacion del maestro
        public int modificarRegistroMaestroGrupo(MaestroGruposBO datosMaestroGrupo)
        {
            cmd = new SqlCommand("UPDATE MaestroGrupos SET IDMaestro = @IDMaestro, IDGrupo = @IDGrupo, IDAsignatura = @IDAsignatura, IDPeriodo = @IDPeriodo WHERE IDMaestroGrupo = @IDMaestroGrupo");

            cmd.Parameters.Add("@IDMaestro", SqlDbType.Int).Value = datosMaestroGrupo.IDMaestro;
            cmd.Parameters.Add("@IDGrupo", SqlDbType.Int).Value = datosMaestroGrupo.IDGrupo;
            cmd.Parameters.Add("@IDAsignatura", SqlDbType.Int).Value = datosMaestroGrupo.IDAsignatura;
            cmd.Parameters.Add("@IDPeriodo", SqlDbType.Int).Value = datosMaestroGrupo.IDPeriodo;
            cmd.Parameters.Add("@IDMaestroGrupo", SqlDbType.Int).Value = datosMaestroGrupo.IDMaestroGrupo;
            cmd.CommandType = CommandType.Text;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }
    }
}