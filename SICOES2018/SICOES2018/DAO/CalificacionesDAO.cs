using SICOES2018.BO;
using System.Data;
using System.Data.SqlClient;

namespace SICOES2018.DAO
{
    public class CalificacionesDAO : ConexionSQL
    {
        SqlCommand cmd;
        string SQLCommand;

        //Para agregar una calificacion
        public int agregarCalificacion(CalificacionesBO datosCalif)
        {
            cmd = new SqlCommand("INSERT INTO Calificaciones (IDAlumno, IDAsignatura, IDMomento, Calificacion, IDGrupo, Inasistencias) VALUES (@IDAlumno, @IDAsignatura, @IDMomento, @Calificacion, @IDGrupo, @Inasistencias)");

            cmd.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = datosCalif.IDAlumno;
            cmd.Parameters.Add("@IDAsignatura", SqlDbType.Int).Value = datosCalif.IDAsignatura;
            cmd.Parameters.Add("@IDMomento", SqlDbType.Int).Value = datosCalif.IDMomento;
            cmd.Parameters.Add("@Calificacion", SqlDbType.Decimal).Value = datosCalif.Calificacion;
            cmd.Parameters.Add("@IDGrupo", SqlDbType.Int).Value = datosCalif.IDGrupo;
            cmd.Parameters.Add("@Inasistencias", SqlDbType.Int).Value = datosCalif.Inasistencias;


            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        public DataTable ObtenerCalificaciones(int IDGrupo, int IDAsig, int IDMomento)
        {
            SQLCommand = "select al.FotoTabla, cal.IDCalificacion, CONCAT(al.ApePatAlumno,' ',al.ApeMatAlumno, ' ', al.NomAlumno) AS Alumno, cal.Calificacion, cal.Inasistencias from Calificaciones cal join Alumnos al on al.IDAlumno = cal.IDAlumno AND al.IDGrupo = cal.IDGrupo Where cal.IDGrupo = " + IDGrupo + " AND cal.IDAsignatura = " + IDAsig + " AND cal.IDMomento = " + IDMomento + " ORDER BY Alumno";
            return llenarTablas(SQLCommand);
        }

        public DataTable LlenarGVConcCalif(int IDGrupo, int IDAsig)
        {
            SQLCommand = "EXEC ConcentradoCalificaciones " + IDGrupo + "," + IDAsig;
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