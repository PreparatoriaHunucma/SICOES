using SICOES2018.BO;
using System.Data;
using System.Data.SqlClient;

namespace SICOES2018.DAO
{
    public class ModalidadAsignaturasDAO : ConexionSQL
    {
        SqlCommand cmd;

        //Para crear un aviso
        public int agregarModalidad(ModalidadAsignaturasBO datosModalidad)
        {
            cmd = new SqlCommand("INSERT INTO ModalidadAsignaturas (Nombre) VALUES (@Nombre)");

            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = datosModalidad.Nombre;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para modificar el texto del aviso (Preferentemente antes de que sea visto por el alumno)
        public int modificarInfoModalidad(ModalidadAsignaturasBO datosModalidad)
        {
            cmd = new SqlCommand("UPDATE ModalidadAsignaturas SET Nombre = @Nombre WHERE IDModalidadAsig = @IDModalidadAsig");

            cmd.Parameters.Add("@Nombre", SqlDbType.Text).Value = datosModalidad.Nombre;
            cmd.Parameters.Add("@IDModalidadAsig", SqlDbType.Int).Value = datosModalidad.IDModalidadAsig;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }
    }
}