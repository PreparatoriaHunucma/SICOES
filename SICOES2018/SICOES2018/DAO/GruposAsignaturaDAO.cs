using SICOES2018.BO;
using System.Data;
using System.Data.SqlClient;

namespace SICOES2018.DAO
{
    public class GruposAsignaturaDAO : ConexionSQL
    {
        SqlCommand cmd;

        //Para crear registro
        public int agregarGrupoAsignatura(GrupoAsignaturaBO datosGruposAsignatura)
        {
            cmd = new SqlCommand("INSERT INTO GrupoAsignatura (IDGrupo, IDAsignatura) VALUES (@IDGrupo, @IDAsignatura)");

            cmd.Parameters.Add("@IDGrupo", SqlDbType.Int).Value = datosGruposAsignatura.IDGrupo;
            cmd.Parameters.Add("@IDAsignatura", SqlDbType.Int).Value = datosGruposAsignatura.IDAsignatura;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }


        //Para modificar el registro (Preferentemente antes de que sea visto por el alumno)
        public int modificarGrupoAsignatura(GrupoAsignaturaBO datosGruposAsignatura)
        {
            cmd = new SqlCommand("UPDATE GrupoAsignatura SET IDGrupo = @IDGrupo, IDAsignatura = @IDAsignatura WHERE IDGrupoAsig = @IDGrupoAsig");

            cmd.Parameters.Add("@IDGrupo", SqlDbType.Int).Value = datosGruposAsignatura.IDGrupo;
            cmd.Parameters.Add("@IDAsignatura", SqlDbType.Int).Value = datosGruposAsignatura.IDAsignatura;
            cmd.Parameters.Add("@IDGrupoAsig", SqlDbType.Int).Value = datosGruposAsignatura.IDGrupoAsig;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

    }
}