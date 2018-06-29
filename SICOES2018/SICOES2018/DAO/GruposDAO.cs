using SICOES2018.BO;
using System.Data;
using System.Data.SqlClient;

namespace SICOES2018.DAO
{
    public class GruposDAO : ConexionSQL
    {
        SqlCommand cmd;
        string SQLCommand;

        //Para crear un grupo
        public int agregarGrupo(GruposBO datosGrupo)
        {
            cmd = new SqlCommand("INSERT INTO Grupos (NombreGrupo, IDPeriodo, IDPlanEstudio, IDSemestre, Status) VALUES (@NombreGrupo, @IDPeriodo, @IDPlanEstudio, @IDSemestre, @Status)");

            cmd.Parameters.Add("@NombreGrupo", SqlDbType.VarChar).Value = datosGrupo.NombreGrupo;
            cmd.Parameters.Add("@IDPeriodo", SqlDbType.Int).Value = datosGrupo.IDPeriodo;
            cmd.Parameters.Add("@IDPlanEstudio", SqlDbType.Int).Value = datosGrupo.IDPlanEstudio;
            cmd.Parameters.Add("@IDSemestre", SqlDbType.Int).Value = datosGrupo.IDSemestre;
            cmd.Parameters.Add("@Status", SqlDbType.TinyInt).Value = datosGrupo.Status;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        public string buscarDatoAlumno(string Columna, GruposBO datosGrupo)
        {
            cmd = new SqlCommand("SELECT " + Columna + " FROM Grupos WHERE IDGrupo = @IDGrupo;");

            cmd.Parameters.Add("@IDGrupo", SqlDbType.Int).Value = datosGrupo.IDGrupo;

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, Columna);
        }

        //Para modificar el estado del grupo
        public int modificarEstadoGrupo(GruposBO datosGrupo)
        {
            cmd = new SqlCommand("UPDATE Grupos SET Status = @Status WHERE IDGrupo = @IDGrupo");

            cmd.Parameters.Add("@Status", SqlDbType.TinyInt).Value = datosGrupo.Status;
            cmd.Parameters.Add("@IDGrupo", SqlDbType.Int).Value = datosGrupo.IDGrupo;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        public int eliminarGrupo(GruposBO datosGrupo)
        {
            cmd = new SqlCommand("DELETE FROM Grupos WHERE IDGrupo = @IDGrupo");

            cmd.Parameters.Add("@IDGrupo", SqlDbType.Int).Value = datosGrupo.IDGrupo;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }
        //Para modificar la informacion del grupo
        public int modificarInfoAviso(GruposBO datosGrupo)
        {
            cmd = new SqlCommand("UPDATE Grupos SET NombreGrupo = @NombreGrupo, IDPeriodo = @IDPeriodo, IDPlanEstudio = @IDPlanEstudio, IDSemestre = @IDSemestre WHERE IDGrupo = @IDGrupo");

            cmd.Parameters.Add("@NombreGrupo", SqlDbType.VarChar).Value = datosGrupo.NombreGrupo;
            cmd.Parameters.Add("@IDPeriodo", SqlDbType.Int).Value = datosGrupo.IDPeriodo;
            cmd.Parameters.Add("@IDPlanEstudio", SqlDbType.Int).Value = datosGrupo.IDPlanEstudio;
            cmd.Parameters.Add("@IDSemestre", SqlDbType.Int).Value = datosGrupo.IDSemestre;
            cmd.Parameters.Add("@IDGrupo", SqlDbType.Int).Value = datosGrupo.IDGrupo;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para llenar los GridView de los ciclos
        public DataTable LlenarGridView(int IDCiclo, int IDPeriodo)
        {
            SQLCommand = "SELECT g.IDGrupo, g.NombreGrupo, CONCAT(ce.Nombre,' - ', pe.Nombre) AS CicloPeriodo, pl.Nombre AS PlanEstudio FROM dbo.Grupos g JOIN dbo.PeriodoEscolar pe ON pe.IDPeriodo = g.IDPeriodo JOIN dbo.CicloEscolar ce ON ce.IDCicloEscolar = pe.IDCicloEscolar JOIN dbo.PlanesEstudio pl ON pl.IDPlanEstudios = g.IDPlanEstudio WHERE pe.IDCicloEscolar = " + IDCiclo + " AND pe.IDPeriodo = " + IDPeriodo + " ORDER BY g.NombreGrupo";
            return llenarTablas(SQLCommand);
        }

        public DataTable LlenarGVAlumnosXGrupos(int IDGrupo)
        {
            SQLCommand = "SELECT a.IDAlumno, CONCAT(a.ApePatAlumno, ' ', a.ApeMatAlumno, ' ', a.NomAlumno) AS Alumno FROM dbo.Grupos g JOIN dbo.Alumnos a ON a.IDGrupo = g.IDGrupo WHERE g.IDGrupo = " + IDGrupo + " ORDER BY Alumno";
            return llenarTablas(SQLCommand);
        }



        //Para llenar los GridView y DDL de los paises
        public DataTable llenarDDLCicloActual(int IDSemestre)
        {
            SQLCommand = "SELECT g.* FROM dbo.Grupos g JOIN dbo.PeriodoEscolar pe ON pe.IDPeriodo = g.IDPeriodo JOIN dbo.CicloEscolar ce ON ce.IDCicloEscolar = pe.IDCicloEscolar WHERE pe.IDCicloEscolar = (SELECT ce.IDCicloEscolar FROM dbo.CicloEscolar ce WHERE ce.Status = 1) AND g.IDSemestre = " + IDSemestre + " ORDER BY g.NombreGrupo";
            return llenarTablas(SQLCommand);
        }

        public DataTable llenarDDLMaestros(int Periodo, int IDMaestro)
        {
            SQLCommand = "select DISTINCT g.IDGrupo, g.NombreGrupo from MaestroGrupos mg join Grupos g on g.IDGrupo = mg.IDGrupo where mg.IDMaestro = " + IDMaestro + " and g.IDPeriodo = " + Periodo;
            return llenarTablas(SQLCommand);
        }

        public string buscarDatoGrupo(string Columna, GruposBO datosAlumno)
        {
            cmd = new SqlCommand("SELECT " + Columna + " FROM Grupos WHERE IDGrupo = @IDGrupo;");

            cmd.Parameters.Add("@IDGrupo", SqlDbType.Int).Value = datosAlumno.IDGrupo;

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, Columna);
        }

        public DataTable llenarDDL(int Periodo)
        {
            SQLCommand = "select * from Grupos where IDperiodo =" + Periodo;
            return llenarTablas(SQLCommand);
        }


    }
}