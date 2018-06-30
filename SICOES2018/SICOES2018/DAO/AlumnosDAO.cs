using System.Data;
using System.Data.SqlClient;
using SICOES2018.BO;

namespace SICOES2018.DAO
{
    public class AlumnosDAO : ConexionSQL
    {
        SqlCommand cmd;
        string SQLCommand;

        //Para verificar si el alumno tiene una cuenta dentro del sistema
        //Buscar el dato de una tabla en especifico
        public string loginAlumno(AlumnosBO datosAlumno)
        {
            cmd = new SqlCommand("SELECT COUNT(*) AS Login FROM Alumnos WHERE UsuarioAlumno = @UsuarioAlumno AND ContraseñaAlumno = @ContraseñaAlumno");

            cmd.Parameters.Add("@UsuarioAlumno", SqlDbType.VarChar).Value = datosAlumno.UsuarioAlumno;
            cmd.Parameters.Add("@ContraseñaAlumno", SqlDbType.VarChar).Value = datosAlumno.ContrasenhaAlumno;

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, "Login");
        }

        public string ObtenerIDLogin(AlumnosBO datosAlumno)
        {
            cmd = new SqlCommand("SELECT IDAlumno FROM Alumnos WHERE UsuarioAlumno = @UsuarioAlumno AND ContraseñaAlumno = @ContraseñaAlumno");

            cmd.Parameters.Add("@UsuarioAlumno", SqlDbType.VarChar).Value = datosAlumno.UsuarioAlumno;
            cmd.Parameters.Add("@ContraseñaAlumno", SqlDbType.VarChar).Value = datosAlumno.ContrasenhaAlumno;

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, "IDAlumno");
        }

        //Buscar el dato de una tabla en especifico
        public string buscarUltimoIDAlumno(string Columna)
        {
            cmd = new SqlCommand("SELECT TOP (1) [" + Columna + "] FROM Alumnos order by " + Columna + " desc;");

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, Columna);
        }


        //Para agregar a un alumno al sistema (Como pre-inscrito)
        public int agregarAlumno(AlumnosBO datosAlumno)
        {
            cmd = new SqlCommand("INSERT INTO Alumnos (NomAlumno, ApePatAlumno, ApeMatAlumno, TelAlumno, IngresoAlumno, IDTipoAlumno, FotoAlumno, CalleAlumno, NumeroAlumno, ColoniaAlumno, CodigoPostalAlumno, IDMunicipioAlumno, NomPadreAlumno, TelPadreAlumno, NomMadreAlumno, TelMadreAlumno, NomTutorAlumno, TelTutorAlumno, IDDocumentosAlumno, IDEscProAlumno, RevalidaAlumno, NuevoAlumno, FechaNacAlumno, CurpAlumno, IDTurno, Matricula, IDSemestrePreinscripcion, FotoTabla) VALUES (@NomAlumno, @ApePatAlumno, @ApeMatAlumno, @TelAlumno, GETDATE(), @IDTipoAlumno, @FotoAlumno, @CalleAlumno, @NumeroAlumno, @ColoniaAlumno, @CodigoPostalAlumno, @IDMunicipioAlumno, @NomPadreAlumno, @TelPadreAlumno, @NomMadreAlumno, @TelMadreAlumno, @NomTutorAlumno, @TelTutorAlumno, @IDDocumentosAlumno, @IDEscProAlumno, @RevalidaAlumno, @NuevoAlumno, @FechaNacAlumno, @CurpAlumno, @IDTurno, @Matricula, @IDSemestrePreinscripcion, @FotoTabla)");

            cmd.Parameters.Add("@NomAlumno", SqlDbType.VarChar).Value = datosAlumno.NomAlumno;
            cmd.Parameters.Add("@ApePatAlumno", SqlDbType.VarChar).Value = datosAlumno.ApePatAlumno;
            cmd.Parameters.Add("@ApeMatAlumno", SqlDbType.VarChar).Value = datosAlumno.ApeMatAlumno;
            cmd.Parameters.Add("@TelAlumno", SqlDbType.VarChar).Value = datosAlumno.TelAlumno;
            cmd.Parameters.Add("@IDTipoAlumno", SqlDbType.Int).Value = datosAlumno.IDTipoAlumno;
            cmd.Parameters.Add("@FotoAlumno", SqlDbType.VarChar).Value = datosAlumno.FotoAlumno;
            cmd.Parameters.Add("@CalleAlumno", SqlDbType.VarChar).Value = datosAlumno.CalleAlumno;
            cmd.Parameters.Add("@NumeroAlumno", SqlDbType.VarChar).Value = datosAlumno.NumeroAlumno;
            cmd.Parameters.Add("@ColoniaAlumno", SqlDbType.VarChar).Value = datosAlumno.ColoniaAlumno;
            cmd.Parameters.Add("@CodigoPostalAlumno", SqlDbType.VarChar).Value = datosAlumno.CodigoPostalAlumno;
            cmd.Parameters.Add("@IDMunicipioAlumno", SqlDbType.Int).Value = datosAlumno.IDMunicipioAlumno;
            cmd.Parameters.Add("@NomPadreAlumno", SqlDbType.VarChar).Value = datosAlumno.NomPadreAlumno;
            cmd.Parameters.Add("@TelPadreAlumno", SqlDbType.VarChar).Value = datosAlumno.TelPadreAlumno;
            cmd.Parameters.Add("@NomMadreAlumno", SqlDbType.VarChar).Value = datosAlumno.NomMadreAlumno;
            cmd.Parameters.Add("@TelMadreAlumno", SqlDbType.VarChar).Value = datosAlumno.TelMadreAlumno;
            cmd.Parameters.Add("@NomTutorAlumno", SqlDbType.VarChar).Value = datosAlumno.NomTutorAlumno;
            cmd.Parameters.Add("@TelTutorAlumno", SqlDbType.VarChar).Value = datosAlumno.TelTutorAlumno;
            cmd.Parameters.Add("@IDDocumentosAlumno", SqlDbType.Int).Value = datosAlumno.IDDocumentosAlumno;
            cmd.Parameters.Add("@IDEscProAlumno", SqlDbType.Int).Value = datosAlumno.IDEscProAlumno;
            cmd.Parameters.Add("@RevalidaAlumno", SqlDbType.TinyInt).Value = datosAlumno.RevalidaAlumno;
            cmd.Parameters.Add("@NuevoAlumno", SqlDbType.TinyInt).Value = datosAlumno.NuevoAlumno;
            cmd.Parameters.Add("@FechaNacAlumno", SqlDbType.Date).Value = datosAlumno.FechaNacAlum.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@CurpAlumno", SqlDbType.VarChar).Value = datosAlumno.CurpAlumno;
            cmd.Parameters.Add("@IDTurno", SqlDbType.Int).Value = datosAlumno.IDTurno;
            cmd.Parameters.Add("@Matricula", SqlDbType.VarChar).Value = datosAlumno.Matricula;
            cmd.Parameters.Add("@IDSemestrePreinscripcion", SqlDbType.VarChar).Value = datosAlumno.IDSemestrePreinscripcion;
            cmd.Parameters.Add("@FotoTabla", SqlDbType.VarChar).Value = datosAlumno.FotoTabla1;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }
        //Para cambiar el tipo de alumno que es [1 = Pre-Inscrito, 2 = Inscrito, 3 = De Baja]
        public int modificarTipoAlumno(AlumnosBO datosAlumno)
        {
            cmd = new SqlCommand("UPDATE Alumnos SET IDTipoAlumno = @IDTipoAlumno WHERE IDAlumno = @IDAlumno");

            cmd.Parameters.Add("@IDTipoAlumno", SqlDbType.Int).Value = datosAlumno.IDTipoAlumno;
            cmd.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = datosAlumno.IDAlumno;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }




        public int ReinscribirAlumno(AlumnosBO datosAlumno)
        {
            cmd = new SqlCommand("UPDATE Alumnos SET IDGrupo = @IDGrupo, IDSemestrePreinscripcion = @IDSemestrePreinscripcion WHERE IDAlumno = @IDAlumno");

            cmd.Parameters.Add("@IDSemestrePreinscripcion", SqlDbType.Int).Value = datosAlumno.IDSemestrePreinscripcion;
            cmd.Parameters.Add("@IDGrupo", SqlDbType.Int).Value = datosAlumno.IDGrupo;
            cmd.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = datosAlumno.IDAlumno;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }


        //Para cambiar el tipo de alumno a inscrito y asignar a un grupo
        public int inscribirAlumno(AlumnosBO datosAlumno)
        {
            cmd = new SqlCommand("UPDATE Alumnos SET IDTipoAlumno = @IDTipoAlumno, IDGrupo = @IDGrupo, UsuarioAlumno = @UsuarioAlumno, ContraseñaAlumno = @ContraseñaAlumno WHERE IDAlumno = @IDAlumno");

            cmd.Parameters.Add("@IDTipoAlumno", SqlDbType.Int).Value = datosAlumno.IDTipoAlumno;
            cmd.Parameters.Add("@IDGrupo", SqlDbType.Int).Value = datosAlumno.IDGrupo;
            cmd.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = datosAlumno.IDAlumno;
            cmd.Parameters.Add("@UsuarioAlumno", SqlDbType.VarChar).Value = datosAlumno.UsuarioAlumno;
            cmd.Parameters.Add("@ContraseñaAlumno", SqlDbType.VarChar).Value = datosAlumno.ContrasenhaAlumno;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }



        public int BorrarCalificaciones(AlumnosBO datosAlumno)
        {
            cmd = new SqlCommand("DELETE FROM Calificaciones WHERE IDAlumno = @IDAlumno");

            cmd.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = datosAlumno.IDAlumno;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }
        public int BorrarCalificacionesAlumno(AlumnosBO datosAlumno)
        {
            cmd = new SqlCommand("DELETE FROM CalificacionesAlumno WHERE IDAlumno = @IDAlumno");

            cmd.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = datosAlumno.IDAlumno;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }


        //Para modificar la informacion del alumno dentro del sistema
        public int modificarInfoAlumno(AlumnosBO datosAlumno)
        {
            cmd = new SqlCommand("UPDATE Alumnos SET NomAlumno = @NomAlumno, ApePatAlumno = @ApePatAlumno, ApeMatAlumno = @ApeMatAlumno, TelAlumno = @TelAlumno, FotoAlumno = @FotoAlumno, CalleAlumno = @CalleAlumno, NumeroAlumno = @NumeroAlumno, ColoniaAlumno = @ColoniaAlumno, CodigoPostalAlumno = @CodigoPostalAlumno, IDMunicipioAlumno = @IDMunicipioAlumno, NomPadreAlumno = @NomPadreAlumno, TelPadreAlumno = @TelPadreAlumno, NomMadreAlumno = @NomMadreAlumno, TelMadreAlumno = @TelMadreAlumno, NomTutorAlumno = @NomTutorAlumno, TelTutorAlumno = @TelTutorAlumno, IDEscProAlumno = @IDEscProAlumno, RevalidaAlumno = @RevalidaAlumno, NuevoAlumno = @NuevoAlumno, FechaNacAlumno = @FechaNacAlumno, CurpAlumno = @CurpAlumno, IDSemestrePreinscripcion = @IDSemestrePreinscripcion, FotoTabla = @FotoTabla WHERE IDAlumno = @IDAlumno");

            cmd.Parameters.Add("@NomAlumno", SqlDbType.VarChar).Value = datosAlumno.NomAlumno;
            cmd.Parameters.Add("@ApePatAlumno", SqlDbType.VarChar).Value = datosAlumno.ApePatAlumno;
            cmd.Parameters.Add("@ApeMatAlumno", SqlDbType.VarChar).Value = datosAlumno.ApeMatAlumno;
            cmd.Parameters.Add("@TelAlumno", SqlDbType.VarChar).Value = datosAlumno.TelAlumno;
            cmd.Parameters.Add("@FotoAlumno", SqlDbType.VarChar).Value = datosAlumno.FotoAlumno;
            cmd.Parameters.Add("@CalleAlumno", SqlDbType.VarChar).Value = datosAlumno.CalleAlumno;
            cmd.Parameters.Add("@NumeroAlumno", SqlDbType.VarChar).Value = datosAlumno.NumeroAlumno;
            cmd.Parameters.Add("@ColoniaAlumno", SqlDbType.VarChar).Value = datosAlumno.ColoniaAlumno;
            cmd.Parameters.Add("@CodigoPostalAlumno", SqlDbType.VarChar).Value = datosAlumno.CodigoPostalAlumno;
            cmd.Parameters.Add("@IDMunicipioAlumno", SqlDbType.Int).Value = datosAlumno.IDMunicipioAlumno;
            cmd.Parameters.Add("@NomPadreAlumno", SqlDbType.VarChar).Value = datosAlumno.NomPadreAlumno;
            cmd.Parameters.Add("@TelPadreAlumno", SqlDbType.VarChar).Value = datosAlumno.TelPadreAlumno;
            cmd.Parameters.Add("@NomMadreAlumno", SqlDbType.VarChar).Value = datosAlumno.NomMadreAlumno;
            cmd.Parameters.Add("@TelMadreAlumno", SqlDbType.VarChar).Value = datosAlumno.TelMadreAlumno;
            cmd.Parameters.Add("@NomTutorAlumno", SqlDbType.VarChar).Value = datosAlumno.NomTutorAlumno;
            cmd.Parameters.Add("@TelTutorAlumno", SqlDbType.VarChar).Value = datosAlumno.TelTutorAlumno;
            cmd.Parameters.Add("@IDEscProAlumno", SqlDbType.Int).Value = datosAlumno.IDEscProAlumno;
            cmd.Parameters.Add("@RevalidaAlumno", SqlDbType.TinyInt).Value = datosAlumno.RevalidaAlumno;
            cmd.Parameters.Add("@NuevoAlumno", SqlDbType.TinyInt).Value = datosAlumno.NuevoAlumno;
            cmd.Parameters.Add("@FechaNacAlumno", SqlDbType.Date).Value = datosAlumno.FechaNacAlum;
            cmd.Parameters.Add("@CurpAlumno", SqlDbType.VarChar).Value = datosAlumno.CurpAlumno;
            cmd.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = datosAlumno.IDAlumno;
            cmd.Parameters.Add("@IDSemestrePreinscripcion", SqlDbType.Int).Value = datosAlumno.IDSemestrePreinscripcion;
            cmd.Parameters.Add("@FotoTabla", SqlDbType.VarChar).Value = datosAlumno.FotoTabla1;
            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }
        //Para llenar los GridView de los alumnos
        public DataTable LlenarGridView(int IDTipoAlumno)
        {
            SQLCommand = "SELECT IDAlumno, NomAlumno, ApePatAlumno, ApeMatAlumno, CONVERT(varchar, FechaNacAlumno, 103) AS FechaNacAlumno, NomTutorAlumno, TelTutorAlumno FROM Alumnos WHERE IDTipoAlumno = " + IDTipoAlumno + ";";
            return llenarTablas(SQLCommand);
        }

        public DataTable ObtenerIDGrupo(int IDGrupo)
        {
            SQLCommand = "SELECT IDAlumno FROM Alumnos WHERE IDGrupo = " + IDGrupo + ";";
            return llenarTablas(SQLCommand);
        }

        //Buscar el dato de una tabla en especifico
        public string buscarDatoAlumno(string Columna, AlumnosBO datosAlumno)
        {
            cmd = new SqlCommand("SELECT " + Columna + " FROM Alumnos WHERE IDAlumno = @IDAlumno;");

            cmd.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = datosAlumno.IDAlumno;

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, Columna);
        }


        public string BuscarCalificacionesAlumno(AlumnosBO datosAlumno)
        {
            cmd = new SqlCommand("SELECT COUNT(*) AS Cantidad FROM Calificaciones WHERE IDAlumno = @IDAlumno;");

            cmd.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = datosAlumno.IDAlumno;

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, "Cantidad");
        }

        public string ObtenerPeriodoBaja(AlumnosBO datosAlumno)
        {
            cmd = new SqlCommand("select g.IDPeriodo from alumnos a join Grupos g on g.IDGrupo = a.IDGrupo WHERE IDAlumno = @IDAlumno;");

            cmd.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = datosAlumno.IDAlumno;

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, "IDPeriodo");
        }

        //Para buscar la cantidad de alumnos
        public string buscarCount(string Columna)
        {
            cmd = new SqlCommand("SELECT COUNT(*) AS Cantidad FROM Alumnos");

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, Columna);
        }
        //Para llenar los GridView de los alumnos
        public DataTable LlenarGridViewGrupos(int IDGrupo)
        {
            SQLCommand = "SELECT IDAlumno, NomAlumno, ApePatAlumno, ApeMatAlumno, CONVERT(varchar, FechaNacAlumno, 103) AS FechaNacAlumno, NomTutorAlumno, TelTutorAlumno FROM Alumnos WHERE IDGrupo = " + IDGrupo + ";";
            return llenarTablas(SQLCommand);
        }

        public DataSet ReporteFormatoPreinscripcion(int IDAlumno, int IDMaestro)
        {
            SQLCommand = "EXEC ReporteFormatoPreinscripcion " + IDAlumno + "," + IDMaestro + "";
            return ejecutarSentencia(SQLCommand);
        }
    }
}