using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SICOES2018.BO;
using SICOES2018.DAO;

namespace SICOES2018.GUI
{
    public partial class RegistroAlumnos : System.Web.UI.Page
    {
        AlumnosBO datoAlum = new AlumnosBO();
        AlumnosDAO ejecAlum = new AlumnosDAO();
        DocumentosAlumnoBO datoDocs = new DocumentosAlumnoBO();
        DocumentosAlumnoDAO ejecDocs = new DocumentosAlumnoDAO();
        EscuelasProcedenciaAlumnosBO datoEscPro = new EscuelasProcedenciaAlumnosBO();
        EscuelasProcedenciaAlumnosDAO ejecEscPro = new EscuelasProcedenciaAlumnosDAO();
        EstadoBO datoEstado = new EstadoBO();
        EstadoDAO ejecEstado = new EstadoDAO();
        GruposBO datoGrupo = new GruposBO();
        GruposDAO ejecGrupo = new GruposDAO();
        MunicipioBO datoMuni = new MunicipioBO();
        MunicipioDAO ejecMuni = new MunicipioDAO();
        PaisBO datoPais = new PaisBO();
        PaisDAO ejecPais = new PaisDAO();
        TipoAlumnoBO datoTipAlum = new TipoAlumnoBO();
        TiposAlumnoDAO ejecTipAlum = new TiposAlumnoDAO();
        TurnosEscuelasBO datoTurno = new TurnosEscuelasBO();
        TurnosEscuelasDAO ejecTurno = new TurnosEscuelasDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataBind();
                LLenarDDLPaisAlumno();
                LLenarDDLPaisEstado();
                LlenarDDLPaisMunicipio();
                LlenarDDLEscuelaProcedencia();
                LlenarDDLTurnos();
                LLenarDDLTipoAlumno();
                LlenarGVEscuelaProcedencia();
                LlenarGVAlumnos(Convert.ToInt32(ddlAlumnosReg.SelectedValue));
                ddlPaisAlum.SelectedValue = "1";
                LLenarDDLEstadoAlumno(Convert.ToInt32(ddlPaisAlum.SelectedValue));
                ddlEstadoAlum.SelectedValue = "1";
                LLenarDDLMunicipioAlumno(Convert.ToInt32(ddlEstadoAlum.SelectedValue));
                LlenarDDLGrupos();
                LlenarGVPais();
            }
        }

        //////////OBTENER DATOS DEL ALUMNO DE LOS CAMPOS
        protected void ObtenerDatosGenerales()
        {
            datoAlum.NomAlumno = txtNomAlumno.Text;
            datoAlum.ApePatAlumno = txtApePatAlumno.Text;
            datoAlum.ApeMatAlumno = txtApeMatAlumno.Text;
            datoAlum.FechaNacAlum = DateTime.ParseExact(txtFechaNacAlum.Text, "yyyy-MM-dd", CultureInfo.CurrentUICulture);
            datoAlum.CurpAlumno = txtCurpAlum.Text.ToUpper();
            if (Session["RutaFoto"] != null)
                datoAlum.FotoAlumno = Session["RutaFoto"].ToString();
            else
                datoAlum.FotoAlumno = "~/Resources/images/imgPerfil.jpg";
            if (chckRevalida.Checked == true)
                datoAlum.RevalidaAlumno = 1;
            else
                datoAlum.RevalidaAlumno = 0;
            if (chckNuevoIng.Checked == true)
                datoAlum.NuevoAlumno = 1;
            else
                datoAlum.NuevoAlumno = 0;
        }
        protected void ObtenerDatosGeneralesModif()
        {
            datoAlum.NomAlumno = txtNomAlumno.Text;
            datoAlum.ApePatAlumno = txtApePatAlumno.Text;
            datoAlum.ApeMatAlumno = txtApeMatAlumno.Text;
            datoAlum.FechaNacAlum = DateTime.ParseExact(txtFechaNacAlum.Text, "yyyy-MM-dd", CultureInfo.CurrentUICulture);
            datoAlum.CurpAlumno = txtCurpAlum.Text.ToUpper();
            if (Session["RutaFoto"] != null)
                datoAlum.FotoAlumno = Session["RutaFoto"].ToString();
            else
                datoAlum.FotoAlumno = imgFotoAlum.ImageUrl;

            if (chckRevalida.Checked == true)
                datoAlum.RevalidaAlumno = 1;
            else
                datoAlum.RevalidaAlumno = 0;
            if (chckNuevoIng.Checked == true)
                datoAlum.NuevoAlumno = 1;
            else
                datoAlum.NuevoAlumno = 0;

        }
        protected string ObtenerPerfilAlumno()
        {
            string Cantidad = ejecAlum.buscarCount("Cantidad");
            string NombreArchivo = Path.GetFileName(fotoAlum.PostedFile.FileName);
            string RutaImagenes = "~/Resources/FotoPerfilAlumno/";
            Bitmap ImagenEnBinario = new Bitmap(fotoAlum.PostedFile.InputStream);
            System.Drawing.Image ObjetoImagengde = datoAlum.RedimencionarImagen(ImagenEnBinario, 500);
            ObjetoImagengde.Save(Server.MapPath(RutaImagenes + Cantidad + "_" + NombreArchivo));
            return RutaImagenes + Cantidad + "_" + NombreArchivo;
        }
        protected void ObtenerDatosTutor()
        {
            if (txtNomPadreAlum.Text.Length > 0 && txtNomPadreAlum.Text != "")
                datoAlum.NomPadreAlumno = txtNomPadreAlum.Text;
            else
                datoAlum.NomPadreAlumno = "N/A";
            if (txtTelPadreAlum.Text.Length > 0 && txtTelPadreAlum.Text != "")
                datoAlum.TelPadreAlumno = txtTelPadreAlum.Text;
            else
                datoAlum.TelPadreAlumno = "N/A";
            if (txtNomMadreAlum.Text.Length > 0 && txtNomMadreAlum.Text != "")
                datoAlum.NomMadreAlumno = txtNomMadreAlum.Text;
            else
                datoAlum.NomMadreAlumno = "N/A";
            if (txtTelMadreAlum.Text.Length > 0 && txtTelMadreAlum.Text != "")
                datoAlum.TelMadreAlumno = txtTelMadreAlum.Text;
            else
                datoAlum.TelMadreAlumno = "N/A";
            datoAlum.NomTutorAlumno = txtNomTutorAlum.Text;
            datoAlum.TelTutorAlumno = txtTelTutorAlum.Text;
        }
        protected void ObtenerDomicilio()
        {
            datoAlum.CalleAlumno = txtCallAlum.Text;
            datoAlum.NumeroAlumno = txtNumAlum.Text;
            datoAlum.ColoniaAlumno = txtColAlum.Text;
            datoAlum.CodigoPostalAlumno = txtCPAlum.Text;
            datoAlum.IDMunicipioAlumno = Convert.ToInt32(ddlMunicipioAlum.SelectedValue);
            datoAlum.TelAlumno = txtTelAlum.Text;
        }
        protected void ObtenerEscProAlum()
        {
            datoAlum.IDEscProAlumno = Convert.ToInt32(ddlEscProAlum.SelectedValue);
            datoAlum.IDTurno = Convert.ToInt32(ddlTurnoEscPro.SelectedValue);
        }
        protected void ObtenerDocumentos()
        {
            string IDDocs;
            //Acta de Nacimiento
            if (chckActaNacAlum.Checked == true)
                datoDocs.ActaNacimiento = 1;
            else
                datoDocs.ActaNacimiento = 0;
            //Fotografias
            if (chckFotosAlum.Checked == true)
                datoDocs.Fotografias = 1;
            else
                datoDocs.Fotografias = 0;
            //Curp
            if (chckCurpAlum.Checked == true)
                datoDocs.Curp = 1;
            else
                datoDocs.Curp = 0;
            //Constancia
            if (chckConstanciaAlum.Checked == true)
                datoDocs.Constancia = 1;
            else
                datoDocs.Constancia = 0;
            //Compromabte domiciliario
            if (chckCompDomiAlum.Checked == true)
                datoDocs.CompromanteDomiciliario = 1;
            else
                datoDocs.CompromanteDomiciliario = 0;
            //Boletas de calificaciones 
            if (chckBoleCalifAlum.Checked == true)
                datoDocs.BoletaCalificaciones = 1;
            else
                datoDocs.BoletaCalificaciones = 0;
            //Certificado parcial 
            if (chckCertifParcialAlum.Checked == true)
                datoDocs.CertificadoParcial = 1;
            else
                datoDocs.CertificadoParcial = 0;
            //Oficio de revalidación 
            if (chckOfiRevalAlum.Checked == true)
                datoDocs.OficioRevalidacion = 1;
            else
                datoDocs.OficioRevalidacion = 0;
            //Constancia de comp. 1/2 
            if (chckConstanciaMediaAlum.Checked == true)
                datoDocs.ConstanciaMedia = 1;
            else
                datoDocs.ConstanciaMedia = 0;
            //Certificado de secundaria
            if (chckCertifSecunAlum.Checked == true)
                datoDocs.CertificadoSecundaria = 1;
            else
                datoDocs.CertificadoSecundaria = 0;
            if (txtrOtrosAlum.Text.Length > 0 && txtrOtrosAlum.Text != "")
                datoDocs.Otros = txtrOtrosAlum.Text;
            else
                datoDocs.Otros = "N/A";
            ejecDocs.agregarRegistroDocumentos(datoDocs);
            IDDocs = ejecDocs.buscarUltimoIDDocs("IDDocumentos");
            datoAlum.IDDocumentosAlumno = Convert.ToInt32(IDDocs);
        }
        protected void ObtenerDocumentosModif()
        {
            //Acta de Nacimiento
            if (chckActaNacAlum.Checked == true)
                datoDocs.ActaNacimiento = 1;
            else
                datoDocs.ActaNacimiento = 0;
            //Fotografias
            if (chckFotosAlum.Checked == true)
                datoDocs.Fotografias = 1;
            else
                datoDocs.Fotografias = 0;
            //Curp
            if (chckCurpAlum.Checked == true)
                datoDocs.Curp = 1;
            else
                datoDocs.Curp = 0;
            //Constancia
            if (chckConstanciaAlum.Checked == true)
                datoDocs.Constancia = 1;
            else
                datoDocs.Constancia = 0;
            //Compromabte domiciliario
            if (chckCompDomiAlum.Checked == true)
                datoDocs.CompromanteDomiciliario = 1;
            else
                datoDocs.CompromanteDomiciliario = 0;
            //Boletas de calificaciones 
            if (chckBoleCalifAlum.Checked == true)
                datoDocs.BoletaCalificaciones = 1;
            else
                datoDocs.BoletaCalificaciones = 0;
            //Certificado parcial 
            if (chckCertifParcialAlum.Checked == true)
                datoDocs.CertificadoParcial = 1;
            else
                datoDocs.CertificadoParcial = 0;
            //Oficio de revalidación 
            if (chckOfiRevalAlum.Checked == true)
                datoDocs.OficioRevalidacion = 1;
            else
                datoDocs.OficioRevalidacion = 0;
            //Constancia de comp. 1/2 
            if (chckConstanciaMediaAlum.Checked == true)
                datoDocs.ConstanciaMedia = 1;
            else
                datoDocs.ConstanciaMedia = 0;
            //Certificado de secundaria
            if (chckCertifSecunAlum.Checked == true)
                datoDocs.CertificadoSecundaria = 1;
            else
                datoDocs.CertificadoSecundaria = 0;
            if (txtrOtrosAlum.Text.Length > 0 && txtrOtrosAlum.Text != "")
                datoDocs.Otros = txtrOtrosAlum.Text;
            else
                datoDocs.Otros = "N/A";
            datoAlum.IDAlumno = Convert.ToInt32(Session["AlumModif"]);
            datoDocs.IDDocumentos = Convert.ToInt32(ejecAlum.buscarDatoAlumno("IDDocumentosAlumno", datoAlum));
            ejecDocs.modificarDocumentos(datoDocs);
        }


        //////////ESTABLECER DATOS DEL ALUMNO A LOS CAMPOS
        protected void EstablecerDatosGenerales()
        {
            txtNomAlumno.Text = ejecAlum.buscarDatoAlumno("NomAlumno", datoAlum);
            txtApePatAlumno.Text = ejecAlum.buscarDatoAlumno("ApePatAlumno", datoAlum);
            txtApeMatAlumno.Text = ejecAlum.buscarDatoAlumno("ApeMatAlumno", datoAlum);
            txtFechaNacAlum.Text = Convert.ToDateTime(ejecAlum.buscarDatoAlumno("FechaNacAlumno", datoAlum)).ToString("yyyy-MM-dd");
            txtCurpAlum.Text = ejecAlum.buscarDatoAlumno("CurpAlumno", datoAlum);
            imgFotoAlum.ImageUrl = ejecAlum.buscarDatoAlumno("FotoAlumno", datoAlum);
            if (ejecAlum.buscarDatoAlumno("RevalidaAlumno", datoAlum) == "1")
            {
                chckRevalida.Checked = true;
                chckNuevoIng.Checked = false;
            }
            if (ejecAlum.buscarDatoAlumno("NuevoAlumno", datoAlum) == "1")
            {
                chckNuevoIng.Checked = true;
                chckRevalida.Checked = false;
            }
        }
        protected void EstablecerDatosTutor()
        {
            txtNomPadreAlum.Text = ejecAlum.buscarDatoAlumno("NomPadreAlumno", datoAlum);
            txtTelPadreAlum.Text = ejecAlum.buscarDatoAlumno("TelPadreAlumno", datoAlum);
            txtNomMadreAlum.Text = ejecAlum.buscarDatoAlumno("NomMadreAlumno", datoAlum);
            txtTelMadreAlum.Text = ejecAlum.buscarDatoAlumno("TelMadreAlumno", datoAlum);
            txtNomTutorAlum.Text = ejecAlum.buscarDatoAlumno("NomTutorAlumno", datoAlum);
            txtTelTutorAlum.Text = ejecAlum.buscarDatoAlumno("TelTutorAlumno", datoAlum);
            if (txtNomPadreAlum.Text == txtNomTutorAlum.Text)
                chckTutorPadre.Checked = true;
            if (txtNomMadreAlum.Text == txtNomTutorAlum.Text)
                chckTutorMadre.Checked = true;
        }
        protected void EstablecerDomicilio()
        {
            txtCallAlum.Text = ejecAlum.buscarDatoAlumno("CalleAlumno", datoAlum);
            txtNumAlum.Text = ejecAlum.buscarDatoAlumno("NumeroAlumno", datoAlum);
            txtColAlum.Text = ejecAlum.buscarDatoAlumno("ColoniaAlumno", datoAlum);
            txtCPAlum.Text = ejecAlum.buscarDatoAlumno("CodigoPostalAlumno", datoAlum);
            txtTelAlum.Text = ejecAlum.buscarDatoAlumno("TelAlumno", datoAlum);
            int IDMunicipio = Convert.ToInt32(ejecAlum.buscarDatoAlumno("IDMunicipioAlumno", datoAlum));
            datoMuni.IDMunicipio = IDMunicipio;
            int IDEstado = Convert.ToInt32(ejecMuni.buscarDatoMunicipio("IDEstado", datoMuni));
            datoEstado.IDEstado = IDEstado;
            int IDPais = Convert.ToInt32(ejecEstado.buscarDatoEstado("IDPais", datoEstado));
            ddlPaisAlum.SelectedValue = IDPais.ToString();
            ddlEstadoAlum.SelectedValue = IDEstado.ToString();
            ddlMunicipioAlum.SelectedValue = IDMunicipio.ToString();
        }
        protected void EstablecerEscProAlum()
        {
            ddlEscProAlum.SelectedValue = ejecAlum.buscarDatoAlumno("IDEscProAlumno", datoAlum);
            datoEscPro.IDEscProAlumno = Convert.ToInt32(ddlEscProAlum.SelectedValue);
            txtNomEscProAlum.Text = ejecEscPro.buscarDatoEscPro("NombreEscPro", datoEscPro);
            txtClaveEscProAlum.Text = ejecEscPro.buscarDatoEscPro("ClaveEscPro", datoEscPro);
            ddlTurnoEscPro.SelectedValue = ejecAlum.buscarDatoAlumno("IDTurno", datoAlum);
        }
        protected void EstablecerDocumentos()
        {
            datoDocs.IDDocumentos = Convert.ToInt32(ejecAlum.buscarDatoAlumno("IDDocumentosAlumno", datoAlum));
            if (ejecDocs.buscarDatoDocs("ActaNacimiento", datoDocs) == "1")
                chckActaNacAlum.Checked = true;
            if (ejecDocs.buscarDatoDocs("Fotografias", datoDocs) == "1")
                chckFotosAlum.Checked = true;
            if (ejecDocs.buscarDatoDocs("Curp", datoDocs) == "1")
                chckCurpAlum.Checked = true;
            if (ejecDocs.buscarDatoDocs("Constancia", datoDocs) == "1")
                chckConstanciaAlum.Checked = true;
            if (ejecDocs.buscarDatoDocs("ComprobanteDomiciliario", datoDocs) == "1")
                chckCompDomiAlum.Checked = true;
            if (ejecDocs.buscarDatoDocs("BoletaCalificaciones", datoDocs) == "1")
                chckBoleCalifAlum.Checked = true;
            if (ejecDocs.buscarDatoDocs("CertificadoParcial", datoDocs) == "1")
                chckCertifParcialAlum.Checked = true;
            if (ejecDocs.buscarDatoDocs("OficioRevalidacion", datoDocs) == "1")
                chckOfiRevalAlum.Checked = true;
            if (ejecDocs.buscarDatoDocs("ConstanciaMedia", datoDocs) == "1")
                chckConstanciaMediaAlum.Checked = true;
            if (ejecDocs.buscarDatoDocs("CertificadoSecundaria", datoDocs) == "1")
                chckCertifSecunAlum.Checked = true;
            txtrOtrosAlum.Text = ejecDocs.buscarDatoDocs("Otros", datoDocs);
        }


        //////////Llenar grid views y drop down lists
        protected void LLenarDDLTipoAlumno()
        {
            ddlAlumnosReg.Items.Clear();
            ddlAlumnosReg.DataSource = ejecTipAlum.llenarTablasDDL();
            ddlAlumnosReg.DataTextField = "Nombre";
            ddlAlumnosReg.DataValueField = "IDTipoAlumno";
            ddlAlumnosReg.DataBind();
            if (ddlAlumnosReg.Items.Count != 0)
            {
                int TipoID = Convert.ToInt32(ddlAlumnosReg.SelectedValue);
                LlenarGVAlumnos(TipoID);
            }
        }
        protected void LlenarGVAlumnos(int IDTipoAlumno)
        {
            gvAlumnos.DataSource = ejecAlum.LlenarGridView(IDTipoAlumno);
            gvAlumnos.DataBind();
        }
        protected void LLenarDDLPaisAlumno()
        {
            ddlPaisAlum.Items.Clear();
            ddlPaisAlum.DataSource = ejecPais.llenarTablasDDL();
            ddlPaisAlum.DataTextField = "Nombre";
            ddlPaisAlum.DataValueField = "IDPais";
            ddlPaisAlum.DataBind();
            if (ddlPaisAlum.Items.Count != 0)
            {
                int PaisID = Convert.ToInt32(ddlPaisAlum.SelectedValue);
                LLenarDDLEstadoAlumno(PaisID);
            }
        }
        protected void LLenarDDLPaisEstado()
        {
            ddlPaisAddEstado.Items.Clear();
            ddlPaisAddEstado.DataSource = ejecPais.llenarTablasDDL();
            ddlPaisAddEstado.DataTextField = "Nombre";
            ddlPaisAddEstado.DataValueField = "IDPais";
            ddlPaisAddEstado.DataBind();
            if (ddlPaisAddEstado.Items.Count != 0)
            {
                int PaisID = Convert.ToInt32(ddlPaisAddEstado.SelectedValue);
                LlenarGVEstado(PaisID);
            }

        }
        protected void LlenarDDLPaisMunicipio()
        {
            ddlPaisAddMunicipio.Items.Clear();
            ddlPaisAddMunicipio.DataSource = ejecPais.llenarTablasDDL();
            ddlPaisAddMunicipio.DataTextField = "Nombre";
            ddlPaisAddMunicipio.DataValueField = "IDPais";
            ddlPaisAddMunicipio.DataBind();
            if (ddlPaisAddMunicipio.Items.Count != 0)
            {
                int PaisID = Convert.ToInt32(ddlPaisAddMunicipio.SelectedValue);
                LLenarDDLEstadoMunicipio(PaisID);
            }

        }
        protected void LlenarGVPais()
        {
            gvAddPais.DataSource = ejecPais.llenarTablasDDL();
            gvAddPais.DataBind();
        }
        protected void LLenarDDLEstadoAlumno(int IDPais)
        {
            ddlEstadoAlum.Items.Clear();
            ddlEstadoAlum.DataSource = ejecEstado.LlenarDropDownList(IDPais);
            ddlEstadoAlum.DataTextField = "Nombre";
            ddlEstadoAlum.DataValueField = "IDEstado";
            ddlEstadoAlum.DataBind();
            if (ddlEstadoAlum.Items.Count != 0)
            {
                int IDEstado = Convert.ToInt32(ddlEstadoAlum.SelectedValue);
                LLenarDDLMunicipioAlumno(IDEstado);
            }
        }
        protected void LLenarDDLEstadoMunicipio(int IDPais)
        {
            ddlEstadoAddMunicipio.Items.Clear();
            ddlEstadoAddMunicipio.DataSource = ejecEstado.LlenarDropDownList(IDPais);
            ddlEstadoAddMunicipio.DataTextField = "Nombre";
            ddlEstadoAddMunicipio.DataValueField = "IDEstado";
            ddlEstadoAddMunicipio.DataBind();
            if (ddlEstadoAddMunicipio.Items.Count != 0)
            {
                int EstadoID = Convert.ToInt32(ddlEstadoAddMunicipio.SelectedValue);
                LlenarGVMunicipio(EstadoID);
            }

        }
        protected void LlenarGVEstado(int IDPais)
        {
            gvAddEstado.DataSource = ejecEstado.LlenarDropDownList(IDPais);
            gvAddEstado.DataBind();
        }
        protected void LLenarDDLMunicipioAlumno(int IDEstado)
        {
            ddlMunicipioAlum.Items.Clear();
            ddlMunicipioAlum.DataSource = ejecMuni.LlenarDropDownList(IDEstado);
            ddlMunicipioAlum.DataTextField = "Nombre";
            ddlMunicipioAlum.DataValueField = "IDMunicipio";
            ddlMunicipioAlum.DataBind();
        }
        protected void LlenarGVMunicipio(int IDEstado)
        {
            gvAddMunicipio.DataSource = ejecMuni.LlenarDropDownList(IDEstado);
            gvAddMunicipio.DataBind();
        }
        protected void LlenarDDLEscuelaProcedencia()
        {
            ddlEscProAlum.Items.Clear();
            ddlEscProAlum.DataSource = ejecEscPro.llenarDDL();
            ddlEscProAlum.DataTextField = "NombreEscPro";
            ddlEscProAlum.DataValueField = "IDEscProAlumNO";
            ddlEscProAlum.DataBind();
        }
        protected void LlenarGVEscuelaProcedencia()
        {
            gvEscProReg.DataSource = ejecEscPro.llenarTablas();
            gvEscProReg.DataBind();
        }
        protected void LlenarDDLTurnos()
        {
            ddlTurnoEscPro.Items.Clear();
            ddlTurnoEscPro.DataSource = ejecTurno.llenarDDL();
            ddlTurnoEscPro.DataTextField = "Nombre";
            ddlTurnoEscPro.DataValueField = "IDTurno";
            ddlTurnoEscPro.DataBind();
        }
        protected void LlenarDDLGrupos()
        {
            ddlGrupos.Items.Clear();
            ddlGrupos.DataSource = ejecGrupo.llenarDDLCicloActual();
            ddlGrupos.DataTextField = "NombreGrupo";
            ddlGrupos.DataValueField = "IDGrupo";
            ddlGrupos.DataBind();
            if (ddlGrupos.Items.Count != 0)
            {
                LlenarGVAlumnosGrupos(Convert.ToInt32(ddlGrupos.SelectedValue));
            }
        }
        protected void LlenarGVAlumnosGrupos(int IDGrupo)
        {
            gvAlumnosGrupos.DataSource = ejecAlum.LlenarGridViewGrupos(IDGrupo);
            gvAlumnosGrupos.DataBind();
        }


        protected void LimpiarCampos()
        {
            txtNomAlumno.Text = String.Empty;
            txtApePatAlumno.Text = String.Empty;
            txtApeMatAlumno.Text = String.Empty;
            txtFechaNacAlum.Text = String.Empty;
            txtCurpAlum.Text = String.Empty;
            txtNomPadreAlum.Text = String.Empty;
            txtNomMadreAlum.Text = String.Empty;
            txtNomTutorAlum.Text = String.Empty;
            txtTelPadreAlum.Text = String.Empty;
            txtTelMadreAlum.Text = String.Empty;
            txtTelTutorAlum.Text = String.Empty;
            chckTutorPadre.Checked = false;
            chckTutorMadre.Checked = false;
            txtCallAlum.Text = String.Empty;
            txtNumAlum.Text = String.Empty;
            txtColAlum.Text = String.Empty;
            txtCPAlum.Text = String.Empty;
            txtTelAlum.Text = String.Empty;
            ddlPaisAlum.DataBind();
            txtNomEscProAlum.Text = String.Empty;
            txtClaveEscProAlum.Text = String.Empty;
            ddlTurnoEscPro.SelectedIndex = 1;
            chckActaNacAlum.Checked = false;
            chckFotosAlum.Checked = false;
            chckCurpAlum.Checked = false;
            chckCompDomiAlum.Checked = false;
            chckBoleCalifAlum.Checked = false;
            chckCertifParcialAlum.Checked = false;
            chckOfiRevalAlum.Checked = false;
            chckConstanciaAlum.Checked = false;
            chckCertifSecunAlum.Checked = false;
            chckConstanciaMediaAlum.Checked = false;
            txtrOtrosAlum.Text = String.Empty;
            imgFotoAlum.ImageUrl = "~/Resources/images/imgPerfil.jpg";
            Session.Contents.Remove("RutaFoto");
            chckNuevoIng.Checked = false;
            chckRevalida.Checked = false;
        }
        protected void LimpiarCheckBoxes()
        {
            chckActaNacAlum.Checked = false;
            chckFotosAlum.Checked = false;
            chckCurpAlum.Checked = false;
            chckCompDomiAlum.Checked = false;
            chckBoleCalifAlum.Checked = false;
            chckCertifParcialAlum.Checked = false;
            chckOfiRevalAlum.Checked = false;
            chckConstanciaAlum.Checked = false;
            chckCertifSecunAlum.Checked = false;
            chckConstanciaMediaAlum.Checked = false;
            txtrOtrosAlum.Text = String.Empty;
        }
        protected void ActualizarUPDatos()
        {
            upDatosGen.Update();
            upDatosTut.Update();
            upDatosDir.Update();
            upDatosEscPro.Update();
            upDatosDocs.Update();
            upBotones.Update();
        }
        protected void ActualizarUPModals()
        {
            upModalAlumnos.Update();
            upModalEscPro.Update();
            upModalEstado.Update();
            upModalInsc.Update();
            upModalMunicipio.Update();
            upModalPais.Update();
        }


        //////////////////////////////ACCIONES CON LOS ALUMNOS
        //Al presionar el botón de agregar alumno
        protected void btnAgregarAlumno_Click(object sender, EventArgs e)
        {
            if (txtFechaNacAlum.Text != string.Empty && txtNomAlumno.Text != string.Empty && txtCurpAlum.Text != string.Empty && txtNomTutorAlum.Text != string.Empty && txtTelTutorAlum.Text != string.Empty && txtNomEscProAlum.Text != string.Empty)
            {
                DateTime valFechaNac = Convert.ToDateTime(txtFechaNacAlum.Text);
                DateTime fechaInicio = new DateTime(1900, 1, 1);
                if ((valFechaNac.Date >= fechaInicio.Date) && (valFechaNac.Date <= DateTime.Today))
                {
                    ObtenerDatosGenerales();
                    ObtenerDatosTutor();
                    ObtenerDomicilio();
                    ObtenerEscProAlum();
                    ObtenerDocumentos();
                    datoAlum.IDTipoAlumno = 1;
                    ejecAlum.agregarAlumno(datoAlum);
                    LimpiarCampos();
                    LlenarGVAlumnos(1);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
                }
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert();", true);
            ActualizarUPDatos();
        }
        //Establecer la fecha máxima del validador
        protected void rngFechaNacAlum_Init(object sender, EventArgs e)
        {
            ((RangeValidator)sender).MaximumValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
        }
        //Confirmar la foto seleccionada para guardarla
        protected void btnConfirmFoto_Click(object sender, EventArgs e)
        {
            if (fotoAlum.HasFile)
            {
                Session["RutaFoto"] = ObtenerPerfilAlumno();
            }
            else
            {
                Session["RutaFoto"] = "~/Resources/images/imgPerfil.jpg";
            }
            imgFotoAlum.ImageUrl = Session["RutaFoto"].ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "fotosuccessalert();", true);

        }
        //Modificar información del alumno
        protected void btnModifAlumno_Click(object sender, EventArgs e)
        {
            if (txtFechaNacAlum.Text != string.Empty && txtNomAlumno.Text != string.Empty && txtCurpAlum.Text != string.Empty && txtNomTutorAlum.Text != string.Empty && txtTelTutorAlum.Text != string.Empty && txtNomEscProAlum.Text != string.Empty)
            {
                DateTime valFechaNac = Convert.ToDateTime(txtFechaNacAlum.Text);
                DateTime fechaInicio = new DateTime(1900, 1, 1);
                if ((valFechaNac.Date >= fechaInicio.Date) && (valFechaNac.Date <= DateTime.Today))
                {
                    datoAlum.IDAlumno = Convert.ToInt32(Session["AlumModif"]);
                    ObtenerDatosGeneralesModif();
                    ObtenerDatosTutor();
                    ObtenerDomicilio();
                    ObtenerEscProAlum();
                    ObtenerDocumentosModif();
                    ejecAlum.modificarInfoAlumno(datoAlum);
                    LimpiarCampos();
                    ddlAlumnosReg.SelectedIndex = 0;
                    LlenarGVAlumnos(Convert.ToInt32(ddlAlumnosReg.SelectedValue));
                    btnAgregarAlumno.Visible = true;
                    btnModifAlumno.Visible = false;
                    btnInscribirAlumno.Visible = false;
                    btnDarBajaAlumno.Visible = false;
                    ActualizarUPDatos();
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "modifsuccessalert();", true);
                }
            }
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert();", true);

        }
        //Inscribir al alumno a un grupo
        protected void btnInscribirAlumno_Click(object sender, EventArgs e)
        {
            if (Session["AlumModif"] != null)
            {
                datoAlum.IDAlumno = Convert.ToInt32(Session["AlumModif"]);
                datoAlum.IDTipoAlumno = 2;
                datoAlum.IDGrupo = Convert.ToInt32(ddlGrupos.SelectedValue);
                string nombre = ejecAlum.buscarDatoAlumno("NomAlumno", datoAlum).ToLower();
                string tresletras = nombre.Substring(0, 3);
                string apellido;
                if (ejecAlum.buscarDatoAlumno("ApePatAlumno", datoAlum).ToLower() != string.Empty)
                    apellido = ejecAlum.buscarDatoAlumno("ApePatAlumno", datoAlum).ToLower();
                else
                    apellido = ejecAlum.buscarDatoAlumno("ApeMatAlumno", datoAlum).ToLower();
                string usuario = tresletras + "." + apellido + Session["AlumModif"].ToString();
                datoAlum.UsuarioAlumno = datoAlum.EncriptarMD5(usuario);
                string contrasenha = "123456";
                datoAlum.ContrasenhaAlumno = datoAlum.EncriptarMD5(contrasenha);
                ejecAlum.inscribirAlumno(datoAlum);
                LimpiarCampos();
                LlenarGVAlumnos(1);
                btnAgregarAlumno.Visible = true;
                btnModifAlumno.Visible = false;
                btnInscribirAlumno.Visible = false;
                btnDarBajaAlumno.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "inscripcionsuccessalert();", true);
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert();", true);
        }
        //Dar de baja a un alumno
        protected void btnDarBajaAlumno_Click(object sender, EventArgs e)
        {
            if (Session["AlumModif"] != null)
            {
                datoAlum.IDAlumno = Convert.ToInt32(Session["AlumModif"]);
                datoAlum.IDTipoAlumno = 3;
                ejecAlum.modificarTipoAlumno(datoAlum);
                LimpiarCampos();
                LlenarGVAlumnos(1);
                btnAgregarAlumno.Visible = true;
                btnModifAlumno.Visible = false;
                btnInscribirAlumno.Visible = false;
                btnDarBajaAlumno.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "bajasuccessalert();", true);
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert();", true);
        }


        //////////ACCIONES CON EL GRID VIEW DE LOS ALUMNOS
        //Llenar el grid view de los alumnos al seleccionar el tipo de usuario
        protected void ddlAlumnosReg_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarGVAlumnos(Convert.ToInt32(ddlAlumnosReg.SelectedValue));
        }
        //Al presionar el botón de ver alumno en el grid view de los alumnos
        protected void gvAlumnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string currentCommand = e.CommandName;
            if (currentCommand == "SelectAlum")
            {
                int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
                Session["AlumModif"] = Convert.ToInt32(gvAlumnos.DataKeys[currentRowIndex].Value);
                datoAlum.IDAlumno = Convert.ToInt32(Session["AlumModif"]);
                LimpiarCheckBoxes();
                EstablecerDatosGenerales();
                EstablecerDatosTutor();
                EstablecerDomicilio();
                EstablecerEscProAlum();
                EstablecerDocumentos();
                LlenarGVAlumnos(Convert.ToInt32(ddlAlumnosReg.SelectedValue));
                btnAgregarAlumno.Visible = false;
                btnModifAlumno.Visible = true;
                btnInscribirAlumno.Visible = true;
                btnDarBajaAlumno.Visible = true;
                ActualizarUPDatos();
                upDivModalAlumnos.Update();
            }
        }
        //Al cambiar de página en el grid view de los alumnos
        protected void gvAlumnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAlumnos.PageIndex = e.NewPageIndex;
            LlenarGVAlumnos(Convert.ToInt32(ddlAlumnosReg.SelectedValue));
        }
        //Mostrar a los alumnos inscritos en el grupo seleccionado
        protected void ddlGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarGVAlumnosGrupos(Convert.ToInt32(ddlGrupos.SelectedValue));
        }


        //////////////////////////////ACCIONES CON LOS PAISES
        //Para cambiar los drop down lists de estados al seleccionar país [Seccion: Datos Domicilio]
        protected void ddlPaisAlum_SelectedIndexChanged(object sender, EventArgs e)
        {
            LLenarDDLEstadoAlumno(Convert.ToInt32(ddlPaisAlum.SelectedValue));
        }
        //Para cambiar el grid view de estados al seleccionar pais [Seccion: Añadir Estado]
        protected void ddlPaisAddEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarGVEstado(Convert.ToInt32(ddlPaisAddEstado.SelectedValue));
        }
        //Para cambiar los drop down lists de estados al seleccionar pais [Seccion: Añadir Municipio]
        protected void ddlPaisAddMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            LLenarDDLEstadoMunicipio(Convert.ToInt32(ddlPaisAddMunicipio.SelectedValue));
        }
        //Para cambiar de pagina en los grid view
        protected void gvAddPais_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAddPais.PageIndex = e.NewPageIndex;
            LlenarGVPais();
            upModalPais.Update();
        }
        //Para agregar un país
        protected void btnAddNewPais_Click(object sender, EventArgs e)
        {
            if (txtAddPais.Text != string.Empty)
            {
                datoPais.Nombre = txtAddPais.Text;
                ejecPais.agregarPais(datoPais);
                LlenarGVPais();
                LLenarDDLPaisAlumno();
                LLenarDDLPaisEstado();
                LlenarDDLPaisMunicipio();
                txtAddPais.Text = string.Empty;
                ActualizarUPDatos();
                ActualizarUPModals();
            }
            else
            {
                upModalPais.Update();
            }
        }
        //Al presionar editar en el grid
        protected void gvAddPais_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAddPais.EditIndex = e.NewEditIndex;
            LlenarGVPais();
        }
        //Para editar la informacion
        protected void gvAddPais_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label id = gvAddPais.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
            TextBox name = gvAddPais.Rows[e.RowIndex].FindControl("txt_Name") as TextBox;
            datoPais.IDPais = Convert.ToInt32(id.Text);
            datoPais.Nombre = name.Text;
            ejecPais.modificarInfoPais(datoPais);
            gvAddPais.EditIndex = -1;
            LlenarGVPais();
            LLenarDDLPaisAlumno();
            LLenarDDLPaisEstado();
            LlenarDDLPaisMunicipio();
            ActualizarUPDatos();
        }
        //Al presionar cancelar en el grid
        protected void gvAddPais_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAddPais.EditIndex = -1;
            LlenarGVPais();
        }


        //////////////////////////////ACCIONES CON LOS ESTADOS
        //Para cambiar los drop down lists de municipios al seleccionar el estado [Seccion: Direccion]
        protected void ddlEstadoAlum_SelectedIndexChanged(object sender, EventArgs e)
        {
            LLenarDDLMunicipioAlumno(Convert.ToInt32(ddlEstadoAlum.SelectedValue));
        }
        //Para cambiar el grid view de municipios al seleccionar el estado [Seccion: Direccion]
        protected void ddlEstadoAddMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarGVMunicipio(Convert.ToInt32(ddlEstadoAddMunicipio.SelectedValue));
        }
        //Para agregar un estado
        protected void btnAddEstado_Click(object sender, EventArgs e)
        {
            if (txtAddEstado.Text != string.Empty)
            {
                datoEstado.Nombre = txtAddEstado.Text;
                datoEstado.IDPais = Convert.ToInt32(ddlPaisAddEstado.SelectedValue);
                ejecEstado.agregarEstado(datoEstado);
                LLenarDDLEstadoAlumno(Convert.ToInt32(ddlPaisAlum.SelectedValue));
                LLenarDDLEstadoMunicipio(Convert.ToInt32(ddlPaisAddMunicipio.SelectedValue));
                LlenarGVEstado(Convert.ToInt32(ddlPaisAddEstado.SelectedValue));
                txtAddEstado.Text = string.Empty;
                ActualizarUPDatos();
                ActualizarUPModals();
            }
            else
            {
                LlenarGVEstado(Convert.ToInt32(ddlPaisAddEstado.SelectedValue));
                rqNombreEstado.Validate();
                upModalEstado.Update();
            }

        }
        //Para cambiar de pagina en los grid view
        protected void gvAddEstado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAddEstado.PageIndex = e.NewPageIndex;
            LlenarGVEstado(Convert.ToInt32(ddlPaisAddEstado.SelectedValue));
        }


        //EN PRUEBAS
        protected void gvAddEstado_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Finding the controls from Gridview for the row which is going to update  
            Label id = gvAddEstado.Rows[e.RowIndex].FindControl("lbl_IDAddEstado") as Label;
            TextBox name = gvAddEstado.Rows[e.RowIndex].FindControl("txt_NameAddEstado") as TextBox;
            datoEstado.IDEstado = Convert.ToInt32(id.Text);
            datoEstado.Nombre = name.Text;
            ejecEstado.modificarInfoEstado(datoEstado);
            gvAddEstado.EditIndex = -1;
            LlenarGVEstado(Convert.ToInt32(ddlPaisAddEstado.SelectedValue));

        }

        protected void gvAddEstado_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAddEstado.EditIndex = e.NewEditIndex;
            LlenarGVEstado(Convert.ToInt32(ddlPaisAddEstado.SelectedValue));
        }

        protected void gvAddEstado_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAddEstado.EditIndex = -1;
            LlenarGVEstado(Convert.ToInt32(ddlPaisAddEstado.SelectedValue));

        }


        //////////////////////////////ACCIONES CON LOS MUNICIPIOS
        //Para cambiar de pagina en los grid view
        protected void gvAddMunicipio_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAddMunicipio.PageIndex = e.NewPageIndex;
            LlenarGVMunicipio(Convert.ToInt32(ddlEstadoAddMunicipio.SelectedValue));

        }
        //Para agregar un municipio
        protected void btnAddMunicipio_Click(object sender, EventArgs e)
        {
            if (txtAddMunicipio.Text != string.Empty)
            {
                datoMuni.Nombre = txtAddMunicipio.Text;
                datoMuni.IDEstado = Convert.ToInt32(ddlEstadoAddMunicipio.SelectedValue);
                ejecMuni.agregarMunicipio(datoMuni);
                LlenarGVMunicipio(Convert.ToInt32(ddlEstadoAddMunicipio.SelectedValue));
                LLenarDDLMunicipioAlumno(Convert.ToInt32(ddlEstadoAlum.SelectedValue));
                txtAddMunicipio.Text = string.Empty;
                ActualizarUPDatos();
            }
            else
            {
                LlenarGVMunicipio(Convert.ToInt32(ddlEstadoAddMunicipio.SelectedValue));
                rqNombreMunicipio.Validate();
                upModalMunicipio.Update();
            }

        }
        //Al presionar cancelar en el grid
        protected void gvAddMunicipio_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAddMunicipio.EditIndex = -1;
            LlenarGVMunicipio(Convert.ToInt32(ddlEstadoAddMunicipio.SelectedValue));
        }
        //Al presionar editar en el grid
        protected void gvAddMunicipio_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAddMunicipio.EditIndex = e.NewEditIndex;
            LlenarGVMunicipio(Convert.ToInt32(ddlEstadoAddMunicipio.SelectedValue));
        }
        //Para editar la informacion
        protected void gvAddMunicipio_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label id = gvAddMunicipio.Rows[e.RowIndex].FindControl("lbl_IDAddMuni") as Label;
            TextBox name = gvAddMunicipio.Rows[e.RowIndex].FindControl("txt_NameAddMuni") as TextBox;
            datoMuni.IDMunicipio = Convert.ToInt32(id.Text);
            datoMuni.Nombre = name.Text;
            ejecMuni.modificarInfoMuni(datoMuni);
            gvAddMunicipio.EditIndex = -1;
            LlenarGVMunicipio(Convert.ToInt32(ddlEstadoAddMunicipio.SelectedValue));
            LLenarDDLMunicipioAlumno(Convert.ToInt32(ddlEstadoAlum.SelectedValue));
            ActualizarUPDatos();
        }


        //////////////////////////////ACCIONES CON LAS ESCUELAS DE PROCEDENCIA
        //Para llenar los campos de la escuela al momento de seleccionar la escuela
        protected void ddlEscProAlum_TextChanged(object sender, EventArgs e)
        {
            datoEscPro.IDEscProAlumno = Convert.ToInt32(ddlEscProAlum.SelectedValue);
            txtNomEscProAlum.Text = ejecEscPro.buscarDatoEscPro("NombreEscPro", datoEscPro);
            txtClaveEscProAlum.Text = ejecEscPro.buscarDatoEscPro("ClaveEscPro", datoEscPro);
        }
        //Para cambiar de pagina en los grid view
        protected void gvEscProReg_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEscProReg.PageIndex = e.NewPageIndex;
            LlenarGVEscuelaProcedencia();
        }
        //Para agregar una escuela
        protected void btnAddEscPro_Click(object sender, EventArgs e)
        {
            if (txtNomEscProAdd.Text != string.Empty && txtClaveEscProAdd.Text != string.Empty)
            {
                datoEscPro.NombreEscPro = txtNomEscProAdd.Text;
                datoEscPro.ClaveEscPro = txtClaveEscProAdd.Text.ToUpper();
                ejecEscPro.agregarEscuelaPro(datoEscPro);
                LlenarGVEscuelaProcedencia();
                LlenarDDLEscuelaProcedencia();
                txtClaveEscProAdd.Text = string.Empty;
                txtNomEscProAdd.Text = string.Empty;
                ActualizarUPDatos();
            }
            else
            {
                LlenarGVEscuelaProcedencia();
                upModalEscPro.Update();
            }
        }
        //Al presionar editar en el grid
        protected void gvEscProReg_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEscProReg.EditIndex = e.NewEditIndex;
            LlenarGVEscuelaProcedencia();
        }
        //Para editar la informacion
        protected void gvEscProReg_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label id = gvEscProReg.Rows[e.RowIndex].FindControl("lbl_IDAddEscPro") as Label;
            TextBox name = gvEscProReg.Rows[e.RowIndex].FindControl("txt_NameAddEscPro") as TextBox;
            TextBox clave = gvEscProReg.Rows[e.RowIndex].FindControl("txt_ClaveAddEscPro") as TextBox;
            datoEscPro.IDEscProAlumno = Convert.ToInt32(id.Text);
            datoEscPro.NombreEscPro = name.Text;
            datoEscPro.ClaveEscPro = clave.Text;
            ejecEscPro.modificarInfoEscuelaProc(datoEscPro);
            gvEscProReg.EditIndex = -1;
            LlenarGVEscuelaProcedencia();
            LlenarDDLEscuelaProcedencia();
            ActualizarUPDatos();
        }
        //Al presionar cancelar en el grid
        protected void gvEscProReg_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEscProReg.EditIndex = -1;
            LlenarGVEscuelaProcedencia();
        }

        //////////////////////////////LOGICA AL SELECCIONAR TUTOR
        //Cuando el padre es el tutor
        protected void chckTutorPadre_CheckedChanged(object sender, EventArgs e)
        {
            chckTutorMadre.Checked = false;
            txtNomTutorAlum.Text = txtNomPadreAlum.Text;
            txtTelTutorAlum.Text = txtTelPadreAlum.Text;
        }
        //Cuando la madre es el tutor
        protected void chckTutorMadre_CheckedChanged(object sender, EventArgs e)
        {
            chckTutorPadre.Checked = false;
            txtNomTutorAlum.Text = txtNomMadreAlum.Text;
            txtTelTutorAlum.Text = txtTelMadreAlum.Text;
        }


        //////////////////////////////LOGICA AL SELECCIONAR TIPO DE ALUMNO
        //Cuando el alumno es revalidador
        protected void chckRevalida_CheckedChanged(object sender, EventArgs e)
        {
            chckNuevoIng.Checked = false;
        }
        //Cuando el alumno es de nuevo ingreso
        protected void chckNuevoIng_CheckedChanged(object sender, EventArgs e)
        {
            chckRevalida.Checked = false;
        }
    }
}