using SICOES2018.BO;
using System.Data;
using System.Data.SqlClient;

namespace SICOES2018.DAO
{
    public class CalificacionesDAO :ConexionSQL
    {
        SqlCommand cmd;
        string SQLCommand;

        //Para agregar una calificacion
        public int agregarCalificacion(CalificacionesBO datosCalif)
        {
            cmd = new SqlCommand("INSERT INTO Calificaciones (IDAlumno, IDAsignatura, IDMomento, Calificacion) VALUES (@IDAlumno, @IDAsignatura, @IDMomento, @Calificacion)");

            cmd.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = datosCalif.IDAlumno;
            cmd.Parameters.Add("@IDAsignatura", SqlDbType.Int).Value = datosCalif.IDAsignatura;
            cmd.Parameters.Add("@IDMomento", SqlDbType.Int).Value = datosCalif.IDMomento;
            cmd.Parameters.Add("@Calificacion", SqlDbType.Decimal).Value = datosCalif.Calificacion;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        public DataTable ObtenerCalificaciones()
        {
            SQLCommand = "select CONCAT(al.ApePatAlumno,' ',al.ApeMatAlumno, ' ', al.NomAlumno) AS Alumno, cal.Calificacion, cal.Inasistencias from Calificaciones cal join Alumnos al on al.IDAlumno = cal.IDAlumno Where cal.IDGrupo = 14 AND cal.IDAsignatura = 2 AND cal.IDMomento = 1";
            return llenarTablas(SQLCommand);
        }



        //Para modificar la calificacion de un alumno
        public int modificarCalificacion(CalificacionesBO datosCalif)
        {
            cmd = new SqlCommand("UPDATE Calificaciones SET Calificacion = @Calificacion WHERE IDCalificacion = @IDCalificacion");

            cmd.Parameters.Add("@Calificacion", SqlDbType.Text).Value = datosCalif.Calificacion;
            cmd.Parameters.Add("@IDCalificacion", SqlDbType.Int).Value = datosCalif.IDCalificacion;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }
    }
}