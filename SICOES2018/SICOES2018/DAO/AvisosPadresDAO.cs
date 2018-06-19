using SICOES2018.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SICOES2018.DAO
{
    public class AvisosPadresDAO : ConexionSQL
    {
        SqlCommand cmd;

        public int agregarAviso(AvisosPadresBO datosAviso)
        {
            cmd = new SqlCommand("INSERT INTO AvisosPadres (TextoAviso) VALUES (@TextoAviso)");

            cmd.Parameters.Add("@TextoAviso", SqlDbType.VarChar).Value = datosAviso.Texto;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        public string buscarUltimoIDAviso()
        {
            cmd = new SqlCommand("SELECT TOP (1) IDAviso FROM AvisosPadres order by IDAviso desc;");

            cmd.CommandType = CommandType.Text;
            return buscarDatoEspecifico(cmd, "IDAviso");
        }

    }
}