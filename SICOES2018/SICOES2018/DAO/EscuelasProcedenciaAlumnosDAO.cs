using System.Data;
using System.Data.SqlClient;
using SICOES2018.BO;

namespace SICOES2018.DAO
{
    public class EscuelasProcedenciaAlumnosDAO : ConexionSQL
    {
        SqlCommand cmd;

        //Agregar una nueva escuela de procedencia
        public int agregarEscuelaPro(EscuelasProcedenciaAlumnosBO datosEscuelasProcedenciaAlumnos)
        {
            cmd = new SqlCommand("INSERT INTO EscuelasProcedenciaAlumnos (NombreEscPro, ClaveEscPro, IDTurno) VALUES (@NombreEscPro, @ClaveEscPro, @IDTurno)");

            cmd.Parameters.Add("@NombreEscPro", SqlDbType.VarChar).Value = datosEscuelasProcedenciaAlumnos.NombreEscPro;
            cmd.Parameters.Add("@ClaveEscPro", SqlDbType.VarChar).Value = datosEscuelasProcedenciaAlumnos.ClaveEscPro;
            cmd.Parameters.Add("@IDTurno", SqlDbType.Int).Value = datosEscuelasProcedenciaAlumnos.IDTurno;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para modificar el nombre de la escuela de procedencia
        public int modificarInfoEscuelaProc(EscuelasProcedenciaAlumnosBO datosEscuelasProcedenciaAlumnos)
        {
            cmd = new SqlCommand("UPDATE EscuelasProcedenciaAlumnos SET NombreEscPro = @NombreEscPro, ClaveEscPro = @ClaveEscPro, IDTurno = @IDTurno WHERE IDEscProAlumno = @IDEscProAlumno");

            cmd.Parameters.Add("@NombreEscPro", SqlDbType.VarChar).Value = datosEscuelasProcedenciaAlumnos.NombreEscPro;
            cmd.Parameters.Add("@ClaveEscPro", SqlDbType.VarChar).Value = datosEscuelasProcedenciaAlumnos.ClaveEscPro;
            cmd.Parameters.Add("@IDTurno", SqlDbType.Int).Value = datosEscuelasProcedenciaAlumnos.IDTurno;
            cmd.Parameters.Add("@IDEscProAlumno", SqlDbType.Int).Value = datosEscuelasProcedenciaAlumnos.IDEscProAlumno;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }
    }
}