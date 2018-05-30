using SICOES2018.BO;
using System.Data;
using System.Data.SqlClient;

namespace SICOES2018.DAO
{
    public class SemestresDAO : ConexionSQL
    {
        SqlCommand cmd;
        string SQLCommand;

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

        //Para llenar los Drop Down List de los ciclos
        public DataTable llenarDDLImpar()
        {
            SQLCommand = "SELECT * FROM dbo.Semestres WHERE IDSemestre = 1 OR IDSemestre = 3 OR IDSemestre = 5";
            return llenarTablas(SQLCommand);
        }

        public DataTable llenarDDLTodos()
        {
            SQLCommand = "SELECT * FROM dbo.Semestres";
            return llenarTablas(SQLCommand);
        }


        //Para llenar los Drop Down List de los ciclos
        public DataTable llenarDDLPar()
        {
            SQLCommand = "SELECT * FROM dbo.Semestres WHERE IDSemestre = 2 OR IDSemestre = 4 OR IDSemestre = 6";
            return llenarTablas(SQLCommand);
        }

    }
}