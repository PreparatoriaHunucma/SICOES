using SICOES2018.BO;
using System.Data;
using System.Data.SqlClient;

namespace SICOES2018.DAO
{
    public class SemestresDAO : ConexionSQL
    {
        SqlCommand cmd;

        //Para crear un semestre
        public int agregarSemestre(SemestresBO datpsSemestre)
        {
            cmd = new SqlCommand("INSERT INTO Semestres (Nombre) VALUES (@Nombre)");

            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = datpsSemestre.Nombre;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para modificar el texto del semestre
        public int modificarInfoSemestre(SemestresBO datpsSemestre)
        {
            cmd = new SqlCommand("UPDATE Semestres SET Nombre = @Nombre WHERE IDSemestre = @IDSemestre");

            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = datpsSemestre.Nombre;
            cmd.Parameters.Add("@IDSemestre", SqlDbType.Int).Value = datpsSemestre.IDSemestre;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

    }
}