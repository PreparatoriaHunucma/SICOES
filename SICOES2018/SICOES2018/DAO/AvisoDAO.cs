using System.Data;
using System.Data.SqlClient;
using SICOES2018.BO;

namespace SICOES2018.DAO
{
    public class AvisoDAO : ConexionSQL
    {
        SqlCommand cmd;

        //Para crear un aviso
        public int agregarAviso(AvisoBO datosAviso)
        {
            cmd = new SqlCommand("INSERT INTO Aviso (IDMaestro, IDAlumno, TextoAviso, EstadoAviso) VALUES (@IDMaestro, @IDAlumno, @TextoAviso, @EstadoAviso)");

            cmd.Parameters.Add("@IDMaestro", SqlDbType.Int).Value = datosAviso.IDMaestro;
            cmd.Parameters.Add("@IDAlumno", SqlDbType.Int).Value = datosAviso.IDAlumno;
            cmd.Parameters.Add("@TextoAviso", SqlDbType.Text).Value = datosAviso.TextoAviso;
            cmd.Parameters.Add("@EstadoAviso", SqlDbType.TinyInt).Value = datosAviso.EstadoAviso;
            cmd.CommandType = CommandType.Text;

            return ejecutarComando(cmd);
        }

        //Para modificar el estado del aviso segun el alumno [0 = NO VISTO, 1 = VISTO]
        public int modificarEstadoAviso(AvisoBO datosAviso)
        {
            cmd = new SqlCommand("UPDATE Aviso SET EstadoAviso = @EstadoAviso WHERE IDAviso = @IDAviso");

            cmd.Parameters.Add("@EstadoAviso", SqlDbType.TinyInt).Value = datosAviso.EstadoAviso;
            cmd.Parameters.Add("@IDAviso", SqlDbType.Int).Value = datosAviso.IDAviso;
            cmd.CommandType = CommandType.Text;

            return ejecutarComando(cmd);
        }

        //Para modificar el texto del aviso (Preferentemente antes de que sea visto por el alumno)
        public int modificarInfoAviso(AvisoBO datosAviso)
        {
            cmd = new SqlCommand("UPDATE Aviso SET TextoAviso = @TextoAviso WHERE IDAviso = @IDAviso");

            cmd.Parameters.Add("@TextoAviso", SqlDbType.Text).Value = datosAviso.TextoAviso;
            cmd.Parameters.Add("@IDAviso", SqlDbType.Int).Value = datosAviso.IDAviso;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

    }
}