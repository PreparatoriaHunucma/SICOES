using SICOES2018.BO;
using System.Data;
using System.Data.SqlClient;

namespace SICOES2018.DAO
{
    public class MunicipioDAO : ConexionSQL
    {
        SqlCommand cmd;

        //Para agregar un nuevo municipio
        public int agregarEstado(MunicipioBO datosMunicipio)
        {
            cmd = new SqlCommand("INSERT INTO Municipio (Nombre, IDEstado) VALUES (@Nombre, @IDEstado)");

            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = datosMunicipio.Nombre;
            cmd.Parameters.Add("@IDEstado", SqlDbType.Int).Value = datosMunicipio.IDEstado;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para modificar el nombre del estado
        public int modificarInfoAviso(MunicipioBO datosMunicipio)
        {
            cmd = new SqlCommand("UPDATE Estadp SET Nombre = @Nombre WHERE IDMunicipio = @IDMunicipio");

            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = datosMunicipio.Nombre;
            cmd.Parameters.Add("@IDMunicipio", SqlDbType.Int).Value = datosMunicipio.IDMunicipio;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }
    }
}