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

        //Para verificar si el maestro tiene una cuenta dentro del sistema
        public int loginMaestro(MaestrosBO datoMaestro)
        {
            cmd = new SqlCommand("SELECT * FROM Maestro WHERE UsuarioMaestro = @UsuarioMaestro AND ContraseñaMaestro = @ContraseñaMaestro");

            cmd.Parameters.Add("@UsuarioAlumno", SqlDbType.VarChar).Value = datoMaestro.UsuarioMaestro;
            cmd.Parameters.Add("@ContraseñaAlumno", SqlDbType.VarChar).Value = datoMaestro.ContrasenhaMaestro;
            cmd.CommandType = CommandType.Text;

            return ejecutarComando(cmd);
        }

        //Para agregar a un docente al sistema
        public int agregarMaestro(MaestrosBO datosMaestro)
        {
            cmd = new SqlCommand("INSERT INTO Maestros (NomMaestro, ApePatMaestro, ApeMatMaestro, TelMaestro, CorreoMaestro, CedulaMaestro, IngresoMaestro, FotoMaestro, CurriculumMaestro, IDTipoMaestro, GradoAcademicoMaestro, DireccionMaestro, IDMunicipioMaestro, StatusMaestro, UsuarioMaestro, ContraseñaMaestro) VALUES (@NomMaestro, @ApePatMaestro, @ApeMatMaestro, @TelMaestro, @CorreoMaestro, @CedulaMaestro, GETDATE(), @FotoMaestro, @CurriculumMaestro, @IDTipoMaestro, @GradoAcademicoMaestro, @DireccionMaestro, @IDMunicipioMaestro, @StatusMaestro, @UsuarioMaestro, @ContraseñaMaestro)");

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
            cmd.Parameters.Add("@UsuarioMaestro", SqlDbType.VarChar).Value = datosMaestro.UsuarioMaestro;
            cmd.Parameters.Add("@ContraseñaMaestro", SqlDbType.VarChar).Value = datosMaestro.ContrasenhaMaestro;
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

        //Para modificar la informacion del maestro dentro del sistema
        public int modificarInfoMaestro(MaestrosBO datosMaestro)
        {
            cmd = new SqlCommand("UPDATE Alumno SET NomMaestro = @NomMaestro, ApePatMaestro = @ApePatMaestro, ApeMatMaestro = @ApeMatMaestro, TelMaestro = @TelMaestro, CorreoMaestro = @CorreoMaestro, CedulaMaestro = @CedulaMaestro, FotoMaestro = @FotoMaestro, CurriculumMaestro = @CurriculumMaestro, GradoAcademicoMaestro = @GradoAcademicoMaestro, DireccionMaestro = @DireccionMaestro, IDMunicipioMaestro = @IDMunicipioMaestro WHERE IDMaestro = @IDMaestro");

            cmd.Parameters.Add("@NomMaestro", SqlDbType.VarChar).Value = datosMaestro.NomMaestro;
            cmd.Parameters.Add("@ApePatMaestro", SqlDbType.VarChar).Value = datosMaestro.ApePatMaestro;
            cmd.Parameters.Add("@ApeMatMaestro", SqlDbType.VarChar).Value = datosMaestro.ApeMatMaestro;
            cmd.Parameters.Add("@TelMaestro", SqlDbType.VarChar).Value = datosMaestro.TelMaestro;
            cmd.Parameters.Add("@CorreoMaestro", SqlDbType.VarChar).Value = datosMaestro.CorreoMaestro;
            cmd.Parameters.Add("@CedulaMaestro", SqlDbType.VarChar).Value = datosMaestro.CedulaMaestro;
            cmd.Parameters.Add("@FotoMaestro", SqlDbType.VarChar).Value = datosMaestro.FotoMaestro;
            cmd.Parameters.Add("@CurriculumMaestro", SqlDbType.VarChar).Value = datosMaestro.CurriculumMaestro;
            cmd.Parameters.Add("@GradoAcademicoMaestro", SqlDbType.VarChar).Value = datosMaestro.GradoAcademicoMaestro;
            cmd.Parameters.Add("@DireccionMaestro", SqlDbType.VarChar).Value = datosMaestro.DireccionMaestro;
            cmd.Parameters.Add("@IDMunicipioMaestro", SqlDbType.Int).Value = datosMaestro.IDMunicipioMaestro;
            cmd.Parameters.Add("@IDMaestro", SqlDbType.Int).Value = datosMaestro.IDMaestro;

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

    }
}