using SICOES2018.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SICOES2018.DAO
{
    public class CalificacionesAlumnoDAO : ConexionSQL
    {
        SqlCommand cmd;
        string SQLCommand;

        //Para agregar una calificacion
        public int agregarCalificacion(CalificacionesAlumnoBO datosCalif)
        {
            cmd = new SqlCommand("INSERT INTO CalificacionesAlumno (IDAlumno, IDAsignatura, IDMomento, Calificacion, IDGrupo, Inasistencias, FechaCaptura) VALUES (@IDAlumno, @IDAsignatura, @IDMomento, @Calificacion, @IDGrupo, @Inasistencias, GETDATE())");

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
            SQLCommand = "select distinct al.IDAlumno, al.FotoTabla, cal.IDCalificacion, CONCAT(al.ApePatAlumno,' ',al.ApeMatAlumno, ' ', al.NomAlumno) AS Alumno, cal.Calificacion, cal.Inasistencias from Calificaciones cal join Alumnos al on al.IDAlumno = cal.IDAlumno AND al.IDGrupo = cal.IDGrupo Where cal.IDGrupo = " + IDGrupo + " AND cal.IDAsignatura = " + IDAsig + " AND cal.IDMomento = " + IDMomento + " ORDER BY Alumno";
            return llenarTablas(SQLCommand);
        }

        public DataTable LlenarGVCalifAlum(int IDAlumno, int IDGrupo)
        {
            SQLCommand = "EXEC CalifAlum " + IDAlumno + "," + IDGrupo;
            return llenarTablas(SQLCommand);
        }

        public DataTable LlenadDDLCicloAlumno(int IDAlumno)
        {
            SQLCommand = "SELECT Distinct ce.IDCicloEscolar, ce.Nombre FROM CicloEscolar ce JOIN PeriodoEscolar pe ON pe.IDCicloEscolar = ce.IDCicloEscolar JOIN Grupos g ON g.IDPeriodo = pe.IDPeriodo JOIN Calificaciones ca ON ca.IDGrupo = g.IDGrupo WHERE ca.IDAlumno = " + IDAlumno;
            return llenarTablas(SQLCommand);
        }

        public DataTable LlenadDDLGrupoPeriodo(int IDAlumno, int IDCiclo)
        {
            SQLCommand = "SELECT Distinct g.IDGrupo, CONCAT(pe.Nombre, ' - ', g.NombreGrupo) AS Grupo FROM Grupos g JOIN PeriodoEscolar pe ON pe.IDPeriodo = g.IDPeriodo JOIN Calificaciones ca ON ca.IDGrupo = g.IDGrupo WHERE pe.IDCicloEscolar = " + IDCiclo + " AND ca.IDAlumno = " + IDAlumno;
            return llenarTablas(SQLCommand);
        }


        //Para modificar la calificacion de un alumno
        public int modificarCalificacion(CalificacionesAlumnoBO datosCalif)
        {
            cmd = new SqlCommand("UPDATE CalificacionesAlumno SET Calificacion = @Calificacion, Inasistencias = @Inasistencias, FechaCaptura = GETDATE() WHERE IDAlumno = @IDAlumno AND IDAsignatura = @IDAsignatura AND IDMomento = @IDMomento AND IDGrupo = @IDGrupo");

            cmd.Parameters.Add("@Calificacion", SqlDbType.Decimal).Value = datosCalif.Calificacion;
            cmd.Parameters.Add("@Inasistencias", SqlDbType.Int).Value = datosCalif.Inasistencias;
            cmd.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = datosCalif.IDAlumno;
            cmd.Parameters.Add("@IDAsignatura", SqlDbType.Int).Value = datosCalif.IDAsignatura;
            cmd.Parameters.Add("@IDMomento", SqlDbType.Int).Value = datosCalif.IDMomento;
            cmd.Parameters.Add("@IDGrupo", SqlDbType.Int).Value = datosCalif.IDGrupo;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

    }
}