using SICOES2018.BO;
using System.Data;
using System.Data.SqlClient;

namespace SICOES2018.DAO
{
    public class EstadoDAO : ConexionSQL
    {
        SqlCommand cmd;
        string SQLCommand;

        //Para agregar un nuevo estado
        public int agregarEstado(EstadoBO datosEstado)
        {
            cmd = new SqlCommand("INSERT INTO Estado (Nombre, IDPais) VALUES (@Nombre, @IDPais)");

            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = datosEstado.Nombre;
            cmd.Parameters.Add("@IDPais", SqlDbType.Int).Value = datosEstado.IDPais;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para modificar el nombre del estado
        public int modificarInfoEstado(EstadoBO datosEstado)
        {
            cmd = new SqlCommand("UPDATE Estado SET Nombre = @Nombre WHERE IDEstado = @IDEstado");

            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = datosEstado.Nombre;
            cmd.Parameters.Add("@IDEstado", SqlDbType.Int).Value = datosEstado.IDEstado;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para llenar los DDL de los estados
        public DataTable LlenarDropDownList(int IDPais)
        {
            SQLCommand = "SELECT * FROM Estado WHERE IDPais = '" + IDPais + "' Order By Nombre";
            return llenarTablas(SQLCommand);
        }
        //Buscar el dato de una tabla en especifico
        public string buscarDatoEstado(string Columna, EstadoBO datosEstado)
        {
            cmd = new SqlCommand("SELECT " + Columna + " FROM Estado WHERE IDEstado = @IDEstado;");

            cmd.Parameters.Add("@IDEstado", SqlDbType.Int).Value = datosEstado.IDEstado;

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, Columna);
        }

    }
}