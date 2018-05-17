using System;

namespace SICOES2018.BO
{
    public class DepartamentosEscuelaBO
    {
        private int iDDepartamentos, iDEncargado, iDEscuela;
        private String nombreDep;
        private short statusDep;

        public int IDDepartamentos { get => iDDepartamentos; set => iDDepartamentos = value; }
        public int IDEncargado { get => iDEncargado; set => iDEncargado = value; }
        public int IDEscuela { get => iDEscuela; set => iDEscuela = value; }
        public string NombreDep { get => nombreDep; set => nombreDep = value; }
        public short StatusDep { get => statusDep; set => statusDep = value; }
    }
}