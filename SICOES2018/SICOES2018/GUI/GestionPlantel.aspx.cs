using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SICOES2018.BO;
using SICOES2018.DAO;

namespace SICOES2018.GUI
{
    public partial class GestionPlantel : System.Web.UI.Page
    {
        EstadoBO datoEstado = new EstadoBO();
        EstadoDAO ejecEstado = new EstadoDAO();
        DatosEscuelaBO datoEscuela = new DatosEscuelaBO();
        DatosEscuelaDAO ejecEscuela = new DatosEscuelaDAO();
        DepartamentosEscuelaBO datoDepartamento = new DepartamentosEscuelaBO();
        DepartamentosEscuelaDAO ejecDepartamento = new DepartamentosEscuelaDAO();
        MunicipioBO datoMuni = new MunicipioBO();
        MunicipioDAO ejecMuni = new MunicipioDAO();
        PaisBO datoPais = new PaisBO();
        PaisDAO ejecPais = new PaisDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataBind();
                LlenarTodosCampos();
                LLenarDDLPaisAlumno();
                LLenarDDLPaisEstado();
                LlenarDDLPaisMunicipio();
                LlenarGVPais();
                LlenarGVDepartamento();
                LLenarDDLDepartamentos();
                LlenarDDLDocentes(Convert.ToInt32(ddlDepartamentos.SelectedValue));
                LLenarDDLEncargado(Convert.ToInt32(ddlDepartamentos.SelectedValue));
                //ddlPaisAlum.SelectedValue = "1";
                //LLenarDDLEstadoAlumno(Convert.ToInt32(ddlPaisAlum.SelectedValue));
                //ddlEstadoAlum.SelectedValue = "1";
                //LLenarDDLMunicipioAlumno(Convert.ToInt32(ddlEstadoAlum.SelectedValue));
                //ddlMunicipioAlum.SelectedValue = "2";
            }
        }

        protected void LlenarTodosCampos()
        {
            datoEscuela.IDEscuela= 1;
            LlenarDatosEscuela();
            LlenarDireccion();
        }

        protected void LlenarDatosEscuela()
        {
            txtNomPlan.Text = ejecEscuela.buscarDatoEscuela("NombreEsc", datoEscuela);
            txtClave.Text = ejecEscuela.buscarDatoEscuela("ClaveEsc", datoEscuela);
            txtCorreo.Text = ejecEscuela.buscarDatoEscuela("EmailEsc", datoEscuela);
        }

        protected void LlenarDireccion()
        {
            txtCallAlum.Text = ejecEscuela.buscarDatoEscuela("CalleEsc", datoEscuela);
            txtColAlum.Text = ejecEscuela.buscarDatoEscuela("ColoniaEsc", datoEscuela);
            txtNumAlum.Text = ejecEscuela.buscarDatoEscuela("NumeroEsc", datoEscuela);
            txtCPAlum.Text = ejecEscuela.buscarDatoEscuela("CodigoPostalEsc", datoEscuela);
            txtTelAlum.Text = ejecEscuela.buscarDatoEscuela("TelEscuela", datoEscuela);
            int IDMunicipio = Convert.ToInt32(ejecEscuela.buscarDatoEscuela("IDMunicipio", datoEscuela));
            datoMuni.IDMunicipio = IDMunicipio;
            int IDEstado = Convert.ToInt32(ejecMuni.buscarDatoMunicipio("IDEstado", datoMuni));
            datoEstado.IDEstado = IDEstado;
            int IDPais = Convert.ToInt32(ejecEstado.buscarDatoEstado("IDPais", datoEstado));
            ddlPaisAlum.SelectedValue = IDPais.ToString();
            ddlEstadoAlum.SelectedValue = IDEstado.ToString();
            ddlMunicipioAlum.SelectedValue = IDMunicipio.ToString();

        }

        //Modificar información del alumno
        protected void btnModifAlumno_Click(object sender, EventArgs e)
        {

            datoEscuela.IDEscuela = 1;
            datoDepartamento.IDEscuela = 1;
            datoDepartamento.StatusDep = 1;
            ObtenerDatosGeneralesModif();
                    ObtenerDomicilio();
                    ejecEscuela.modificarInfoEscuela(datoEscuela);
                    ActualizarUPDatos();
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "modifsuccessalert();", true);
            //else
            //    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert();", true);

        }

        protected void btnModifEncargado_Click(object sender, EventArgs e)
        {
            datoDepartamento.IDDepartamentos = Convert.ToInt32(ddlDepartamentos.SelectedValue);
            datoDepartamento.IDEncargado = Convert.ToInt32(ddlDocentes.SelectedValue);
            ejecDepartamento.modificarInfoDepartamento(datoDepartamento);
            ActualizarUPDatos();
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "modifsuccessalert();", true);
        }

        private void ObtenerDomicilio()
        {
            datoEscuela.CalleEsc = txtCallAlum.Text;
            datoEscuela.NumeroEsc = txtNumAlum.Text;
            datoEscuela.ColoniaEsc = txtColAlum.Text;
            datoEscuela.CodigoPostalEsc = txtCPAlum.Text;
            datoEscuela.TelEsc = txtTelAlum.Text;
            datoEscuela.IDMunicipio = Convert.ToInt32(ddlMunicipioAlum.SelectedValue);

        }

        private void ObtenerDatosGeneralesModif()
        {
            datoEscuela.NombreEsc = txtNomPlan.Text;
            datoEscuela.ClaveEsc = txtClave.Text;
            datoEscuela.EmailEsc = txtCorreo.Text;
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

        protected void LLenarDDLDepartamentos()
        {
            ddlDepartamentos.Items.Clear();
            ddlDepartamentos.DataSource = ejecDepartamento.llenarTablasDDL();
            ddlDepartamentos.DataTextField = "NombreDep";
            ddlDepartamentos.DataValueField = "IDDepartamentos";
            ddlDepartamentos.DataBind();
            
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
        protected void LLenarDDLEncargado(int IDDepartamentos)

        {
            ddlEncargado.Items.Clear();
            ddlEncargado.DataSource = ejecDepartamento.LlenarDropDownList(IDDepartamentos);
           
                ddlEncargado.DataTextField = "NomMaestro";
                ddlEncargado.DataValueField = "IDMaestro";
                ddlEncargado.DataBind();
            

        }

        protected void LlenarDDLDocentes(int IDDepartamentos)

        {
            ddlDocentes.Items.Clear();
            ddlDocentes.DataSource = ejecDepartamento.NoAsignado();
            ddlDocentes.DataTextField = "NomMaestro";
            ddlDocentes.DataValueField = "IDMaestro";
            ddlDocentes.DataBind();
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

        ///ACCIONES CON LOS DEPARTAMENTOS////

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            LLenarDDLEncargado(Convert.ToInt32(ddlDepartamentos.SelectedValue));
            LlenarDDLDocentes(Convert.ToInt32(ddlDepartamentos.SelectedValue));
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
        //Para cambiar de pagina en los grid view

        protected void gvAddDepartamento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAddDepartamento.PageIndex = e.NewPageIndex;
            LlenarGVDepartamento();
            UpModalDepartamento.Update();
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
                txtAddPais.Text = "";
                ActualizarUPDatos();
                ActualizarUPModals();
            }
            else
            {
                LlenarGVPais();
                //upModalPais.Update();
            }
        }

        protected void LlenarGVDepartamento()
        {
            gvAddDepartamento.DataSource = ejecDepartamento.llenarTablasDDL();
            gvAddDepartamento.DataBind();
        }

        protected void btnAddNewDepartamento_Click(object sender, EventArgs e)
        {
            if (txtAddDepartamento.Text != string.Empty)
            {
                datoDepartamento.NombreDep = txtAddDepartamento.Text;
                ejecDepartamento.agregarDepartamento(datoDepartamento);
                LlenarGVDepartamento();
                LLenarDDLDepartamentos();
                txtAddDepartamento.Text = "";
                ActualizarUPDatos();
                ActualizarUPModals();
            }
            else
            {
                LlenarGVPais();
                //upModalPais.Update();
            }
        }

        //Al presionar cancelar en el grid
        protected void gvAddDepartamento_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAddDepartamento.EditIndex = -1;
            LlenarGVDepartamento();
        }

        //Al presionar editar en el grid
        protected void gvAddDepartamento_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAddDepartamento.EditIndex = e.NewEditIndex;
            LlenarGVDepartamento();
        }
        //Al presionar editar en el grid
        protected void gvAddPais_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAddPais.EditIndex = e.NewEditIndex;
            LlenarGVPais();
        }

        //Para editar la informacion
        protected void gvAddDepartamento_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label id = gvAddDepartamento.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
            TextBox name = gvAddDepartamento.Rows[e.RowIndex].FindControl("txt_Name") as TextBox;
            datoDepartamento.IDDepartamentos= Convert.ToInt32(id.Text);
            datoDepartamento.NombreDep = name.Text;
            ejecDepartamento.modificarInfoDepartamento(datoDepartamento);
            gvAddDepartamento.EditIndex = -1;
            LlenarGVDepartamento();
            LLenarDDLDepartamentos();
            ActualizarUPDatos();
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
        ///Acciones para los encargados////
        protected void ddlEncargado_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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

        protected void ActualizarUPDatos()
        {
            //upDatosGen.Update();
            //upDatosTut.Update();
            upDatosDir.Update();
            UpDepartamentos.Update();
            //upDatosEscPro.Update();
            //upDatosDocs.Update();
            upBotones.Update();
        }
        protected void ActualizarUPModals()
        {
            //upModalAlumnos.Update();
            //upModalEscPro.Update();
            upModalEstado.Update();
            UpModalDepartamento.Update();
            //upModalInsc.Update();
            upModalMunicipio.Update();
            upModalPais.Update();
        }
    }
}