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
    public partial class AltaUsuarios : System.Web.UI.Page
    {
        MaestrosBO datoEmp = new MaestrosBO();
        MaestrosDAO ejecEmp = new MaestrosDAO();
        TipoMaestroBO datoPermiso = new TipoMaestroBO();
        TipoMaestroDAO ejecPermiso = new TipoMaestroDAO();
        EstadoBO datoEstado = new EstadoBO();
        EstadoDAO ejecEstado = new EstadoDAO();
        MunicipioBO datoMuni = new MunicipioBO();
        MunicipioDAO ejecMuni = new MunicipioDAO();
        TipoMaestroBO datoTipEmp = new TipoMaestroBO();
        TipoMaestroDAO ejecTipEmp = new TipoMaestroDAO();
        PaisBO datoPais = new PaisBO();
        PaisDAO ejecPais = new PaisDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataBind();
                LLenarDropDownListsPais();
                LLenarDropDownListsPais2();
                LLenarDropDownListsPais3();
                //LLenarDropDownListsEscuelasProc();
                //llenarDDLTurnos();
               LLenarDropDownListsTipoAlumno();
                //LlenarGridViewEscPro();
                LlenarGridViewAlumnos(Convert.ToInt32(ddlAlumnosReg.SelectedValue));
                ddlPaisEmp.SelectedValue = "1";
                LLenarDropDownListsEstado(Convert.ToInt32(ddlPaisEmp.SelectedValue));
                ddlEstadoEmp.SelectedValue = "1";
                LLenarDropDownListsMunicipio(Convert.ToInt32(ddlEstadoEmp.SelectedValue));
            }
            LlenarGridViewPais();

        }
        protected void limpiarCampos()
        {
            txtNomEmp.Text = String.Empty;
            txtApePatEmp.Text = String.Empty;
            txtApeMatEmp.Text = String.Empty;
            //txtFechaNacEmp.Text = String.Empty;
            txtCedula.Text = String.Empty;
            //txtNomPadreAlum.Text = String.Empty;
            //txtNomMadreAlum.Text = String.Empty;
            //txtNomTutorAlum.Text = String.Empty;
            //txtTelPadreAlum.Text = String.Empty;
            //txtTelMadreAlum.Text = String.Empty;
            //txtTelTutorAlum.Text = String.Empty;
            //chckTutorPadre.Checked = false;
            //chckTutorMadre.Checked = false;
            txtDireccEmp.Text = String.Empty;
            //txtNumEmp.Text = String.Empty;
            //txtColEmp.Text = String.Empty;
            //txtCPEmp.Text = String.Empty;
            txtTelAlum.Text = String.Empty;
            ddlPaisEmp.DataBind();
            //txtNomEscProAlum.Text = String.Empty;
            //txtClaveEscProAlum.Text = String.Empty;
            //ddlTurnoEscPro.SelectedIndex = 1;
            chckDirectivo.Checked = false;
            chckSecretariaAdm.Checked = false;
            chckSecretariaAca.Checked = false;
            chckControl.Checked = false;
            chckDocente.Checked = false;
            imgFotoEmp.ImageUrl = "~/Resources/images/imgPerfil.jpg";
        }

        //////////////////////////////ALUMNO//////////////////////////////
        protected void btnAgregarEmp_Click(object sender, EventArgs e)
        {
            if (txtNomEmp.Text != "" && txtCedula.Text != "")
            {
              // DateTime valFechaNac = Convert.ToDateTime(txtFechaNacAlum.Text);
                DateTime fechaInicio = new DateTime(1900, 1, 1);
                    guardarDatosGenerales();
                    //guardarDatosTutor();
                    guardarDomicilio();
                    //guardarEscProAlum();
                    guardarDocumentos();
                    datoEmp.IDTipoMaestro = 1;
                    //datoEmp.RevalidaAlumno = 1;
                    //datoEmp.NuevoAlumno = 0;
                    ejecEmp.agregarMaestro(datoEmp);
                    limpiarCampos();
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
                    LlenarGridViewAlumnos(1);
                
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert();", true);
        }
        protected void guardarDatosGenerales()
        {
            datoEmp.NomMaestro = txtNomEmp.Text;
            datoEmp.ApePatMaestro = txtApePatEmp.Text;
            datoEmp.ApeMatMaestro = txtApeMatEmp.Text;
            //datoEmp.FechaNacAlum = DateTime.ParseExact(txtFechaNacAlum.Text, "yyyy-MM-dd", CultureInfo.CurrentUICulture);
            datoEmp.CedulaMaestro = txtCedula.Text.ToUpper();
            datoEmp.GradoAcademicoMaestro = txtGradoEmp.Text.ToUpper();
            datoEmp.CurriculumMaestro = Session["RutaCurriculum"].ToString();
            datoEmp.FotoMaestro = Session["RutaFoto"].ToString();
            datoEmp.UsuarioMaestro = txtNomEmp.Text + txtApePatEmp.Text + txtCedula.Text;
            datoEmp.ContrasenhaMaestro = "123456";

        }
        protected string guardarPerfilMaestro()
        {
            string Cantidad = ejecEmp.buscarCount("Cantidad");
            string NombreArchivo = Path.GetFileName(fotoEmp.PostedFile.FileName);
            string RutaImagenes = "~/Resources/FotoPerfilMaestro/";
            Bitmap ImagenEnBinario = new Bitmap(fotoEmp.PostedFile.InputStream);
            System.Drawing.Image ObjetoImagengde = datoEmp.RedimencionarImagen(ImagenEnBinario, 500);
            ObjetoImagengde.Save(Server.MapPath(RutaImagenes + Cantidad + "_" + NombreArchivo));
            return RutaImagenes + Cantidad + "_" + NombreArchivo;
        }

        protected string guardarCurriculum()
        {
            string Cantidad = ejecEmp.buscarCount("Cantidad");
            string NombreArchivo = Path.GetFileName(filecurriculum.PostedFile.FileName);
            string RutaImagenes = "~/Resources/Curriculum/";
            return RutaImagenes + Cantidad + "_" + NombreArchivo;
        }
        //protected void guardarDatosTutor()
        //{
        //    //
        //    if (txtNomPadreAlum.Text.Length > 0 && txtNomPadreAlum.Text != "")
        //        datoAlum.NomPadreAlumno = txtNomPadreAlum.Text;
        //    else
        //        datoAlum.NomPadreAlumno = "N/A";
        //    //
        //    if (txtTelPadreAlum.Text.Length > 0 && txtTelPadreAlum.Text != "")
        //        datoAlum.TelPadreAlumno = txtTelPadreAlum.Text;
        //    else
        //        datoAlum.TelPadreAlumno = "N/A";
        //    //
        //    if (txtNomMadreAlum.Text.Length > 0 && txtNomMadreAlum.Text != "")
        //        datoAlum.NomMadreAlumno = txtNomMadreAlum.Text;
        //    else
        //        datoAlum.NomMadreAlumno = "N/A";
        //    //
        //    if (txtTelMadreAlum.Text.Length > 0 && txtTelMadreAlum.Text != "")
        //        datoAlum.TelMadreAlumno = txtTelMadreAlum.Text;
        //    else
        //        datoAlum.TelMadreAlumno = "N/A";
        //    datoAlum.NomTutorAlumno = txtNomTutorAlum.Text;
        //    datoAlum.TelTutorAlumno = txtTelTutorAlum.Text;

        //    }
            protected void guardarDomicilio()
        {
            datoEmp.DireccionMaestro = txtDireccEmp.Text;
            //datoEmp.NumeroAlumno = txtNumAlum.Text;
            //datoEmp.ColoniaAlumno = txtColAlum.Text;
            //datoEmp.CodigoPostalAlumno = txtCPAlum.Text;
            datoEmp.IDMunicipioMaestro = Convert.ToInt32(ddlMunicipioEmp.SelectedValue);
            datoEmp.TelMaestro = txtTelAlum.Text;
            datoEmp.CorreoMaestro = TxtCorreoEmp.Text;
        }
        //protected void guardarEscProAlum()
        //{
        //    datoAlum.IDEscProAlumno = Convert.ToInt32(ddlEscProAlum.SelectedValue);
        //    datoAlum.IDTurno = Convert.ToInt32(ddlTurnoEscPro.SelectedValue);
        //}
        protected void guardarDocumentos()
        {
            string IDDocs;
            //Acta de Nacimiento
            if (chckDirectivo.Checked == true)
                datoPermiso.Directivo = 1;
            else
                datoPermiso.Directivo = 0;
            //Fotografias
            if (chckSecretariaAdm.Checked == true)
                datoPermiso.SecreAdmin = 1;
            else
                datoPermiso.SecreAdmin = 0;
            //Curp
            if (chckSecretariaAca.Checked == true)
                datoPermiso.SecreAcade = 1;
            else
                datoPermiso.SecreAcade = 0;
            //Constancia
            if (chckControl.Checked == true)
                datoPermiso.ControlEsc = 1;
            else
                datoPermiso.ControlEsc = 0;
            //Compromabte domiciliario
            if (chckDocente.Checked == true)
                datoPermiso.Docente = 1;
            else
                datoPermiso.Docente = 0;
            ////Boletas de calificaciones 
            //if (chckBoleCalifAlum.Checked == true)
            //    datoPermiso.BoletaCalificaciones = 1;
            //else
            //    datoPermiso.BoletaCalificaciones = 0;
            ////Certificado parcial 
            //if (chckCertifParcialAlum.Checked == true)
            //    datoPermiso.CertificadoParcial = 1;
            //else
            //    datoPermiso.CertificadoParcial = 0;
            ////Oficio de revalidación 
            //if (chckOfiRevalAlum.Checked == true)
            //    datoPermiso.OficioRevalidacion = 1;
            //else
            //    datoPermiso.OficioRevalidacion = 0;
            ////Constancia de comp. 1/2 
            //if (chckConstanciaMediaAlum.Checked == true)
            //    datoPermiso.ConstanciaMedia = 1;
            //else
            //    datoPermiso.ConstanciaMedia = 0;
            ////Certificado de secundaria
            //if (chckCertifSecunAlum.Checked == true)
            //    datoPermiso.CertificadoSecundaria = 1;
            //else
            //    datoPermiso.CertificadoSecundaria = 0;
            //if (txtrOtrosAlum.Text.Length > 0 && txtrOtrosAlum.Text != "")
            //    datoPermiso.Otros = txtrOtrosAlum.Text;
            //else
            //    datoPermiso.Otros = "N/A";
            ejecPermiso.agregarRegistroTipoMaestro(datoPermiso);
            IDDocs = ejecPermiso.buscarUltimoIDTipo("IDTipoMaestro");
            datoEmp.IDTipoMaestro = Convert.ToInt32(IDDocs);
        }
        //Para declarar la fecha maxima como el dia actual
        protected void rngFechaNacAlum_Init(object sender, EventArgs e)
        {
            ((RangeValidator)sender).MaximumValue = DateTime.Now.Date.ToString("dd-MM-yy");
        }
        protected void gvAlumnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAlumnos.PageIndex = e.NewPageIndex;
            LlenarGridViewAlumnos(Convert.ToInt32(ddlAlumnosReg.SelectedValue));

        }
        //Para llenar los grid view de los alumnos
        protected void LlenarGridViewAlumnos(int StatusMaestro)
        {
            gvAlumnos.DataSource = ejecEmp.LlenarGridView(StatusMaestro);
            gvAlumnos.DataBind();
            upAlumnos.Update();
        }
        ////Para llenar los drop down lists de tipos de alumnos
        protected void LLenarDropDownListsTipoAlumno()
        {
            ddlAlumnosReg.DataSource = ejecTipEmp.llenarTablasDDL();
            ddlAlumnosReg.DataTextField = "StatusMaestro";
            ddlAlumnosReg.DataValueField = "IDMaestro";
            ddlAlumnosReg.DataBind();
            upAlumnos.Update();
            if (ddlAlumnosReg.Items.Count != 0)
            {
                int TipoID = Convert.ToInt32(ddlAlumnosReg.SelectedValue);
                LlenarGridViewAlumnos(TipoID);
            }
        }
        //Para cambiar la lista de alumnos segun el tipo
        protected void ddlAlumnosReg_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IDTipo = Convert.ToInt32(ddlAlumnosReg.SelectedValue);
            LlenarGridViewAlumnos(IDTipo);

        }




        //////////////////////////////PAIS//////////////////////////////
        //Para llenar los drop down lists de pais [Seccion: Direccion]
        protected void LLenarDropDownListsPais()
        {
            ddlPaisEmp.DataSource = ejecPais.llenarTablasDDL();
            ddlPaisEmp.DataTextField = "Nombre";
            ddlPaisEmp.DataValueField = "IDPais";
            ddlPaisEmp.DataBind();
            upDireccion.Update();
            if (ddlPaisEmp.Items.Count != 0)
            {
                int PaisID = Convert.ToInt32(ddlPaisEmp.SelectedValue);
                LLenarDropDownListsEstado(PaisID);
            }
        }
        //Para llenar los drop down lists de pais [Seccion: Añadir Estado]
        protected void LLenarDropDownListsPais2()
        {
            ddlPaisAddEstado.DataSource = ejecPais.llenarTablasDDL();
            ddlPaisAddEstado.DataTextField = "Nombre";
            ddlPaisAddEstado.DataValueField = "IDPais";
            ddlPaisAddEstado.DataBind();
            upAddEstado.Update();
            if (ddlPaisAddEstado.Items.Count != 0)
            {
                int PaisID = Convert.ToInt32(ddlPaisAddEstado.SelectedValue);
                LlenarGridViewEstado(PaisID);
            }

        }
        //Para llenar los drop down lists de pais [Seccion: Añadir Municipio]
        protected void LLenarDropDownListsPais3()
        {
            ddlPaisAddMunicipio.DataSource = ejecPais.llenarTablasDDL();
            ddlPaisAddMunicipio.DataTextField = "Nombre";
            ddlPaisAddMunicipio.DataValueField = "IDPais";
            ddlPaisAddMunicipio.DataBind();
            upAddMunicipio.Update();
            if (ddlPaisAddMunicipio.Items.Count != 0)
            {
                int PaisID = Convert.ToInt32(ddlPaisAddMunicipio.SelectedValue);
                LLenarDropDownListsEstado2(PaisID);
            }

        }
        //Para cambiar los drop down lists de estado al seleccionar pais [Seccion: Direccion]
        protected void ddlPaisEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IDPais = Convert.ToInt32(ddlPaisEmp.SelectedValue);
            LLenarDropDownListsEstado(IDPais);
        }
        //Para cambiar los drop down lists de estado al seleccionar pais [Seccion: Añadir Estado]
        protected void ddlPaisAddEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IDPais = Convert.ToInt32(ddlPaisAddEstado.SelectedValue);
            LlenarGridViewEstado(IDPais);
        }
        //Para cambiar los drop down lists de estado al seleccionar pais [Seccion: Añadir Municipio]
        protected void ddlPaisAddMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IDPais = Convert.ToInt32(ddlPaisAddMunicipio.SelectedValue);
            LLenarDropDownListsEstado2(IDPais);

        }
        //Para llenar los grid view de los paises
        protected void LlenarGridViewPais()
        {
            gvAddPais.DataSource = ejecPais.llenarTablasDDL();
            gvAddPais.DataBind();
            upAddPais.Update();
            upDireccion.Update();
        }
        //Para cambiar de pagina en los grid view
        protected void gvAddPais_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAddPais.PageIndex = e.NewPageIndex;
            LlenarGridViewPais();
        }
        //Para agregar un país
        protected void btnAddNewPais_Click(object sender, EventArgs e)
        {
            if (txtAddPais.Text.Length > 0 && txtAddPais.Text != "")
            {
                datoPais.Nombre = txtAddPais.Text;
                ejecPais.agregarPais(datoPais);
                LlenarGridViewPais();
                LLenarDropDownListsPais();
                LLenarDropDownListsPais2();
                LLenarDropDownListsPais3();
                lbAdvAddPais.Visible = false;
                txtAddPais.Text = "";
            }
            else
            {
                lbAdvAddPais.Text = "¡Ingrese el nombre del país!";
                lbAdvAddPais.Visible = true;
            }
        }
        //Al presionar cancelar en el grid
        protected void gvAddPais_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAddPais.EditIndex = -1;
            LlenarGridViewPais();

        }
        //Al presionar editar en el grid
        protected void gvAddPais_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAddPais.EditIndex = e.NewEditIndex;
            LlenarGridViewPais();
        }
        //Para editar la informacion
        protected void gvAddPais_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            //Finding the controls from Gridview for the row which is going to update  
            Label id = gvAddPais.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
            TextBox name = gvAddPais.Rows[e.RowIndex].FindControl("txt_Name") as TextBox;
            datoPais.IDPais = Convert.ToInt32(id.Text);
            datoPais.Nombre = name.Text;
            ejecPais.modificarInfoPais(datoPais);
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            gvAddPais.EditIndex = -1;
            //Call ShowData method for displaying updated data  
            LlenarGridViewPais();
        }



        //////////////////////////////ESTADO//////////////////////////////
        //Para llenar los drop down lists de estado [Seccion: Direccion]
        protected void LLenarDropDownListsEstado(int IDPais)
        {
            ddlEstadoEmp.Items.Clear();
            ddlEstadoEmp.DataSource = ejecEstado.LlenarDropDownList(IDPais);
            ddlEstadoEmp.DataTextField = "Nombre";
            ddlEstadoEmp.DataValueField = "IDEstado";
            ddlEstadoEmp.DataBind();
            upDireccion.Update();
            if (ddlEstadoEmp.Items.Count != 0)
            {
                int IDEstado = Convert.ToInt32(ddlEstadoEmp.SelectedValue);

                LLenarDropDownListsMunicipio(IDEstado);
            }
        }
        //Para llenar los drop down lists de estado [Seccion: Añadir Municipio]
        protected void LLenarDropDownListsEstado2(int IDPais)
        {
            ddlEstadoAddMunicipio.Items.Clear();
            ddlEstadoAddMunicipio.DataSource = ejecEstado.LlenarDropDownList(IDPais);
            ddlEstadoAddMunicipio.DataTextField = "Nombre";
            ddlEstadoAddMunicipio.DataValueField = "IDEstado";
            ddlEstadoAddMunicipio.DataBind();
            upAddMunicipio.Update();
            if (ddlEstadoAddMunicipio.Items.Count != 0)
            {
                int EstadoID = Convert.ToInt32(ddlEstadoAddMunicipio.SelectedValue);
                LlenarGridViewMunicipio(EstadoID);
            }

        }
        //Para llenar los grid view de los estados
        protected void LlenarGridViewEstado(int IDPais)
        {
            gvAddEstado.DataSource = ejecEstado.LlenarDropDownList(IDPais);
            gvAddEstado.DataBind();
            upAddEstado.Update();
        }
        //Para cambiar de pagina en los grid view
        protected void gvAddEstado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAddEstado.PageIndex = e.NewPageIndex;
            LlenarGridViewEstado(Convert.ToInt32(ddlPaisAddEstado.SelectedValue));
        }
        //Para cambiar los drop down lists de municipios al seleccionar el estado [Seccion: Direccion]
        protected void ddlEstadoEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IDEstado = Convert.ToInt32(ddlEstadoEmp.SelectedValue);
            LLenarDropDownListsMunicipio(IDEstado);
        }
        //Para cambiar el grid view de municipios al seleccionar el estado [Seccion: Direccion]
        protected void ddlEstadoAddMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IDEstado = Convert.ToInt32(ddlEstadoAddMunicipio.SelectedValue);
            LlenarGridViewMunicipio(IDEstado);
        }
        //Para agregar un estado
        protected void btnAddEstado_Click(object sender, EventArgs e)
        {
            if (txtAddEstado.Text.Length > 0 && txtAddEstado.Text != "")
            {
                datoEstado.Nombre = txtAddEstado.Text;
                datoEstado.IDPais = Convert.ToInt32(ddlPaisAddEstado.SelectedValue);
                ejecEstado.agregarEstado(datoEstado);
                LlenarGridViewEstado(Convert.ToInt32(ddlPaisAddEstado.SelectedValue));
                lbAdvEstado.Visible = false;
                txtAddEstado.Text = "";
            }
            else
            {
                LlenarGridViewEstado(Convert.ToInt32(ddlPaisAddEstado.SelectedValue));
                lbAdvEstado.Text = "¡Ingrese el nombre del estado!";
                lbAdvEstado.Visible = true;
            }

        }
        protected void gvAddEstado_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Finding the controls from Gridview for the row which is going to update  
            Label id = gvAddEstado.Rows[e.RowIndex].FindControl("lbl_IDAddEstado") as Label;
            TextBox name = gvAddPais.Rows[e.RowIndex].FindControl("txt_NameAddEstado") as TextBox;
            datoEstado.IDEstado = Convert.ToInt32(id.Text);
            datoEstado.Nombre = name.Text;
            ejecEstado.modificarInfoEstado(datoEstado);
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            gvAddPais.EditIndex = -1;
            //Call ShowData method for displaying updated data  
            LlenarGridViewEstado(Convert.ToInt32(ddlPaisAddEstado.SelectedValue));

        }

        protected void gvAddEstado_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAddEstado.EditIndex = e.NewEditIndex;
            gvAddEstado.DataBind();
        }

        protected void gvAddEstado_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAddEstado.EditIndex = -1;
            LlenarGridViewEstado(Convert.ToInt32(ddlPaisAddEstado.SelectedValue));

        }




        //////////////////////////////MUNICIPIO//////////////////////////////
        //Para llenar los drop down lists de municipio
        protected void LLenarDropDownListsMunicipio(int IDEstado)
        {
            ddlMunicipioEmp.Items.Clear();
            ddlMunicipioEmp.DataSource = ejecMuni.LlenarDropDownList(IDEstado);
            ddlMunicipioEmp.DataTextField = "Nombre";
            ddlMunicipioEmp.DataValueField = "IDMunicipio";
            ddlMunicipioEmp.DataBind();
            upDireccion.Update();
        }
        //Para llenar los grid view de los estados
        protected void LlenarGridViewMunicipio(int IDEstado)
        {
            gvAddMunicipio.DataSource = ejecMuni.LlenarDropDownList(IDEstado);
            gvAddMunicipio.DataBind();
            upAddMunicipio.Update();
        }
        //Para cambiar de pagina en los grid view
        protected void gvAddMunicipio_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAddMunicipio.PageIndex = e.NewPageIndex;
            LlenarGridViewMunicipio(Convert.ToInt32(ddlEstadoAddMunicipio.SelectedValue));

        }
        //Para agregar un municipio
        protected void btnAddMunicipio_Click(object sender, EventArgs e)
        {
            if (txtAddMunicipio.Text.Length > 0 && txtAddMunicipio.Text != "")
            {
                datoMuni.Nombre = txtAddMunicipio.Text;
                datoMuni.IDEstado = Convert.ToInt32(ddlEstadoAddMunicipio.SelectedValue);
                ejecMuni.agregarMunicipio(datoMuni);
                LlenarGridViewMunicipio(Convert.ToInt32(ddlEstadoAddMunicipio.SelectedValue));
                lbAdvMunicipio.Visible = false;
                txtAddMunicipio.Text = "";
                LLenarDropDownListsMunicipio(Convert.ToInt32(ddlEstadoEmp.SelectedValue));
            }
            else
            {
                LlenarGridViewMunicipio(Convert.ToInt32(ddlEstadoAddMunicipio.SelectedValue));
                lbAdvMunicipio.Text = "¡Ingrese el nombre del municipio!";
                lbAdvMunicipio.Visible = true;
            }

        }



        //////////////////////////////ESCUELAS DE PROCEDENCIA//////////////////////////////
        //Para llenar los drop down lists de escuelas de procedencia
        //protected void LLenarDropDownListsEscuelasProc()
        //{
        //    if (!IsPostBack)
        //    {
        //        ddlEscProAlum.DataSource = ejecEscPro.llenarDDL();
        //        ddlEscProAlum.DataTextField = "NombreEscPro";
        //        ddlEscProAlum.DataValueField = "IDEscProAlumNO";
        //        ddlEscProAlum.DataBind();
        //    }
        //}
        //Para llenar los campos de la escuela al momento de seleccionar la escuela
        //protected void ddlEscProAlum_TextChanged(object sender, EventArgs e)
        //{
        //    datoEscPro.IDEscProAlumno = Convert.ToInt32(ddlEscProAlum.SelectedValue);
        //    txtNomEscProAlum.Text = ejecEscPro.buscarDatoEscPro("NombreEscPro", datoEscPro);
        //    txtClaveEscProAlum.Text = ejecEscPro.buscarDatoEscPro("ClaveEscPro", datoEscPro);
        //}
        //Para cambiar de pagina en los grid view
        //protected void gvEscProReg_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvEscProReg.PageIndex = e.NewPageIndex;
        //    LlenarGridViewEscPro();

        //}
        //Para llenar los grid view de las escuelas
        //protected void LlenarGridViewEscPro()
        //{
        //    gvEscProReg.DataSource = ejecEscPro.llenarTablas();
        //    gvEscProReg.DataBind();
        //    upAddEscPro.Update();
        //    upEscProAlum.Update();
        //    LLenarDropDownListsEscuelasProc();
        //}
        //Para agregar una escuela
        //protected void btnAddEscPro_Click(object sender, EventArgs e)
        //{
        //    if (txtNomEscProAdd.Text.Length > 0 && txtNomEscProAdd.Text != "")
        //    {
        //        if (txtClaveEscProAdd.Text.Length > 0 && txtClaveEscProAdd.Text != "")
        //        {
        //            datoEscPro.NombreEscPro = txtNomEscProAdd.Text;
        //            datoEscPro.ClaveEscPro = txtClaveEscProAdd.Text.ToUpper();
        //            ejecEscPro.agregarEscuelaPro(datoEscPro);
        //            LlenarGridViewEscPro();
        //            lbAdvClaveEscPro.Visible = false;
        //            txtClaveEscProAdd.Text = "";
        //            lbAdvNomEscPro.Visible = false;
        //            txtNomEscProAdd.Text = "";
        //        }
        //        else
        //        {
        //            lbAdvClaveEscPro.Text = "¡Ingrese el nombre de la escuela!";
        //            lbAdvClaveEscPro.Visible = true;
        //            lbAdvNomEscPro.Visible = false;
        //        }
        //    }
        //    else
        //    {
        //        lbAdvNomEscPro.Text = "¡Ingrese el nombre de la escuela!";
        //        lbAdvNomEscPro.Visible = true;
        //        lbAdvClaveEscPro.Visible = false;
        //    }
        //}
        //Para llenar los grid view de los turnos
        //protected void llenarDDLTurnos()
        //{
        //    ddlTurnoEscPro.DataSource = ejecTurno.llenarDDL();
        //    ddlTurnoEscPro.DataTextField = "Nombre";
        //    ddlTurnoEscPro.DataValueField = "IDTurno";
        //    ddlTurnoEscPro.DataBind();
        //}



        //////////////////////////////LOGICATUTORES//////////////////////////////
        //Cuando el padre es el tutor
        //protected void chckTutorPadre_CheckedChanged(object sender, EventArgs e)
        //{
        //    chckTutorMadre.Checked = false;
        //    txtNomTutorAlum.Text = txtNomPadreAlum.Text;
        //    txtTelTutorAlum.Text = txtTelPadreAlum.Text;
        //    upTutor.Update();
        //}
        //Cuando la madre es el tutor
        //protected void chckTutorMadre_CheckedChanged(object sender, EventArgs e)
        //{
        //    chckTutorPadre.Checked = false;
        //    txtNomTutorAlum.Text = txtNomMadreAlum.Text;
        //    txtTelTutorAlum.Text = txtTelMadreAlum.Text;
        //    upTutor.Update();
        //}

        protected void gvAlumnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string currentCommand = e.CommandName;
            int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
            int IDMaestro = Convert.ToInt32(gvAlumnos.DataKeys[currentRowIndex].Value);
            datoEmp.IDMaestro = IDMaestro;
            if (currentCommand == "SelectAlum")
            {
                //DATOS GENERALES
                txtNomEmp.Text = ejecEmp.buscarDatoAlumno("NomMaestro", datoEmp);
                txtApePatEmp.Text = ejecEmp.buscarDatoAlumno("ApePatMaestro", datoEmp);
                txtApeMatEmp.Text = ejecEmp.buscarDatoAlumno("ApeMatAlumno", datoEmp);
                //txtFechaNacEmp.Text = Convert.ToDateTime(ejecAlum.buscarDatoAlumno("FechaNacAlumno", datoAlum)).ToString("yyyy-MM-dd");
                txtCedula.Text = ejecEmp.buscarDatoAlumno("CedulaMaestro", datoEmp);
                txtGradoEmp.Text = ejecEmp.buscarDatoAlumno("GradoAcademicoMaestro", datoEmp);
                imgFotoEmp.ImageUrl = ejecEmp.buscarDatoAlumno("FotoMaestro", datoEmp);
                //DATOS DEL TUTOR
                //txtNomPadreAlum.Text = ejecAlum.buscarDatoAlumno("NomPadreAlumno", datoAlum);
                //txtTelPadreAlum.Text = ejecAlum.buscarDatoAlumno("TelPadreAlumno", datoAlum);
                //txtNomMadreAlum.Text = ejecAlum.buscarDatoAlumno("NomMadreAlumno", datoAlum);
                //txtTelMadreAlum.Text = ejecAlum.buscarDatoAlumno("TelMadreAlumno", datoAlum);
                //txtNomTutorAlum.Text = ejecAlum.buscarDatoAlumno("NomTutorAlumno", datoAlum);
                txtTelAlum.Text = ejecEmp.buscarDatoAlumno("TelMaestro", datoEmp);
                //if (txtNomPadre.Text == txtNomTutorAlum.Text)
                //    chckTutorPadre.Checked = true;
                //if (txtNomMadreAlum.Text == txtNomTutorAlum.Text)
                //    chckTutorMadre.Checked = true;
                //DATOS DEL DOMICILIO
                txtDireccEmp.Text = ejecEmp.buscarDatoAlumno("CalleAlumno", datoEmp);
                //txtNumAlum.Text = ejecAlum.buscarDatoAlumno("NumeroAlumno", datoAlum);
                //txtColAlum.Text = ejecAlum.buscarDatoAlumno("ColoniaAlumno", datoAlum);
                //txtCPAlum.Text = ejecAlum.buscarDatoAlumno("CodigoPostalAlumno", datoAlum);
                //txtTelAlum.Text = ejecAlum.buscarDatoAlumno("TelAlumno", datoAlum);
                int IDMunicipio = Convert.ToInt32(ejecEmp.buscarDatoAlumno("IDMunicipioAlumno", datoEmp));
                datoMuni.IDMunicipio = IDMunicipio;
                int IDEstado = Convert.ToInt32(ejecMuni.buscarDatoMunicipio("IDEstado", datoMuni));
                datoEstado.IDEstado = IDEstado;
                int IDPais = Convert.ToInt32(ejecEstado.buscarDatoEstado("IDPais", datoEstado));
                ddlPaisEmp.SelectedValue = IDPais.ToString();
                ddlEstadoEmp.SelectedValue = IDEstado.ToString();
                ddlMunicipioEmp.SelectedValue = IDMunicipio.ToString();
                upDireccion.Update();
                //DATOS ESCUELA DE PROCEDENCIA
                //ddlEscProAlum.SelectedValue = ejecAlum.buscarDatoAlumno("IDEscProAlumno", datoAlum);
                //datoEscPro.IDEscProAlumno = Convert.ToInt32(ddlEscProAlum.SelectedValue);
                //txtNomEscProAlum.Text = ejecEscPro.buscarDatoEscPro("NombreEscPro", datoEscPro);
                //txtClaveEscProAlum.Text = ejecEscPro.buscarDatoEscPro("ClaveEscPro", datoEscPro);
                //ddlTurnoEscPro.SelectedValue = ejecAlum.buscarDatoAlumno("IDTurno", datoAlum);
                //DATOS DOCUMENTOS
                datoTipEmp.IDTipoMaestro= Convert.ToInt32(ejecEmp.buscarDatoAlumno("IDDocumentosAlumno", datoEmp));
                if (ejecPermiso.buscarDatoPermiso("Directivo", datoPermiso) == "1")
                    chckDirectivo.Checked = true;
                if (ejecPermiso.buscarDatoPermiso("SecreAdmin", datoPermiso) == "1")
                    chckSecretariaAdm.Checked = true;
                if (ejecPermiso.buscarDatoPermiso("SecreAcade", datoPermiso) == "1")
                    chckSecretariaAca.Checked = true;
                if (ejecPermiso.buscarDatoPermiso("ControlEsc", datoPermiso) == "1")
                    chckControl.Checked = true;
                if (ejecPermiso.buscarDatoPermiso("Docente", datoPermiso) == "1")
                    chckDocente.Checked = true;
                //if (ejecDocs.buscarDatoDocs("BoletaCalificaciones", datoDocs) == "1")
                //    chckBoleCalifAlum.Checked = true;
                //if (ejecDocs.buscarDatoDocs("CertificadoParcial", datoDocs) == "1")
                //    chckCertifParcialAlum.Checked = true;
                //if (ejecDocs.buscarDatoDocs("OficioRevalidacion", datoDocs) == "1")
                //    chckOfiRevalAlum.Checked = true;
                //if (ejecDocs.buscarDatoDocs("ConstanciaMedia", datoDocs) == "1")
                //    chckConstanciaMediaAlum.Checked = true;
                //if (ejecDocs.buscarDatoDocs("CertificadoSecundaria", datoDocs) == "1")
                //    chckCertifSecunAlum.Checked = true;
                //txtrOtrosAlum.Text = ejecDocs.buscarDatoDocs("Otros", datoDocs);
                btnAgregarAlumno.Visible = false;
                UpdatePanel1.Update();
            }
        }

        protected void btnConfirmFoto_Click(object sender, EventArgs e)
        {
            if (fotoEmp.HasFile)
            {
                Session["RutaFoto"] = guardarPerfilMaestro();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "fotosuccessalert();", true);
            }
            else
            {
                Session["RutaFoto"] = "~/Resources/images/imgPerfil.jpg";
            }


            imgFotoEmp.ImageUrl = Session["RutaFoto"].ToString();

        }

        protected void btnConfirmCurriculum_Click(object sender, EventArgs e)
        {
            if (filecurriculum.HasFile)
            {
                Session["RutaCurriculum"] = guardarCurriculum();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "fotosuccessalert();", true);
            }
            else
            {
                Session["RutaCurriculum"] = "~/Resources/images/imgPerfil.jpg";
            }


            imgFotoEmp.ImageUrl = Session["RutaCurriculum"].ToString();
        }


    //protected void chckRevalida_CheckedChanged(object sender, EventArgs e)
    //{
    //    chckNuevoIng.Checked = false;
    //}

    //protected void chckNuevoIng_CheckedChanged(object sender, EventArgs e)
    //{
    //    chckRevalida.Checked = false;
    //}
}
}