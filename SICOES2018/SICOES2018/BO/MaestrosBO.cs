using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;

namespace SICOES2018.BO
{
    public class MaestrosBO
    {
        private int iDMaestro, iDTipoMaestro, iDMunicipioMaestro;
        private String nomMaestro, apePatMaestro, apeMatMaestro, telMaestro, correoMaestro, fotoMaestro, curriculumMaestro, gradoAcademicoMaestro, direccionMaestro, usuarioMaestro, contrasenhaMaestro, cedulaMaestro;
        private DateTime ingresoMaestro;
        private short statusMaestro;

        public int IDMaestro { get => iDMaestro; set => iDMaestro = value; }
        public int IDTipoMaestro { get => iDTipoMaestro; set => iDTipoMaestro = value; }
        public string NomMaestro { get => nomMaestro; set => nomMaestro = value; }
        public string ApePatMaestro { get => apePatMaestro; set => apePatMaestro = value; }
        public string ApeMatMaestro { get => apeMatMaestro; set => apeMatMaestro = value; }
        public string TelMaestro { get => telMaestro; set => telMaestro = value; }
        public string CorreoMaestro { get => correoMaestro; set => correoMaestro = value; }
        public string FotoMaestro { get => fotoMaestro; set => fotoMaestro = value; }
        public string CurriculumMaestro { get => curriculumMaestro; set => curriculumMaestro = value; }
        public string GradoAcademicoMaestro { get => gradoAcademicoMaestro; set => gradoAcademicoMaestro = value; }
        public string DireccionMaestro { get => direccionMaestro; set => direccionMaestro = value; }
        public string UsuarioMaestro { get => usuarioMaestro; set => usuarioMaestro = value; }
        public string ContrasenhaMaestro { get => contrasenhaMaestro; set => contrasenhaMaestro = value; }
        public DateTime IngresoMaestro { get => ingresoMaestro; set => ingresoMaestro = value; }
        public short StatusMaestro { get => statusMaestro; set => statusMaestro = value; }
        public string CedulaMaestro { get => cedulaMaestro; set => cedulaMaestro = value; }
        public int IDMunicipioMaestro { get => iDMunicipioMaestro; set => iDMunicipioMaestro = value; }

        public System.Drawing.Image RedimencionarImagen(System.Drawing.Image Imgoriginal, int Altoimg)
        {
            var Radio = (double)Altoimg / Imgoriginal.Height;//diferencia entre la imagenes
            var NuevoAncho = (int)(Imgoriginal.Width * Radio);
            var NuevoAlto = (int)(Imgoriginal.Height * Radio);
            var ImagenRedimencionada = new Bitmap(NuevoAncho, NuevoAlto);
            //creo archivo apartir del bitmap con las nuevas dimensiones
            var g = Graphics.FromImage(ImagenRedimencionada);
            g.DrawImage(Imgoriginal, 0, 0, NuevoAncho, NuevoAlto);
            return ImagenRedimencionada;
        }

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