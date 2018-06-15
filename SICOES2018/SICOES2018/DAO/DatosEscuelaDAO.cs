using SICOES2018.BO;
using System.Data;
using System.Data.SqlClient;

namespace SICOES2018.DAO
{
    public class DatosEscuelaDAO : ConexionSQL
    {
        SqlCommand cmd;

        //Para añadir los datos de la escuela
        public int agregarDatosEscuela(DatosEscuelaBO datosDatosEscuela)
        {
            cmd = new SqlCommand("INSERT INTO DatosEscuela (NombreEsc, ClaveEsc, CalleEsc, NumeroEsc, ColoniaEsc, CodigoPostalEsc, IDMunicipio, TelEscuela, EmailEsc, IDDepartamentos) VALUES (@NombreEsc, @ClaveEsc, @CalleEsc, @NumeroEsc, @ColoniaEsc, @CodigoPostalEsc, @IDMunicipio, @TelEscuela, @EmailEsc, @IDDepartamentos)");

            cmd.Parameters.Add("@NombreEsc", SqlDbType.VarChar).Value = datosDatosEscuela.NombreEsc;
            cmd.Parameters.Add("@ClaveEsc", SqlDbType.VarChar).Value = datosDatosEscuela.ClaveEsc;
            cmd.Parameters.Add("@CalleEsc", SqlDbType.VarChar).Value = datosDatosEscuela.CalleEsc;
            cmd.Parameters.Add("@NumeroEsc", SqlDbType.VarChar).Value = datosDatosEscuela.NumeroEsc;
            cmd.Parameters.Add("@ColoniaEsc", SqlDbType.VarChar).Value = datosDatosEscuela.ColoniaEsc;
            cmd.Parameters.Add("@CodigoPostalEsc", SqlDbType.VarChar).Value = datosDatosEscuela.CodigoPostalEsc;
            cmd.Parameters.Add("@IDMunicipio", SqlDbType.Int).Value = datosDatosEscuela.IDMunicipio;
            cmd.Parameters.Add("@TelEscuela", SqlDbType.VarChar).Value = datosDatosEscuela.TelEsc;
            cmd.Parameters.Add("@EmailEsc", SqlDbType.VarChar).Value = datosDatosEscuela.EmailEsc;
            cmd.Parameters.Add("@IDDepartamentos", SqlDbType.Int).Value = datosDatosEscuela.IDDepartamentos;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para modificar la informacion de la escuela
        public int modificarInfoAviso(DatosEscuelaBO datosDatosEscuela)
        {
            cmd = new SqlCommand("UPDATE DatosEscuela SET NombreEsc = @NombreEsc, ClaveEsc = @ClaveEsc, CalleEsc = @CalleEsc, NumeroEsc = @NumeroEsc, ColoniaEsc = @ColoniaEsc, CodigoPostalEsc = @CodigoPostalEsc, IDMunicipio = @IDMunicipio, TelEscuela = @TelEscuela, EmailEsc = @EmailEsc, IDDepartamentos = @IDDepartamentos WHERE IDEscuela = @IDEscuela");


            cmd.Parameters.Add("@NombreEsc", SqlDbType.VarChar).Value = datosDatosEscuela.NombreEsc;
            cmd.Parameters.Add("@ClaveEsc", SqlDbType.VarChar).Value = datosDatosEscuela.ClaveEsc;
            cmd.Parameters.Add("@CalleEsc", SqlDbType.VarChar).Value = datosDatosEscuela.CalleEsc;
            cmd.Parameters.Add("@NumeroEsc", SqlDbType.VarChar).Value = datosDatosEscuela.NumeroEsc;
            cmd.Parameters.Add("@ColoniaEsc", SqlDbType.VarChar).Value = datosDatosEscuela.ColoniaEsc;
            cmd.Parameters.Add("@CodigoPostalEsc", SqlDbType.VarChar).Value = datosDatosEscuela.CodigoPostalEsc;
            cmd.Parameters.Add("@IDMunicipio", SqlDbType.Int).Value = datosDatosEscuela.IDMunicipio;
            cmd.Parameters.Add("@TelEscuela", SqlDbType.VarChar).Value = datosDatosEscuela.TelEsc;
            cmd.Parameters.Add("@EmailEsc", SqlDbType.VarChar).Value = datosDatosEscuela.EmailEsc;
            cmd.Parameters.Add("@IDDepartamentos", SqlDbType.Int).Value = datosDatosEscuela.IDDepartamentos;
            cmd.Parameters.Add("@IDEscuela", SqlDbType.Int).Value = datosDatosEscuela.IDEscuela;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        public string buscarDatoEscuela(string Columna, DatosEscuelaBO datosEscuela)
        {
            cmd = new SqlCommand("SELECT " + Columna + " FROM DatosEscuela WHERE IDEscuela = @IDEscuela;");

            cmd.Parameters.Add("@IDEscuela", SqlDbType.Int).Value = datosEscuela.IDEscuela;

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, Columna);
        }

        //Para modificar la informacion del alumno dentro del sistema
        public int modificarInfoEscuela(DatosEscuelaBO datosEscuela)
        {
            cmd = new SqlCommand("UPDATE DatosEscuela SET NombreEsc = @NombreEsc, ClaveEsc = @ClaveEsc, CalleEsc = @CalleEsc, NumeroEsc = @NumeroEsc, ColoniaEsc = @ColoniaEsc, CodigoPostalEsc = @CodigoPostalEsc, IDMunicipio = @IDMunicipio, TelEscuela = @TelEscuela, EmailEsc = @EmailEsc WHERE IDEscuela = @IDEscuela");

            cmd.Parameters.Add("@NombreEsc", SqlDbType.VarChar).Value = datosEscuela.NombreEsc;
            cmd.Parameters.Add("@ClaveEsc", SqlDbType.VarChar).Value = datosEscuela.ClaveEsc;
            cmd.Parameters.Add("@CalleEsc", SqlDbType.VarChar).Value = datosEscuela.CalleEsc;
            cmd.Parameters.Add("@NumeroEsc", SqlDbType.VarChar).Value = datosEscuela.NumeroEsc;
            cmd.Parameters.Add("@ColoniaEsc", SqlDbType.VarChar).Value = datosEscuela.ColoniaEsc;
            cmd.Parameters.Add("@CodigoPostalEsc", SqlDbType.VarChar).Value = datosEscuela.CodigoPostalEsc;
            cmd.Parameters.Add("@IDMunicipio", SqlDbType.VarChar).Value = datosEscuela.IDMunicipio;
            cmd.Parameters.Add("@TelEscuela", SqlDbType.VarChar).Value = datosEscuela.TelEsc;
            cmd.Parameters.Add("@EmailEsc", SqlDbType.VarChar).Value = datosEscuela.EmailEsc;
            cmd.Parameters.Add("@IDEscuela", SqlDbType.Int).Value = datosEscuela.IDEscuela;
            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }
    }
}