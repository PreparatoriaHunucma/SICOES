using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SICOES2018.BO;

namespace SICOES2018.DAO
{
    public class EscuelasProcedenciaAlumnosDAO: ConexionSQL
    {
        SqlCommand cmd;

        //Agregar una nueva escuela de procedencia
        public int agregarEscuela(EscuelasProcedenciaAlumnosBO datosEscuelasProcedenciaAlumnos)
        {
            cmd = new SqlCommand("INSERT INTO EscuelasProcedenciaAlumnos (NombreEscPro, ClaveEscPro, IDTurno) VALUES (@NombreEscPro, @ClaveEscPro, @IDTurno)");

            cmd.Parameters.Add("@NombreEscPro", SqlDbType.Int).Value = datosEscuelasProcedenciaAlumnos.NombreEscPro;
            cmd.Parameters.Add("@ClaveEscPro", SqlDbType.Int).Value = datosEscuelasProcedenciaAlumnos.ClaveEscPro;
            cmd.Parameters.Add("@IDTurno", SqlDbType.Text).Value = datosEscuelasProcedenciaAlumnos.IDTurno;
            cmd.CommandType = CommandType.Text;

            return ejecutarComando(cmd);
        }

        //Para modificar el nombre de la escuela de procedencia
        public int modificarNombreEscuelaProc(EscuelasProcedenciaAlumnosBO datosEscuelasProcedenciaAlumnos)
        {
            cmd = new SqlCommand("UPDATE EscuelasProcedenciaAlumnos SET NombreEscPro = @NombreEscPro WHERE IDEscProAlumno = @IDEscProAlumno");

            cmd.Parameters.Add("@NombreEscPro", SqlDbType.TinyInt).Value = datosEscuelasProcedenciaAlumnos.NombreEscPro;
            cmd.Parameters.Add("@IDEscProAlumno", SqlDbType.Int).Value = datosEscuelasProcedenciaAlumnos.IDEscProAlumno;
            cmd.CommandType = CommandType.Text;

            return ejecutarComando(cmd);
        }

        //Para modificar el nombre de la escuela de procedencia [0 = NO VISTO, 1 = VISTO]
        public int modificarClaveEscuelaProc(EscuelasProcedenciaAlumnosBO datosEscuelasProcedenciaAlumnos)
        {
            cmd = new SqlCommand("UPDATE EscuelasProcedenciaAlumnos SET ClaveEscPro = @ClaveEscPro WHERE IDEscProAlumno = @IDEscProAlumno");

            cmd.Parameters.Add("@ClaveEscPro", SqlDbType.TinyInt).Value = datosEscuelasProcedenciaAlumnos.ClaveEscPro;
            cmd.Parameters.Add("@IDEscProAlumno", SqlDbType.Int).Value = datosEscuelasProcedenciaAlumnos.IDEscProAlumno;
            cmd.CommandType = CommandType.Text;

            return ejecutarComando(cmd);
        }

    }
}