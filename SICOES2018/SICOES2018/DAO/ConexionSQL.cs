using System.Data;
using System.Data.SqlClient;

namespace SICOES2018.DAO
{
    public class ConexionSQL
    {
        SqlCommand ComandoSQL;
        SqlDataAdapter adaptador;
        DataSet DataSetAdaptador;
        SqlConnection con;
        SqlCommand exec;

        public ConexionSQL()
        {
            con = new SqlConnection("Data Source=sql7001.site4now.net;Initial Catalog=DB_A3AC6D_SICOES2018;User Id=DB_A3AC6D_SICOES2018_admin;Password=sicoeshunucma2018;");
            //sirve para establecer las consultas e instrucciones SQL que se ejecutarán en el servidor
            exec = new SqlCommand();
        }
        public SqlConnection establecerConexion()
        {
            string cs = "Data Source=sql7001.site4now.net; Initial Catalog=DB_A3AC6D_SICOES2018; User Id=DB_A3AC6D_SICOES2018_admin; Password=sicoeshunucma2018;";
            con = new SqlConnection(cs);
            return con;
        }
        public void abrirConexion()
        {
            con.Open();
        }
        public void cerrarConexion()
        {
            con.Close();
        }
        public int ejecutarComando(SqlCommand sqlcomando)
        {
            ComandoSQL = new SqlCommand();
            ComandoSQL = sqlcomando;
            ComandoSQL.Connection = this.establecerConexion();
            this.abrirConexion();
            int Verif = ComandoSQL.ExecuteNonQuery();
            this.cerrarConexion();
            if (Verif <= 0)
            {
                return 0;
            }
            return 1;
        }
        public DataSet ejecutarSentencia(SqlCommand sqlcomando)
        {
            ComandoSQL = new SqlCommand();
            adaptador = new SqlDataAdapter();
            DataSetAdaptador = new DataSet();
            ComandoSQL = sqlcomando;
            ComandoSQL.Connection = this.establecerConexion();
            this.abrirConexion();
            adaptador.SelectCommand = ComandoSQL;
            adaptador.Fill(DataSetAdaptador);
            this.cerrarConexion();
            return DataSetAdaptador;
        }
        public DataTable ejecutarBusqueda(SqlCommand sqlcomando)
        {
            DataTable tabla = new DataTable();
            adaptador = new SqlDataAdapter();
            ComandoSQL = new SqlCommand();
            ComandoSQL = sqlcomando;
            ComandoSQL.Connection = this.establecerConexion();
            this.abrirConexion();
            adaptador.Fill(tabla);
            this.cerrarConexion();
            return tabla;
        }
        public string buscarDatoEspecifico(SqlCommand sqlcomando, string Columna)
        {
            ComandoSQL = new SqlCommand();
            ComandoSQL = sqlcomando;
            ComandoSQL.Connection = this.establecerConexion();
            this.abrirConexion();
            SqlDataReader LeerDato = ComandoSQL.ExecuteReader();
            LeerDato.Read();
            string DatoEspecifico = LeerDato[Columna].ToString();
            LeerDato.Close();
            this.cerrarConexion();
            return DatoEspecifico;
        }
        public DataTable llenarTablas(string ComandSQL)
        {
            SqlDataAdapter SQLDA = new SqlDataAdapter(ComandSQL, this.establecerConexion());
            this.abrirConexion();
            DataTable TablaALlenar = new DataTable();
            SQLDA.Fill(TablaALlenar);
            this.cerrarConexion();
            return TablaALlenar;
        }
    }
}