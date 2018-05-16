using System;
using System.Security.Cryptography;
using System.Text;

namespace SICOES2018.BO
{
    public class AlumnosBO
    {
        private int iDAlumno, iDTipoAlumno, iDMunicipioAlumno, iDDocumentosAlumno, iDEscProAlumno, iDGrupo;
        private String nomAlumno, apePatAlumno, apeMatAlumno, telAlumno, fotoAlumno, calleAlumno, numeroAlumno, coloniaAlumno, codigoPostalAlumno, nomPadreAlumno, telPadreAlumno, nomMadreAlumno, telMadreAlumno, nomTutorAlumno, telTutorAlumno, curpAlumno, usuarioAlumno, contrasenhaAlumno;
        private DateTime ingresoAlumno, fechaNacAlumno;
        private short revalidaAlumno, nuevoAlumno;


        public int IDAlumno { get => iDAlumno; set => iDAlumno = value; }
        public int IDTipoAlumno { get => iDTipoAlumno; set => iDTipoAlumno = value; }
        public int IDMunicipioAlumno { get => iDMunicipioAlumno; set => iDMunicipioAlumno = value; }
        public int IDDocumentosAlumno { get => iDDocumentosAlumno; set => iDDocumentosAlumno = value; }
        public int IDEscProAlumno { get => iDEscProAlumno; set => iDEscProAlumno = value; }
        public int IDGrupo { get => iDGrupo; set => iDGrupo = value; }
        public string NomAlumno { get => nomAlumno; set => nomAlumno = value; }
        public string ApePatAlumno { get => apePatAlumno; set => apePatAlumno = value; }
        public string ApeMatAlumno { get => apeMatAlumno; set => apeMatAlumno = value; }
        public string TelAlumno { get => telAlumno; set => telAlumno = value; }
        public string FotoAlumno { get => fotoAlumno; set => fotoAlumno = value; }
        public string CalleAlumno { get => calleAlumno; set => calleAlumno = value; }
        public string NumeroAlumno { get => numeroAlumno; set => numeroAlumno = value; }
        public string ColoniaAlumno { get => coloniaAlumno; set => coloniaAlumno = value; }
        public string CodigoPostalAlumno { get => codigoPostalAlumno; set => codigoPostalAlumno = value; }
        public string NomPadreAlumno { get => nomPadreAlumno; set => nomPadreAlumno = value; }
        public string TelPadreAlumno { get => telPadreAlumno; set => telPadreAlumno = value; }
        public string NomMadreAlumno { get => nomMadreAlumno; set => nomMadreAlumno = value; }
        public string TelMadreAlumno { get => telMadreAlumno; set => telMadreAlumno = value; }
        public string NomTutorAlumno { get => nomTutorAlumno; set => nomTutorAlumno = value; }
        public string TelTutorAlumno { get => telTutorAlumno; set => telTutorAlumno = value; }
        public string CurpAlumno { get => curpAlumno; set => curpAlumno = value; }
        public string UsuarioAlumno { get => usuarioAlumno; set => usuarioAlumno = value; }
        public string ContrasenhaAlumno { get => contrasenhaAlumno; set => contrasenhaAlumno = value; }
        public DateTime IngresoAlumno { get => ingresoAlumno; set => ingresoAlumno = value; }
        public DateTime FechaNacAlumno { get => fechaNacAlumno; set => fechaNacAlumno = value; }
        public short RevalidaAlumno { get => revalidaAlumno; set => revalidaAlumno = value; }
        public short NuevoAlumno { get => nuevoAlumno; set => nuevoAlumno = value; }

        public string EncriptarMD5(string texto)
        {
            try
            {
                string key = "accesopermitido";
                byte[] keyArray;
                byte[] Arreglo_a_cifrar = UTF8Encoding.UTF8.GetBytes(texto);
                //Se utilizan las clases de encriptacion MD5
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
                //Arreglo TripleDES
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tdes.CreateEncryptor();
                byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_cifrar, 0, Arreglo_a_cifrar.Length);
                tdes.Clear();
                //Se regresa el resultado en forma de una cadena
                texto = Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
            }
            catch (Exception)
            {

            }
            return texto;
        }
    }
}