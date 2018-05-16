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
            cmd = new SqlCommand("INSERT INTO DepartamentosEscuela (NombreDep, IDEncargado, IDEscuela) VALUES (@NombreDep, @IDEncargado, @IDEscuela)");

            cmd.Parameters.Add("@NombreDep", SqlDbType.Int).Value = datosDepartamentoEsc.NombreDep;
            cmd.Parameters.Add("@IDEncargado", SqlDbType.Int).Value = datosDepartamentoEsc.IDEncargado;
            cmd.Parameters.Add("@IDEscuela", SqlDbType.Text).Value = datosDepartamentoEsc.IDEscuela;
            
            cmd.CommandType = CommandType.Text;

            return ejecutarComando(cmd);
        }

        //Para modificar el nombre del departamento
        public int modificarNombreDepartamento(DepartamentosEscuelaBO datosDepartamentoEsc)
        {
            cmd = new SqlCommand("UPDATE DepartamentosEscuela SET NombreDep = @NombreDep WHERE IDDepartamentos = @IDDepartamentos");

            cmd.Parameters.Add("@NombreDep", SqlDbType.TinyInt).Value = datosDepartamentoEsc.NombreDep;
            cmd.Parameters.Add("@IDDepartamentos", SqlDbType.Int).Value = datosDepartamentoEsc.IDDepartamentos;
            cmd.CommandType = CommandType.Text;

            return ejecutarComando(cmd);
        }

        //Para modificar al encargado del departamento
        public int modificarEncargadoDepartamento(DepartamentosEscuelaBO datosDepartamentoEsc)
        {
            cmd = new SqlCommand("UPDATE DepartamentosEscuela SET IDEncargado = @IDEncargado WHERE IDDepartamentos = @IDDepartamentos");

            cmd.Parameters.Add("@IDEncargado", SqlDbType.TinyInt).Value = datosDepartamentoEsc.IDEncargado;
            cmd.Parameters.Add("@IDDepartamentos", SqlDbType.Int).Value = datosDepartamentoEsc.IDDepartamentos;
            cmd.CommandType = CommandType.Text;

            return ejecutarComando(cmd);
        }

    }
}