using SICOES2018.BO;
using System.Data;
using System.Data.SqlClient;

namespace SICOES2018.DAO
{
    public class TipoMaestroDAO : ConexionSQL
    {
        SqlCommand cmd;
        string SQLCommand;

        //Para crear un registro de tipo de maestro [0 = NO ES, 1 = SI ES]
        public int agregarRegistroTipoMaestro(TipoMaestroBO datoTipoMaestro)
        {
            cmd = new SqlCommand("INSERT INTO TipoMaestro (Directivo, SecreAdmin, SecreAcade, ControlEsc, Docente) VALUES (@Directivo, @SecreAdmin, @SecreAcade, @ControlEsc, @Docente)");

            cmd.Parameters.Add("@Directivo", SqlDbType.TinyInt).Value = datoTipoMaestro.Directivo;
            cmd.Parameters.Add("@SecreAdmin", SqlDbType.TinyInt).Value = datoTipoMaestro.SecreAdmin;
            cmd.Parameters.Add("@SecreAcade", SqlDbType.TinyInt).Value = datoTipoMaestro.SecreAcade;
            cmd.Parameters.Add("@ControlEsc", SqlDbType.TinyInt).Value = datoTipoMaestro.ControlEsc;
            cmd.Parameters.Add("@Docente", SqlDbType.TinyInt).Value = datoTipoMaestro.Docente;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para modificar el estado de los permisos del maestro
        public int modificarTipoMaestro(TipoMaestroBO datoTipoMaestro)
        {
            cmd = new SqlCommand("UPDATE TipoMaestro SET Directivo = @Directivo, SecreAdmin = @SecreAdmin, SecreAcade = @SecreAcade, ControlEsc = @ControlEsc, Docente = @Docente WHERE IDTipoMaestro = @IDTipoMaestro");

            cmd.Parameters.Add("@Directivo", SqlDbType.TinyInt).Value = datoTipoMaestro.Directivo;
            cmd.Parameters.Add("@SecreAdmin", SqlDbType.TinyInt).Value = datoTipoMaestro.SecreAdmin;
            cmd.Parameters.Add("@SecreAcade", SqlDbType.TinyInt).Value = datoTipoMaestro.SecreAcade;
            cmd.Parameters.Add("@ControlEsc", SqlDbType.TinyInt).Value = datoTipoMaestro.ControlEsc;
            cmd.Parameters.Add("@Docente", SqlDbType.TinyInt).Value = datoTipoMaestro.Docente;
            cmd.Parameters.Add("@IDTipoMaestro", SqlDbType.Int).Value = datoTipoMaestro.IDTipoMaestro;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Buscar el dato de una tabla en especifico
        public string buscarUltimoIDTipo(string Columna)
        {
            cmd = new SqlCommand("SELECT TOP (1) [" + Columna + "] FROM TipoMaestro order by " + Columna + " desc;");

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, Columna);
        }

        //Para llenar los GridView y DDL de los paises
        public DataTable llenarTablasDDL()
        {
            SQLCommand = "SELECT * FROM Maestros";
            return llenarTablas(SQLCommand);
        }

        //public DataTable llenarTablasDDL()
        //{
        //    SQLCommand = "SELECT * FROM TipoMaestro";
        //    return llenarTablas(SQLCommand);
        //}

        public string buscarDatoPermiso(string Columna, TipoMaestroBO datosTipoMaestro)
        {
            cmd = new SqlCommand("SELECT " + Columna + " FROM TipoMaestro WHERE IDTipoMaestro = @IDTipoMaestro;");

            cmd.Parameters.Add("@IDTipoMaestro", SqlDbType.Int).Value = datosTipoMaestro.IDTipoMaestro;

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, Columna);
        }

    }
}