using SICOES2018.BO;
using System.Data;
using System.Data.SqlClient;

namespace SICOES2018.DAO
{
    public class PaisDAO : ConexionSQL
    {
        SqlCommand cmd;

        //Para crear un pais
        public int agregarPais(PaisBO datosPais)
        {
            cmd = new SqlCommand("INSERT INTO Pais (Nombre) VALUES (@Nombre)");

            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = datosPais.Nombre;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para modificar la informacion del pais
        public int modificarInfoPais(PaisBO datosPais)
        {
            cmd = new SqlCommand("UPDATE Pais SET Nombre = @Nombre WHERE IDPais = @IDPais");

            cmd.Parameters.Add("@Nombre", SqlDbType.Text).Value = datosPais.Nombre;
            cmd.Parameters.Add("@IDPais", SqlDbType.Int).Value = datosPais.IDPais;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

    }
}