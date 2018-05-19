using System.Data;
using System.Data.SqlClient;
using SICOES2018.BO;

namespace SICOES2018.DAO
{
    public class EscuelasProcedenciaAlumnosDAO : ConexionSQL
    {
        SqlCommand cmd;
        string SQLCommand;

        //Agregar una nueva escuela de procedencia
        public int agregarEscuelaPro(EscuelasProcedenciaAlumnosBO datosEscuelasProcedenciaAlumnos)
        {
            cmd = new SqlCommand("INSERT INTO EscuelasProcedenciaAlumnos (NombreEscPro, ClaveEscPro) VALUES (@NombreEscPro, @ClaveEscPro)");

            cmd.Parameters.Add("@NombreEscPro", SqlDbType.VarChar).Value = datosEscuelasProcedenciaAlumnos.NombreEscPro;
            cmd.Parameters.Add("@ClaveEscPro", SqlDbType.VarChar).Value = datosEscuelasProcedenciaAlumnos.ClaveEscPro;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para modificar el nombre de la escuela de procedencia
        public int modificarInfoEscuelaProc(EscuelasProcedenciaAlumnosBO datosEscuelasProcedenciaAlumnos)
        {
            cmd = new SqlCommand("UPDATE EscuelasProcedenciaAlumnos SET NombreEscPro = @NombreEscPro, ClaveEscPro = @ClaveEscPro WHERE IDEscProAlumno = @IDEscProAlumno");

            cmd.Parameters.Add("@NombreEscPro", SqlDbType.VarChar).Value = datosEscuelasProcedenciaAlumnos.NombreEscPro;
            cmd.Parameters.Add("@ClaveEscPro", SqlDbType.VarChar).Value = datosEscuelasProcedenciaAlumnos.ClaveEscPro;
            cmd.Parameters.Add("@IDEscProAlumno", SqlDbType.Int).Value = datosEscuelasProcedenciaAlumnos.IDEscProAlumno;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para llenar los GridView y DDL de las escuelas
        public DataTable llenarDDL()
        {
            SQLCommand = "SELECT * FROM EscuelasProcedenciaAlumnos Order By NombreEscPro";
            return llenarTablas(SQLCommand);
        }
        //Para llenar los GridView y DDL de las escuelas
        public DataTable llenarTablas()
        {
            SQLCommand = "SELECT * FROM EscuelasProcedenciaAlumnos";
            return llenarTablas(SQLCommand);
        }

        //Buscar el dato de una tabla en especifico
        public string buscarDatoEscPro(string Columna, EscuelasProcedenciaAlumnosBO datosEscuelasProcedenciaAlumnos)
        {
            cmd = new SqlCommand("SELECT " + Columna + " FROM EscuelasProcedenciaAlumnos WHERE IDEscProAlumno = @IDEscProAlumno;");

            cmd.Parameters.Add("@IDEscProAlumno", SqlDbType.VarChar).Value = datosEscuelasProcedenciaAlumnos.IDEscProAlumno;

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, Columna);
        }

    }
}