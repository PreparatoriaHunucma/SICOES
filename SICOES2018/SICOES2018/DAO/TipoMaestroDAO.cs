using SICOES2018.BO;
using System.Data;
using System.Data.SqlClient;

namespace SICOES2018.DAO
{
    public class TipoMaestroDAO : ConexionSQL
    {
        SqlCommand cmd;

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

    }
}