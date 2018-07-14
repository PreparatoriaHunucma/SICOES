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
            cmd = new SqlCommand("INSERT INTO Calificaciones (IDAlumno, IDAsignatura, IDMomento, Calificacion, IDGrupo, Inasistencias, FechaCaptura) VALUES (@IDAlumno, @IDAsignatura, @IDMomento, @Calificacion, @IDGrupo, @Inasistencias, GETDATE())");

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
            SQLCommand = "select distinct cal.IDAsignatura, cal.IDAlumno, al.FotoTabla, cal.IDCalificacion, CONCAT(al.ApePatAlumno,' ',al.ApeMatAlumno, ' ', al.NomAlumno) AS Alumno, cal.Calificacion, cal.Inasistencias from Calificaciones cal join Alumnos al on al.IDAlumno = cal.IDAlumno AND al.IDGrupo = cal.IDGrupo Where cal.IDGrupo = " + IDGrupo + " AND cal.IDAsignatura = " + IDAsig + " AND cal.IDMomento = " + IDMomento + " ORDER BY Alumno";
            return llenarTablas(SQLCommand);
        }
        public DataTable ObtenerCalificacionesTodos(int IDGrupo, int IDAsig)
        {
            SQLCommand = "select distinct cal1.IDAsignatura, cal1.IDAlumno, al.FotoTabla, cal1.IDCalificacion, CONCAT(al.ApePatAlumno, ' ', al.ApeMatAlumno, ' ', al.NomAlumno) AS Alumno,  cal1.Calificacion AS PrimerReporte, cal2.Calificacion AS  SegundoReporte, cal3.Calificacion AS Ordinario, cal4.Calificacion AS CalificacionFinal, cal4.Inasistencias FROM dbo.Alumnos al JOIN dbo.Calificaciones cal1 ON cal1.IDAlumno = al.IDAlumno JOIN dbo.Calificaciones cal2 ON cal2.IDAlumno = al.IDAlumno JOIN dbo.Calificaciones cal3 ON cal3.IDAlumno = al.IDAlumno JOIN dbo.Calificaciones cal4 ON cal4.IDAlumno = al.IDAlumno WHERE al.IDGrupo = " + IDGrupo + " AND cal1.IDMomento = 1 AND cal2.IDMomento = 2 AND cal3.IDMomento = 3 AND cal4.IDMomento = 4 AND cal1.IDAsignatura = " + IDAsig + " AND cal2.IDAsignatura = " + IDAsig + " AND cal3.IDAsignatura = " + IDAsig + " AND cal4.IDAsignatura = " + IDAsig + " ORDER BY Alumno";
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

        public int modificarCalificacionMismoSemestre(CalificacionesBO datosCalif)
        {
            cmd = new SqlCommand("UPDATE Calificaciones SET IDGrupo = @IDGrupo WHERE IDAlumno = @IDAlumno AND IDAsignatura = @IDAsignatura AND IDMomento = @IDMomento");

            cmd.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = datosCalif.IDAlumno;
            cmd.Parameters.Add("@IDAsignatura", SqlDbType.Int).Value = datosCalif.IDAsignatura;
            cmd.Parameters.Add("@IDMomento", SqlDbType.Int).Value = datosCalif.IDMomento;
            cmd.Parameters.Add("@IDGrupo", SqlDbType.Int).Value = datosCalif.IDGrupo;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

    }
}