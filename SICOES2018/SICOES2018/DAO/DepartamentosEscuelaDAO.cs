using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SICOES2018.BO;

namespace SICOES2018.DAO
{
    public class DepartamentosEscuelaDAO: ConexionSQL
    {
        SqlCommand cmd;
        string SQLCommand;

        //Para buscar datos en la tabla



        //Para crear un Departamento
        public int agregarDepartamento(DepartamentosEscuelaBO datosDepartamentoEsc)
        {

            cmd = new SqlCommand("INSERT INTO DepartamentosEscuela (NombreDep, IDEscuela, StatusDep) VALUES (@NombreDep, @IDEscuela, @StatusDep)");

            cmd.Parameters.Add("@NombreDep", SqlDbType.VarChar).Value = datosDepartamentoEsc.NombreDep;
            cmd.Parameters.Add("@IDEscuela", SqlDbType.VarChar).Value = datosDepartamentoEsc.IDEscuela;
            cmd.Parameters.Add("@StatusDep", SqlDbType.VarChar).Value = datosDepartamentoEsc.StatusDep;


            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);

            //cmd = new SqlCommand("INSERT INTO DepartamentosEscuela (NombreDep, IDEncargado, IDEscuela, StatusDep) VALUES (@NombreDep, @IDEncargado, @IDEscuela, @StatusDep)");

            //cmd.Parameters.Add("@NombreDep", SqlDbType.VarChar).Value = datosDepartamentoEsc.NombreDep;
            //cmd.Parameters.Add("@IDEncargado", SqlDbType.Int).Value = datosDepartamentoEsc.IDEncargado;
            //cmd.Parameters.Add("@IDEscuela", SqlDbType.Text).Value = datosDepartamentoEsc.IDEscuela;
            //cmd.Parameters.Add("@StatusDep", SqlDbType.TinyInt).Value = datosDepartamentoEsc.StatusDep;

            //cmd.CommandType = CommandType.Text;
            //return ejecutarComando(cmd);
        }

        //Para modificar la informacion del departamento
        public int modificarInfoDepartamento(DepartamentosEscuelaBO datosDepartamentoEsc)
        {
            cmd = new SqlCommand("UPDATE DepartamentosEscuela SET IDEncargado = @IDEncargado WHERE IDDepartamentos = @IDDepartamentos");

            
            cmd.Parameters.Add("@IDEncargado", SqlDbType.Int).Value = datosDepartamentoEsc.IDEncargado;
            
            cmd.Parameters.Add("@IDDepartamentos", SqlDbType.Int).Value = datosDepartamentoEsc.IDDepartamentos;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para modificar el estado de vizualizacion del departamento
        public int modificarEstadoDepartamento(DepartamentosEscuelaBO datosDepartamentoEsc)
        {
            cmd = new SqlCommand("UPDATE DepartamentosEscuela SET StatusDep = @StatusDep WHERE IDDepartamentos = @IDDepartamentos");

            cmd.Parameters.Add("@StatusDep", SqlDbType.TinyInt).Value = datosDepartamentoEsc.StatusDep;
            cmd.Parameters.Add("@IDDepartamentos", SqlDbType.Int).Value = datosDepartamentoEsc.IDDepartamentos;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para llenar los GridView y DDL de los paises
        public DataTable llenarTablasDDL()
        {
            SQLCommand = "SELECT * FROM DepartamentosEscuela";
            return llenarTablas(SQLCommand);
        }
        //Para llenar los DDL de los encargados
        public DataTable LlenarDropDownList(int IDDepartamentos)
        {
            SQLCommand = "SELECT CONCAT(NomMaestro,' ', ApePatMaestro,' ', ApeMatMaestro) AS NomMaestro, IDMaestro FROM Maestros JOIN DepartamentosEscuela ON IDMaestro = IDEncargado WHERE IDDepartamentos = " + IDDepartamentos + "";
            return llenarTablas(SQLCommand);
        }

        public DataTable NoAsignado()
        {
            SQLCommand = "SELECT CONCAT(NomMaestro,' ', ApePatMaestro,' ', ApeMatMaestro) AS NomMaestro, IDMaestro FROM Maestros";
            return llenarTablas(SQLCommand);
        }



    }
}