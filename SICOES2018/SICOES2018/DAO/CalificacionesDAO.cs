using SICOES2018.BO;
using System.Data;
using System.Data.SqlClient;

namespace SICOES2018.DAO
{
    public class CalificacionesDAO :ConexionSQL
    {
        SqlCommand cmd;

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