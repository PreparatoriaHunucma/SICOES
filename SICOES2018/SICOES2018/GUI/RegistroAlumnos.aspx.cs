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
            btnAddNewPais.CausesValidation = false;
            if (!this.IsPostBack)
            {
                LLenarDropDownListsPais();
                LLenarDropDownListsPais2();
                LLenarDropDownListsPais3();
                LLenarDropDownListsEscuelasProc();
                llenarDDLTurnos();
                LLenarDropDownListsTipoAlumno();
                LlenarGridViewPais();
                LlenarGridViewEscPro();
                LlenarGridViewAlumnos(1);
                DataBind();
                ddlPaisAlum.SelectedValue = "1";
                LLenarDropDownListsEstado(Convert.ToInt32(ddlPaisAlum.SelectedValue));
                ddlEstadoAlum.SelectedValue = "1";
                LLenarDropDownListsMunicipio(Convert.ToInt32(ddlEstadoAlum.SelectedValue));

            }

        }
        protected void limpiarCampos()
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

        }

        //////////////////////////////ALUMNO//////////////////////////////
        protected void btnAgregarAlumno_Click(object sender, EventArgs e)
        {
            if (txtFechaNacAlum.Text != "")
            {
                DateTime valFechaNac = Convert.ToDateTime(txtFechaNacAlum.Text);
                DateTime fechaInicio = new DateTime(1900, 1, 1);
                if ((valFechaNac.Date >= fechaInicio.Date) && (valFechaNac.Date <= DateTime.Today))
                {
                    guardarDatosGenerales();
                    guardarDatosTutor();
                    guardarDomicilio();
                    guardarEscProAlum();
                    guardarDocumentos();
                    datoAlum.IDTipoAlumno = 1;
                    datoAlum.RevalidaAlumno = 1;
                    datoAlum.NuevoAlumno = 0;
                    ejecAlum.agregarAlumno(datoAlum);
                    limpiarCampos();
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
                    LlenarGridViewAlumnos(1);
                }
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert();", true);
        }
        protected void guardarDatosGenerales()
        {
            datoAlum.NomAlumno = txtNomAlumno.Text;
            datoAlum.ApePatAlumno = txtApePatAlumno.Text;
            datoAlum.ApeMatAlumno = txtApeMatAlumno.Text;
            datoAlum.FechaNacAlum = DateTime.ParseExact(txtFechaNacAlum.Text, "yyyy-MM-dd", CultureInfo.CurrentUICulture);
            datoAlum.CurpAlumno = txtCurpAlum.Text.ToUpper();
            if (fotoAlum.HasFile)
                datoAlum.FotoAlumno = guardarPerfilAlumno();
            else
                datoAlum.FotoAlumno = "~/Resources/images/imgPerfil.jpg";
        }
        protected string guardarPerfilAlumno()
        {
            string NombreArchivo = Path.GetFileName(fotoAlum.PostedFile.FileName);
            string RutaImagenes = "~/Resources/FotoPerfilAlumno/";
            Bitmap ImagenEnBinario = new Bitmap(fotoAlum.PostedFile.InputStream);
            System.Drawing.Image ObjetoImagengde = datoAlum.RedimencionarImagen(ImagenEnBinario, 500);
            ObjetoImagengde.Save(Server.MapPath(RutaImagenes + NombreArchivo));
            return RutaImagenes + NombreArchivo;
        }
        protected void guardarDatosTutor()
        {
            //
            if (txtNomPadreAlum.Text.Length > 0 && txtNomPadreAlum.Text != "")
                datoAlum.NomPadreAlumno = txtNomPadreAlum.Text;
            else
                datoAlum.NomPadreAlumno = "N/A";
            //
            if (txtTelPadreAlum.Text.Length > 0 && txtTelPadreAlum.Text != "")
                datoAlum.TelPadreAlumno = txtTelPadreAlum.Text;
            else
                datoAlum.TelPadreAlumno = "N/A";
            //
            if (txtNomMadreAlum.Text.Length > 0 && txtNomMadreAlum.Text != "")
                datoAlum.NomMadreAlumno = txtNomMadreAlum.Text;
            else
                datoAlum.NomMadreAlumno = "N/A";
            //
            if (txtTelMadreAlum.Text.Length > 0 && txtTelMadreAlum.Text != "")
                datoAlum.TelMadreAlumno = txtTelMadreAlum.Text;
            else
                datoAlum.TelMadreAlumno = "N/A";
            datoAlum.NomTutorAlumno = txtNomTutorAlum.Text;
            datoAlum.TelTutorAlumno = txtTelTutorAlum.Text;

        }
        protected void guardarDomicilio()
        {
            datoAlum.CalleAlumno = txtCallAlum.Text;
            datoAlum.NumeroAlumno = txtNumAlum.Text;
            datoAlum.ColoniaAlumno = txtColAlum.Text;
            datoAlum.CodigoPostalAlumno = txtCPAlum.Text;
            datoAlum.IDMunicipioAlumno = Convert.ToInt32(ddlMunicipioAlum.SelectedValue);
            datoAlum.TelAlumno = txtTelAlum.Text;
        }
        protected void guardarEscProAlum()
        {
            datoAlum.IDEscProAlumno = Convert.ToInt32(ddlEscProAlum.SelectedValue);
            datoAlum.IDTurno = Convert.ToInt32(ddlTurnoEscPro.SelectedValue);
        }
        protected void guardarDocumentos()
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
        protected void LlenarGridViewAlumnos(int IDTipoAlumno)
        {
            gvAlumnos.DataSource = ejecAlum.LlenarGridView(IDTipoAlumno);
            gvAlumnos.DataBind();
            upAlumnos.Update();
        }
        //Para llenar los drop down lists de tipos de alumnos
        protected void LLenarDropDownListsTipoAlumno()
        {
            ddlAlumnosReg.DataSource = ejecTipAlum.llenarTablasDDL();
            ddlAlumnosReg.DataTextField = "Nombre";
            ddlAlumnosReg.DataValueField = "IDTipoAlumno";
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
            ddlPaisAlum.DataSource = ejecPais.llenarTablasDDL();
            ddlPaisAlum.DataTextField = "Nombre";
            ddlPaisAlum.DataValueField = "IDPais";
            ddlPaisAlum.DataBind();
            upDireccion.Update();
            if (ddlPaisAlum.Items.Count != 0)
            {
                int PaisID = Convert.ToInt32(ddlPaisAlum.SelectedValue);
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
        protected void ddlPaisAlum_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IDPais = Convert.ToInt32(ddlPaisAlum.SelectedValue);
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
            ddlEstadoAlum.Items.Clear();
            ddlEstadoAlum.DataSource = ejecEstado.LlenarDropDownList(IDPais);
            ddlEstadoAlum.DataTextField = "Nombre";
            ddlEstadoAlum.DataValueField = "IDEstado";
            ddlEstadoAlum.DataBind();
            upDireccion.Update();
            if (ddlEstadoAlum.Items.Count != 0)
            {
                int IDEstado = Convert.ToInt32(ddlEstadoAlum.SelectedValue);

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
        protected void ddlEstadoAlum_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IDEstado = Convert.ToInt32(ddlEstadoAlum.SelectedValue);
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
            ddlMunicipioAlum.Items.Clear();
            ddlMunicipioAlum.DataSource = ejecMuni.LlenarDropDownList(IDEstado);
            ddlMunicipioAlum.DataTextField = "Nombre";
            ddlMunicipioAlum.DataValueField = "IDMunicipio";
            ddlMunicipioAlum.DataBind();
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
                LLenarDropDownListsMunicipio(Convert.ToInt32(ddlEstadoAlum.SelectedValue));
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
        protected void LLenarDropDownListsEscuelasProc()
        {
            if (!IsPostBack)
            {
                ddlEscProAlum.DataSource = ejecEscPro.llenarDDL();
                ddlEscProAlum.DataTextField = "NombreEscPro";
                ddlEscProAlum.DataValueField = "IDEscProAlumNO";
                ddlEscProAlum.DataBind();
            }
        }
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
            LlenarGridViewEscPro();

        }
        //Para llenar los grid view de las escuelas
        protected void LlenarGridViewEscPro()
        {
            gvEscProReg.DataSource = ejecEscPro.llenarTablas();
            gvEscProReg.DataBind();
            upAddEscPro.Update();
            upEscProAlum.Update();
            LLenarDropDownListsEscuelasProc();
        }
        //Para agregar una escuela
        protected void btnAddEscPro_Click(object sender, EventArgs e)
        {
            if (txtNomEscProAdd.Text.Length > 0 && txtNomEscProAdd.Text != "")
            {
                if (txtClaveEscProAdd.Text.Length > 0 && txtClaveEscProAdd.Text != "")
                {
                    datoEscPro.NombreEscPro = txtNomEscProAdd.Text;
                    datoEscPro.ClaveEscPro = txtClaveEscProAdd.Text.ToUpper();
                    ejecEscPro.agregarEscuelaPro(datoEscPro);
                    LlenarGridViewEscPro();
                    lbAdvClaveEscPro.Visible = false;
                    txtClaveEscProAdd.Text = "";
                    lbAdvNomEscPro.Visible = false;
                    txtNomEscProAdd.Text = "";
                }
                else
                {
                    lbAdvClaveEscPro.Text = "¡Ingrese el nombre de la escuela!";
                    lbAdvClaveEscPro.Visible = true;
                    lbAdvNomEscPro.Visible = false;
                }
            }
            else
            {
                lbAdvNomEscPro.Text = "¡Ingrese el nombre de la escuela!";
                lbAdvNomEscPro.Visible = true;
                lbAdvClaveEscPro.Visible = false;
            }
        }
        //Para llenar los grid view de los turnos
        protected void llenarDDLTurnos()
        {
            ddlTurnoEscPro.DataSource = ejecTurno.llenarDDL();
            ddlTurnoEscPro.DataTextField = "Nombre";
            ddlTurnoEscPro.DataValueField = "IDTurno";
            ddlTurnoEscPro.DataBind();
        }



        //////////////////////////////LOGICATUTORES//////////////////////////////
        //Cuando el padre es el tutor
        protected void chckTutorPadre_CheckedChanged(object sender, EventArgs e)
        {
            chckTutorMadre.Checked = false;
            txtNomTutorAlum.Text = txtNomPadreAlum.Text;
            txtTelTutorAlum.Text = txtTelPadreAlum.Text;
            upTutor.Update();
        }
        //Cuando la madre es el tutor
        protected void chckTutorMadre_CheckedChanged(object sender, EventArgs e)
        {
            chckTutorPadre.Checked = false;
            txtNomTutorAlum.Text = txtNomMadreAlum.Text;
            txtTelTutorAlum.Text = txtTelMadreAlum.Text;
            upTutor.Update();
        }

        protected void gvAlumnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string currentCommand = e.CommandName;
            int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
            int IDAlumno = Convert.ToInt32(gvAlumnos.DataKeys[currentRowIndex].Value);
            datoAlum.IDAlumno = IDAlumno;
            //DATOS GENERALES
            txtNomAlumno.Text = ejecAlum.buscarDatoAlumno("NomAlumno", datoAlum);
            txtApePatAlumno.Text = ejecAlum.buscarDatoAlumno("ApePatAlumno", datoAlum);
            txtApeMatAlumno.Text = ejecAlum.buscarDatoAlumno("ApeMatAlumno", datoAlum);
            txtFechaNacAlum.Text = Convert.ToDateTime(ejecAlum.buscarDatoAlumno("FechaNacAlumno", datoAlum)).ToString("yyyy-MM-dd");
            txtCurpAlum.Text = ejecAlum.buscarDatoAlumno("CurpAlumno", datoAlum);
            imgFotoAlum.ImageUrl = ejecAlum.buscarDatoAlumno("FotoAlumno", datoAlum);
            //DATOS DEL TUTOR
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
            //DATOS DEL DOMICILIO
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
            upDireccion.Update();
            //DATOS ESCUELA DE PROCEDENCIA
            ddlEscProAlum.SelectedValue = ejecAlum.buscarDatoAlumno("IDEscProAlumno", datoAlum);
            datoEscPro.IDEscProAlumno = Convert.ToInt32(ddlEscProAlum.SelectedValue);
            txtNomEscProAlum.Text = ejecEscPro.buscarDatoEscPro("NombreEscPro", datoEscPro);
            txtClaveEscProAlum.Text = ejecEscPro.buscarDatoEscPro("ClaveEscPro", datoEscPro);
            ddlTurnoEscPro.SelectedValue = ejecAlum.buscarDatoAlumno("IDTurno", datoAlum);
            //DATOS DOCUMENTOS
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
            UpdatePanel1.Update();


        }
    }
}