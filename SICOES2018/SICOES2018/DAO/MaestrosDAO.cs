using SICOES2018.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SICOES2018.DAO
{
    public class MaestrosDAO : ConexionSQL
    {
        SqlCommand cmd;
        string SQLCommand;

        //Para verificar si el maestro tiene una cuenta dentro del sistema
        public string loginMaestro(MaestrosBO datosMaestro)
        {
            cmd = new SqlCommand("SELECT COUNT(*) AS Login FROM Maestros WHERE UsuarioMaestro = @UsuarioMaestro AND ContraseñaMaestro = @ContraseñaMaestro");

            cmd.Parameters.Add("@UsuarioMaestro", SqlDbType.VarChar).Value = datosMaestro.UsuarioMaestro;
            cmd.Parameters.Add("@ContraseñaMaestro", SqlDbType.VarChar).Value = datosMaestro.ContrasenhaMaestro;

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, "Login");
        }
        public string ObtenerIDLogin(MaestrosBO datosMaestro)
        {
            cmd = new SqlCommand("SELECT IDMaestro FROM Maestros WHERE UsuarioMaestro = @UsuarioMaestro AND ContraseñaMaestro = @ContraseñaMaestro");

            cmd.Parameters.Add("@UsuarioMaestro", SqlDbType.VarChar).Value = datosMaestro.UsuarioMaestro;
            cmd.Parameters.Add("@ContraseñaMaestro", SqlDbType.VarChar).Value = datosMaestro.ContrasenhaMaestro;

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, "IDMaestro");
        }

        //Para agregar a un docente al sistema
        public int agregarMaestro(MaestrosBO datosMaestro)
        {
            cmd = new SqlCommand("INSERT INTO Maestros (NomMaestro, ApePatMaestro, ApeMatMaestro, TelMaestro, CorreoMaestro, CedulaMaestro, IngresoMaestro, FotoMaestro, CurriculumMaestro, IDTipoMaestro, GradoAcademicoMaestro, DireccionMaestro, IDMunicipioMaestro, StatusMaestro, Sexo, UltimoGrado) VALUES (@NomMaestro, @ApePatMaestro, @ApeMatMaestro, @TelMaestro, @CorreoMaestro, @CedulaMaestro, GETDATE(), @FotoMaestro, @CurriculumMaestro, @IDTipoMaestro, @GradoAcademicoMaestro, @DireccionMaestro, @IDMunicipioMaestro, @StatusMaestro, @Sexo, @UltimoGrado)");

            cmd.Parameters.Add("@NomMaestro", SqlDbType.VarChar).Value = datosMaestro.NomMaestro;
            cmd.Parameters.Add("@ApePatMaestro", SqlDbType.VarChar).Value = datosMaestro.ApePatMaestro;
            cmd.Parameters.Add("@ApeMatMaestro", SqlDbType.VarChar).Value = datosMaestro.ApeMatMaestro;
            cmd.Parameters.Add("@TelMaestro", SqlDbType.VarChar).Value = datosMaestro.TelMaestro;
            cmd.Parameters.Add("@CorreoMaestro", SqlDbType.VarChar).Value = datosMaestro.CorreoMaestro;
            cmd.Parameters.Add("@CedulaMaestro", SqlDbType.VarChar).Value = datosMaestro.CedulaMaestro;
            cmd.Parameters.Add("@FotoMaestro", SqlDbType.VarChar).Value = datosMaestro.FotoMaestro;
            cmd.Parameters.Add("@CurriculumMaestro", SqlDbType.VarChar).Value = datosMaestro.CurriculumMaestro;
            cmd.Parameters.Add("@IDTipoMaestro", SqlDbType.Int).Value = datosMaestro.IDTipoMaestro;
            cmd.Parameters.Add("@GradoAcademicoMaestro", SqlDbType.VarChar).Value = datosMaestro.GradoAcademicoMaestro;
            cmd.Parameters.Add("@DireccionMaestro", SqlDbType.VarChar).Value = datosMaestro.DireccionMaestro;
            cmd.Parameters.Add("@IDMunicipioMaestro", SqlDbType.Int).Value = datosMaestro.IDMunicipioMaestro;
            cmd.Parameters.Add("@StatusMaestro", SqlDbType.TinyInt).Value = datosMaestro.StatusMaestro;
            cmd.Parameters.Add("@Sexo", SqlDbType.TinyInt).Value = datosMaestro.Sexo;
            cmd.Parameters.Add("@UltimoGrado", SqlDbType.VarChar).Value = datosMaestro.UltimoGrado;
            cmd.CommandType = CommandType.Text;

            return ejecutarComando(cmd);
        }

        public int agregarDocente(MaestrosBO datosMaestro)
        {
            cmd = new SqlCommand("INSERT INTO Maestros (NomMaestro, ApePatMaestro, ApeMatMaestro, TelMaestro, CorreoMaestro, CedulaMaestro, IngresoMaestro, FotoMaestro, CurriculumMaestro, IDTipoMaestro, GradoAcademicoMaestro, DireccionMaestro, IDMunicipioMaestro, StatusMaestro, Sexo, UltimoGrado) VALUES (@NomMaestro, @ApePatMaestro, @ApeMatMaestro, @TelMaestro, @CorreoMaestro, @CedulaMaestro, GETDATE(), @FotoMaestro, @CurriculumMaestro, @IDTipoMaestro, @GradoAcademicoMaestro, @DireccionMaestro, @IDMunicipioMaestro, @StatusMaestro, @Sexo, @UltimoGrado)");

            cmd.Parameters.Add("@NomMaestro", SqlDbType.VarChar).Value = datosMaestro.NomMaestro;
            cmd.Parameters.Add("@ApePatMaestro", SqlDbType.VarChar).Value = datosMaestro.ApePatMaestro;
            cmd.Parameters.Add("@ApeMatMaestro", SqlDbType.VarChar).Value = datosMaestro.ApeMatMaestro;
            cmd.Parameters.Add("@TelMaestro", SqlDbType.VarChar).Value = datosMaestro.TelMaestro;
            cmd.Parameters.Add("@CorreoMaestro", SqlDbType.VarChar).Value = datosMaestro.CorreoMaestro;
            cmd.Parameters.Add("@CedulaMaestro", SqlDbType.VarChar).Value = datosMaestro.CedulaMaestro;
            cmd.Parameters.Add("@FotoMaestro", SqlDbType.VarChar).Value = datosMaestro.FotoMaestro;
            cmd.Parameters.Add("@CurriculumMaestro", SqlDbType.VarChar).Value = datosMaestro.CurriculumMaestro;
            cmd.Parameters.Add("@IDTipoMaestro", SqlDbType.Int).Value = datosMaestro.IDTipoMaestro;
            cmd.Parameters.Add("@GradoAcademicoMaestro", SqlDbType.VarChar).Value = datosMaestro.GradoAcademicoMaestro;
            cmd.Parameters.Add("@DireccionMaestro", SqlDbType.VarChar).Value = datosMaestro.DireccionMaestro;
            cmd.Parameters.Add("@IDMunicipioMaestro", SqlDbType.Int).Value = datosMaestro.IDMunicipioMaestro;
            cmd.Parameters.Add("@StatusMaestro", SqlDbType.TinyInt).Value = datosMaestro.StatusMaestro;
            cmd.Parameters.Add("@Sexo", SqlDbType.TinyInt).Value = datosMaestro.Sexo;
            cmd.Parameters.Add("@UltimoGrado", SqlDbType.VarChar).Value = datosMaestro.UltimoGrado;
            cmd.CommandType = CommandType.Text;

            return ejecutarComando(cmd);
        }

        //Para cambiar el estado del maestro [0 = DE BAJA, 1 = ACTIVO]
        public int modificarEstadoMaestro(MaestrosBO datosMaestro)
        {
            cmd = new SqlCommand("UPDATE Maestros SET StatusMaestro = @StatusMaestro WHERE IDMaestro = @IDMaestro");

            cmd.Parameters.Add("@StatusMaestro", SqlDbType.TinyInt).Value = datosMaestro.StatusMaestro;
            cmd.Parameters.Add("@IDMaestro", SqlDbType.Int).Value = datosMaestro.IDMaestro;
            cmd.CommandType = CommandType.Text;

            return ejecutarComando(cmd);
        }

        //Para cambiar el estado del maestro [0 = DE BAJA, 1 = ACTIVO]
        public int modificarCredencialesMaestro(MaestrosBO datosMaestro)
        {
            cmd = new SqlCommand("UPDATE Maestros SET UsuarioMaestro = @UsuarioMaestro, ContraseñaMaestro = @ContraseñaMaestro WHERE IDMaestro = @IDMaestro");

            cmd.Parameters.Add("@UsuarioMaestro", SqlDbType.VarChar).Value = datosMaestro.UsuarioMaestro;
            cmd.Parameters.Add("@ContraseñaMaestro", SqlDbType.VarChar).Value = datosMaestro.ContrasenhaMaestro;
            cmd.Parameters.Add("@IDMaestro", SqlDbType.Int).Value = datosMaestro.IDMaestro;
            cmd.CommandType = CommandType.Text;

            return ejecutarComando(cmd);
        }

        //Para modificar la informacion del maestro dentro del sistema
        public int modificarInfoMaestro(MaestrosBO datosMaestro)
        {
            cmd = new SqlCommand("UPDATE Maestros SET NomMaestro = @NomMaestro, ApePatMaestro = @ApePatMaestro, ApeMatMaestro = @ApeMatMaestro, TelMaestro = @TelMaestro, CorreoMaestro = @CorreoMaestro, CedulaMaestro = @CedulaMaestro, FotoMaestro = @FotoMaestro, CurriculumMaestro = @CurriculumMaestro, GradoAcademicoMaestro = @GradoAcademicoMaestro, DireccionMaestro = @DireccionMaestro, IDMunicipioMaestro = @IDMunicipioMaestro, StatusMaestro = @StatusMaestro, Sexo = @Sexo, UltimoGrado = @UltimoGrado WHERE IDMaestro = @IDMaestro");

            cmd.Parameters.Add("@NomMaestro", SqlDbType.VarChar).Value = datosMaestro.NomMaestro;
            cmd.Parameters.Add("@ApePatMaestro", SqlDbType.VarChar).Value = datosMaestro.ApePatMaestro;
            cmd.Parameters.Add("@ApeMatMaestro", SqlDbType.VarChar).Value = datosMaestro.ApeMatMaestro;
            cmd.Parameters.Add("@TelMaestro", SqlDbType.VarChar).Value = datosMaestro.TelMaestro;
            cmd.Parameters.Add("@CorreoMaestro", SqlDbType.VarChar).Value = datosMaestro.CorreoMaestro;
            cmd.Parameters.Add("@CedulaMaestro", SqlDbType.VarChar).Value = datosMaestro.CedulaMaestro;
            cmd.Parameters.Add("@FotoMaestro", SqlDbType.VarChar).Value = datosMaestro.FotoMaestro;
            cmd.Parameters.Add("@CurriculumMaestro", SqlDbType.VarChar).Value = datosMaestro.CurriculumMaestro;
            cmd.Parameters.Add("@GradoAcademicoMaestro", SqlDbType.VarChar).Value = datosMaestro.GradoAcademicoMaestro;
            cmd.Parameters.Add("@StatusMaestro", SqlDbType.TinyInt).Value = datosMaestro.StatusMaestro;
            cmd.Parameters.Add("@DireccionMaestro", SqlDbType.VarChar).Value = datosMaestro.DireccionMaestro;
            cmd.Parameters.Add("@IDMunicipioMaestro", SqlDbType.Int).Value = datosMaestro.IDMunicipioMaestro;
            cmd.Parameters.Add("@IDMaestro", SqlDbType.Int).Value = datosMaestro.IDMaestro;
            cmd.Parameters.Add("@Sexo", SqlDbType.TinyInt).Value = datosMaestro.Sexo;
            cmd.Parameters.Add("@UltimoGrado", SqlDbType.VarChar).Value = datosMaestro.UltimoGrado;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para buscar la cantidad de maestros
        public string buscarCount(string Columna)
        {
            cmd = new SqlCommand("SELECT COUNT(*) AS Cantidad FROM Maestros");

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, Columna);
        }

        public string buscarCicloActivo()
        {
            cmd = new SqlCommand("select IDCicloEscolar from CicloEscolar where status = 1");

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, "IDCicloEscolar");
        }
        public string buscarPeriodoActivo1(string Ciclo)
        {
            cmd = new SqlCommand("select top(1) IDPeriodo from PeriodoEscolar where idcicloescolar = " + Ciclo + " order by idperiodo asc");

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, "IDPeriodo");
        }
        public string buscarPeriodoActivo2(string Ciclo)
        {
            cmd = new SqlCommand("select top(1) IDPeriodo from PeriodoEscolar where idcicloescolar = " + Ciclo + " order by idperiodo desc");

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, "IDPeriodo");
        }
        public string buscarGrupos(string Periodo, string Maestro)
        {
            cmd = new SqlCommand("select count(*) as cantidad  from MaestroGrupos where idmaestro = " + Maestro + " and idperiodo = 3");

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, "cantidad");
        }

        public string CuentaGrupos(string Maestro)
        {
            cmd = new SqlCommand("select count(*) as cantidad  from MaestroGrupos where idmaestro = " + Maestro + "");

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, "cantidad");
        }

        public DataTable LlenarGridView(int StatusMaestro)
        {
            SQLCommand = "SELECT IDMaestro, NomMaestro, ApePatMaestro, ApeMatMaestro, (CASE WHEN StatusMaestro = '1' THEN 'Activo' ELSE 'Inactivo'END) AS StatusMaestro, LOWER(CONCAT(LEFT(NomMaestro,3),'.',ApePatMaestro,IDMaestro)) AS Usuario FROM Maestros WHERE StatusMaestro =" + StatusMaestro + ";";
            return llenarTablas(SQLCommand);
            //CONVERT(varchar, FechaNacAlumno, 103) AS FechaNacAlumno,
        }

        public DataTable LlenarGridViewDocentes(int StatusMaestro)
        {
            SQLCommand = "SELECT IDMaestro, NomMaestro, ApePatMaestro, ApeMatMaestro, (CASE WHEN StatusMaestro = '1' THEN 'Activo' ELSE 'Inactivo'END) AS StatusMaestro, LOWER(CONCAT(LEFT(NomMaestro,3),'.',ApePatMaestro,IDMaestro)) AS Usuario From TipoMaestro INNER JOIN Maestros on TipoMaestro.IDTipoMaestro = Maestros.IDMaestro Where Maestros.StatusMaestro = "+StatusMaestro+" AND Docente = 1";
            return llenarTablas(SQLCommand);
            //CONVERT(varchar, FechaNacAlumno, 103) AS FechaNacAlumno,
        }

        //Buscar el dato de una tabla en especifico
        public string buscarDatoAlumno(string Columna, MaestrosBO datosMaestro)
        {
            cmd = new SqlCommand("SELECT " + Columna + " FROM Maestros WHERE IDMaestro = @IDMaestro;");

            cmd.Parameters.Add("@IDMaestro", SqlDbType.Int).Value = datosMaestro.IDMaestro;

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, Columna);
        }
        public string buscarDatoStatus(string Columna, MaestrosBO datosMaestro)
        {
            cmd = new SqlCommand("SELECT " + Columna + " FROM Maestros WHERE IDMaestro = @IDMaestro;");

            cmd.Parameters.Add("@IDMaestro", SqlDbType.Int).Value = datosMaestro.IDMaestro;

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, Columna);
        }
        //Buscar el dato de una tabla en especifico
        public string buscarUltimoID(string Columna)
        {
            cmd = new SqlCommand("SELECT TOP (1) [" + Columna + "] FROM Maestros order by " + Columna + " desc;");

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, Columna);
        }

    }
}