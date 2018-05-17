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

        //Para crear un Departamento
        public int agregarDepartamento(DepartamentosEscuelaBO datosDepartamentoEsc)
        {
            cmd = new SqlCommand("INSERT INTO DepartamentosEscuela (NombreDep, IDEncargado, IDEscuela, StatusDep) VALUES (@NombreDep, @IDEncargado, @IDEscuela, @StatusDep)");

            cmd.Parameters.Add("@NombreDep", SqlDbType.VarChar).Value = datosDepartamentoEsc.NombreDep;
            cmd.Parameters.Add("@IDEncargado", SqlDbType.Int).Value = datosDepartamentoEsc.IDEncargado;
            cmd.Parameters.Add("@IDEscuela", SqlDbType.Text).Value = datosDepartamentoEsc.IDEscuela;
            cmd.Parameters.Add("@StatusDep", SqlDbType.TinyInt).Value = datosDepartamentoEsc.StatusDep;

            cmd.CommandType = CommandType.Text;
            return ejecutarComando(cmd);
        }

        //Para modificar la informacion del departamento
        public int modificarInfoDepartamento(DepartamentosEscuelaBO datosDepartamentoEsc)
        {
            cmd = new SqlCommand("UPDATE DepartamentosEscuela SET NombreDep = @NombreDep, IDEncargado = @IDEncargado, IDEscuela = @IDEscuela WHERE IDDepartamentos = @IDDepartamentos");

            cmd.Parameters.Add("@NombreDep", SqlDbType.VarChar).Value = datosDepartamentoEsc.NombreDep;
            cmd.Parameters.Add("@IDEncargado", SqlDbType.Int).Value = datosDepartamentoEsc.IDEncargado;
            cmd.Parameters.Add("@IDEscuela", SqlDbType.Int).Value = datosDepartamentoEsc.IDEscuela;
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
    }
}