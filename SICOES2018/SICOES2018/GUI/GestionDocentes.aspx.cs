using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using SICOES2018.BO;
using SICOES2018.DAO;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;

namespace SICOES2018.GUI
{
    public partial class GestionDocentes : System.Web.UI.Page
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
        PeriodoEscolarBO datoPer = new PeriodoEscolarBO();
        PeriodoEscolarDAO ejecPer = new PeriodoEscolarDAO();
        GruposBO datoGrupo = new GruposBO();
        GruposDAO ejecGrupo = new GruposDAO();
        AsignaturasBO datoAsig = new AsignaturasBO();
        AsignaturasDAO ejecAsig = new AsignaturasDAO();
        MaestroGruposBO datoMaestroGrupo = new MaestroGruposBO();
        MaestrosGruposDAO ejecMaestrosGrupos = new MaestrosGruposDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataBind();
                LLenarDDLPaisEmpleado();
                LLenarDDLPaisEstado();
                LLenarDDLPaisMunicipio();
                LlenarGVMaestros(Convert.ToInt32(ddlMaestrosReg.SelectedValue));
                ddlPaisEmp.SelectedValue = "1";
                LLenarDDLEstadoEmpleado(Convert.ToInt32(ddlPaisEmp.SelectedValue));
                LlenarDDLMunicipioEmpleado(Convert.ToInt32(ddlEstadoEmp.SelectedValue));
                LLenarDDLPeriodoAsignacion();
                ddlPeriodo.SelectedIndex = 0;
            }
            LlenarGVPais();

        }

        //////////OBTENER DATOS DEL ALUMNO DE LOS CAMPOS
        protected void ObtenerDatosGenerales()
        {
            datoEmp.NomMaestro = txtNomEmp.Text;
            datoEmp.ApePatMaestro = txtApePatEmp.Text;
            datoEmp.ApeMatMaestro = txtApeMatEmp.Text;
            datoEmp.CedulaMaestro = txtCedula.Text.ToUpper();
            datoEmp.GradoAcademicoMaestro = txtGradoEmp.Text;
            if (Session["RutaCurriculum"] != null)
                datoEmp.CurriculumMaestro = Session["RutaCurriculum"].ToString();
            else
                datoEmp.CurriculumMaestro = "/Curriculum/NoCV.pdf";
            if (Session["RutaFoto"] != null)
                datoEmp.FotoMaestro = Session["RutaFoto"].ToString();
            else
                datoEmp.FotoMaestro = imgFotoEmp.ImageUrl;


        }
        protected void ObtenerDatosGeneralesModif()
        {
            datoEmp.NomMaestro = txtNomEmp.Text;
            datoEmp.ApePatMaestro = txtApePatEmp.Text;
            datoEmp.ApeMatMaestro = txtApeMatEmp.Text;
            datoEmp.CedulaMaestro = txtCedula.Text.ToUpper();
            datoEmp.GradoAcademicoMaestro = txtGradoEmp.Text.ToUpper();
            if (Session["RutaFoto"] != null)
                datoEmp.FotoMaestro = Session["RutaFoto"].ToString();
            else
                datoEmp.FotoMaestro = imgFotoEmp.ImageUrl;
            if (Session["RutaCurriculum"] != null)
                datoEmp.CurriculumMaestro = Session["RutaCurriculum"].ToString();
            else
                datoEmp.CurriculumMaestro = ejecEmp.buscarDatoAlumno("CurriculumMaestro", datoEmp);


        }
        protected string ObtenerPerfilMaestro()
        {
            string Cantidad = ejecEmp.buscarCount("Cantidad");
            string NombreArchivo = Path.GetFileName(fotoEmp.PostedFile.FileName);
            string RutaImagenes = "~/Resources/FotoPerfilMaestro/";
            Bitmap ImagenEnBinario = new Bitmap(fotoEmp.PostedFile.InputStream);
            System.Drawing.Image ObjetoImagengde = datoEmp.RedimencionarImagen(ImagenEnBinario, 500);
            ObjetoImagengde.Save(Server.MapPath(RutaImagenes + Cantidad + "_" + NombreArchivo));
            return RutaImagenes + Cantidad + "_" + NombreArchivo;
        }
        protected string ObtenerCurriculum()
        {
            string path;
            string filename = filecurriculum.FileName;
            string Cantidad = ejecEmp.buscarCount("Cantidad");
            filecurriculum.PostedFile.SaveAs(Server.MapPath("~\\Curriculum\\" + Cantidad + "_" + filename.Trim()));

            path = "/Curriculum/" + Cantidad + "_" + filename.Trim();
            curriculumok.Text = filename;
            curriculumok.Visible = true;
            btnResubirCurriculum.Visible = true;
            return path;

            //string Cantidad = ejecEmp.buscarCount("Cantidad");
            //string NombreArchivo = Path.GetFileName(filecurriculum.PostedFile.FileName);
            //string savedFileName = Server.MapPath(@"\\Curriculum\\" + Cantidad + "_" + NombreArchivo);
            //filecurriculum.SaveAs(savedFileName);
            //filecurriculum.Visible = false;
            //curriculumok.Text = NombreArchivo;
            //curriculumok.Visible = true;
            //btnResubirCurriculum.Visible = true;
            //return savedFileName;
        }
        protected void ObtenerDomicilio()
        {
            datoEmp.DireccionMaestro = txtDireccEmp.Text;
            datoEmp.IDMunicipioMaestro = Convert.ToInt32(ddlMunicipioEmp.SelectedValue);
            datoEmp.TelMaestro = txtTelAlum.Text;
            datoEmp.CorreoMaestro = TxtCorreoEmp.Text;
        }
        protected void ObtenerPermisos()
        {
                datoPermiso.Docente = 1;
            ejecPermiso.agregarRegistroTipoMaestro(datoPermiso);
            datoEmp.IDTipoMaestro = Convert.ToInt32(ejecPermiso.buscarUltimoIDTipo("IDTipoMaestro"));
        }
        protected void ObtenerPermisosModif()
        {
                datoPermiso.Docente = 1;
            datoEmp.IDMaestro = Convert.ToInt32(Session["EmpModif"]);
            datoPermiso.IDTipoMaestro = Convert.ToInt32(ejecEmp.buscarDatoAlumno("IDTipoMaestro", datoEmp));
            ejecPermiso.modificarTipoMaestro(datoPermiso);
        }


        //////////Llenar grid views y drop down lists
        protected void LlenarGVMaestros(int StatusMaestro)
        {
            gvAlumnos.DataSource = ejecEmp.LlenarGridViewDocentes(StatusMaestro);
            gvAlumnos.DataBind();
        }

        protected void LlenarGVAsignaciones()
        {
            gvAsignaciones.DataSource = ejecMaestrosGrupos.LlenarGridView(Convert.ToInt32(Session["EmpModif"]));
            gvAsignaciones.DataBind();
        }

        protected void LLenarDDLPaisEmpleado()
        {
            ddlPaisEmp.Items.Clear();
            ddlPaisEmp.DataSource = ejecPais.llenarTablasDDL();
            ddlPaisEmp.DataTextField = "Nombre";
            ddlPaisEmp.DataValueField = "IDPais";
            ddlPaisEmp.DataBind();
            if (ddlPaisEmp.Items.Count != 0)
            {
                LLenarDDLEstadoEmpleado(Convert.ToInt32(ddlPaisEmp.SelectedValue));
            }
        }
        protected void LLenarDDLPeriodoAsignacion()
        {
            ddlPeriodo.Items.Clear();
            ddlPeriodo.DataSource = ejecPer.llenarDDLCicloActivo();
            ddlPeriodo.DataTextField = "Nombre";
            ddlPeriodo.DataValueField = "IDPeriodo";
            ddlPeriodo.DataBind();
            if (ddlPeriodo.Items.Count != 0)
            {
                LLenarDDLGruposAsignacion(Convert.ToInt32(ddlPeriodo.SelectedValue));
            }
        }
        protected void LLenarDDLGruposAsignacion(int Periodo)
        {
            ddlGrupo.Items.Clear();
            ddlGrupo.DataSource = ejecGrupo.llenarDDL(Periodo);
            ddlGrupo.DataTextField = "NombreGrupo";
            ddlGrupo.DataValueField = "IDGrupo";
            ddlGrupo.DataBind();
            if (ddlGrupo.Items.Count != 0)
            {
                LLenarDDLMateriasAsignacion(Convert.ToInt32(ddlGrupo.SelectedValue));
            }
        }

        protected void LLenarDDLMateriasAsignacion(int Grupo)
        {
            ddlMateria.Items.Clear();
            ddlMateria.DataSource = ejecAsig.LlenarDDL(Grupo);
            ddlMateria.DataTextField = "NomAsig";
            ddlMateria.DataValueField = "IDAsignatura";
            ddlMateria.DataBind();
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
                LlenarGVEstado(Convert.ToInt32(ddlPaisAddEstado.SelectedValue));
            }

        }
        protected void LLenarDDLPaisMunicipio()
        {
            ddlPaisAddMunicipio.Items.Clear();
            ddlPaisAddMunicipio.DataSource = ejecPais.llenarTablasDDL();
            ddlPaisAddMunicipio.DataTextField = "Nombre";
            ddlPaisAddMunicipio.DataValueField = "IDPais";
            ddlPaisAddMunicipio.DataBind();
            if (ddlPaisAddMunicipio.Items.Count != 0)
            {
                LLenarDDLEstadoMunicipio(Convert.ToInt32(ddlPaisAddMunicipio.SelectedValue));
            }

        }
        protected void LlenarGVPais()
        {
            gvAddPais.DataSource = ejecPais.llenarTablasDDL();
            gvAddPais.DataBind();
        }
        protected void LLenarDDLEstadoEmpleado(int IDPais)
        {
            ddlEstadoEmp.Items.Clear();
            ddlEstadoEmp.DataSource = ejecEstado.LlenarDropDownList(IDPais);
            ddlEstadoEmp.DataTextField = "Nombre";
            ddlEstadoEmp.DataValueField = "IDEstado";
            ddlEstadoEmp.DataBind();
            if (ddlEstadoEmp.Items.Count != 0)
            {
                LlenarDDLMunicipioEmpleado(Convert.ToInt32(ddlEstadoEmp.SelectedValue));
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
                LlenarGVMunicipio(Convert.ToInt32(ddlEstadoAddMunicipio.SelectedValue));
            }

        }
        protected void LlenarGVEstado(int IDPais)
        {
            gvAddEstado.DataSource = ejecEstado.LlenarDropDownList(IDPais);
            gvAddEstado.DataBind();
            upAddEstado.Update();
        }
        protected void LlenarDDLMunicipioEmpleado(int IDEstado)
        {
            ddlMunicipioEmp.Items.Clear();
            ddlMunicipioEmp.DataSource = ejecMuni.LlenarDropDownList(IDEstado);
            ddlMunicipioEmp.DataTextField = "Nombre";
            ddlMunicipioEmp.DataValueField = "IDMunicipio";
            ddlMunicipioEmp.DataBind();
        }
        protected void LlenarGVMunicipio(int IDEstado)
        {
            gvAddMunicipio.DataSource = ejecMuni.LlenarDropDownList(IDEstado);
            gvAddMunicipio.DataBind();
        }


        protected void LimpiarCampos()
        {
            ChckActivo.Checked = false;
            ChckInactivo.Checked = false;
            ESTATUSDELPERSONAL.Visible = false;
            txtNomEmp.Text = String.Empty;
            txtApePatEmp.Text = String.Empty;
            txtApeMatEmp.Text = String.Empty;
            txtCedula.Text = String.Empty;
            txtDireccEmp.Text = String.Empty;
            txtTelAlum.Text = String.Empty;
            TxtCorreoEmp.Text = String.Empty;
            txtGradoEmp.Text = string.Empty;
            //chckDirectivo.Checked = false;
            //chckSecretariaAdm.Checked = false;
            //chckSecretariaAca.Checked = false;
            //chckControl.Checked = false;
            //chckDocente.Checked = false;
            chckHombre.Checked = false;
            chckMujer.Checked = false;
            ddlUltGrado.SelectedIndex = 0;


            imgFotoEmp.ImageUrl = "~/Resources/images/imgPerfil.jpg";
        }
        protected void LimpiarCheckboxes()
        {
            chckHombre.Checked = false;
            chckMujer.Checked = false;
        }
        protected void ActualizarDatos()
        {
            upDatosDir.Update();
            upDatosEstatus.Update();
            upDatosGen.Update();
           // upDatosPermisos.Update();
            upBotones.Update();
        }
        protected void ActualizarModals()
        {
            upAddPais.Update();
            upAddEstado.Update();
            upAddMunicipio.Update();
            upAlumnos.Update();
        }

        //////////////////////////////ACCIONES CON LOS MAESTROS
        protected void btnAgregarEmp_Click(object sender, EventArgs e)
        {
            if (txtNomEmp.Text != string.Empty && txtCedula.Text != string.Empty)
            {
                ObtenerDatosGenerales();
                ObtenerDomicilio();
                ObtenerPermisos();

                if (chckHombre.Checked == true)

                    datoEmp.Sexo = 1;

                if (chckMujer.Checked == true)

                    datoEmp.Sexo = 2;

                if (ddlUltGrado.Items[0].Selected)

                    datoEmp.UltimoGrado = ddlUltGrado.Text;

                if (ddlUltGrado.Items[1].Selected)

                    datoEmp.UltimoGrado = "Ing.";

                if (ddlUltGrado.Items[2].Selected)

                    datoEmp.UltimoGrado = "Lic.";

                if (ddlUltGrado.Items[3].Selected)

                    datoEmp.UltimoGrado = "Mtr.";

                if (ddlUltGrado.Items[4].Selected && chckHombre.Checked == true)

                    datoEmp.UltimoGrado = "Dr.";

                if (ddlUltGrado.Items[4].Selected && chckMujer.Checked == true)

                    datoEmp.UltimoGrado = "Dra.";

                datoEmp.GradoAcademicoMaestro = txtGradoEmp.Text;

                datoEmp.StatusMaestro = 1;
                ejecEmp.agregarMaestro(datoEmp);

                datoEmp.IDMaestro = Convert.ToInt32(ejecEmp.buscarUltimoID("IDMaestro"));
                string nombre = ejecEmp.buscarDatoAlumno("NomMaestro", datoEmp).ToLower();
                string tresletras = nombre.Substring(0, 3);
                string apellido;
                if (ejecEmp.buscarDatoAlumno("ApePatMaestro", datoEmp).ToLower() != string.Empty)
                    apellido = ejecEmp.buscarDatoAlumno("ApePatMaestro", datoEmp).ToLower();
                else
                    apellido = ejecEmp.buscarDatoAlumno("ApeMatMaestro", datoEmp).ToLower();
                string usuario = tresletras + "." + apellido + (ejecEmp.buscarUltimoID("IDMaestro")).ToString();
                datoEmp.UsuarioMaestro = datoEmp.EncriptarMD5(usuario);
                string contraseña = "123456";
                datoEmp.ContrasenhaMaestro = datoEmp.EncriptarMD5(contraseña);
                ejecEmp.modificarCredencialesMaestro(datoEmp);

                LlenarGVMaestros(1);
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert();", true);
            ActualizarDatos();
        }
        protected void btnConfirmFoto_Click(object sender, EventArgs e)
        {
            if (fotoEmp.HasFile)
            {
                Session["RutaFoto"] = ObtenerPerfilMaestro();
            }
            else
            {
                Session["RutaFoto"] = "~/Resources/images/imgPerfil.jpg";
            }
            imgFotoEmp.ImageUrl = Session["RutaFoto"].ToString();
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "fotosuccessalert();", true);
        }
        protected void btnModifAlumno_Click(object sender, EventArgs e)
        {
            if (txtNomEmp.Text != string.Empty && txtCedula.Text != string.Empty && txtTelAlum.Text != string.Empty)
            {
                datoEmp.IDMaestro = Convert.ToInt32(Session["EmpModif"]);
                ObtenerDatosGeneralesModif();
                ObtenerDomicilio();
                ObtenerPermisosModif();

                if (chckHombre.Checked == true)

                    datoEmp.Sexo = 1;

                if (chckMujer.Checked == true)

                    datoEmp.Sexo = 2;

                if (ddlUltGrado.Items[0].Selected)

                    datoEmp.UltimoGrado = ddlUltGrado.Text;

                if (ddlUltGrado.Items[1].Selected)

                    datoEmp.UltimoGrado = "Ing.";

                if (ddlUltGrado.Items[2].Selected)

                    datoEmp.UltimoGrado = "Lic.";

                if (ddlUltGrado.Items[3].Selected)

                    datoEmp.UltimoGrado = "Mtr.";

                if (ddlUltGrado.Items[4].Selected && chckHombre.Checked == true)

                    datoEmp.UltimoGrado = "Dr.";

                if (ddlUltGrado.Items[4].Selected && chckMujer.Checked == true)

                    datoEmp.UltimoGrado = "Dra.";

                datoEmp.GradoAcademicoMaestro = txtGradoEmp.Text;

                if (ChckActivo.Checked == true)
                    datoEmp.StatusMaestro = 1;
                else
                    datoEmp.StatusMaestro = 0;
                ejecEmp.modificarInfoMaestro(datoEmp);
                LimpiarCampos();
                LlenarGVMaestros(1);
                btnAgregarAlumno.Visible = true;
                btnModifAlumno.Visible = false;
                btnAsignarGrupo.Visible = false;
                filecurriculum.Visible = true;
                curriculumok.Visible = false;
                btnResubirCurriculum.Visible = false;
                ActualizarDatos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "modifsuccessalert();", true);

            }
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert();", true);
        }
        protected void btnConfirmCurriculum_Click(object sender, EventArgs e)
        {
            if (filecurriculum.HasFile)
            {
                Session["RutaCurriculum"] = ObtenerCurriculum();
            }
            else
            {
                Session["RutaCurriculum"] = "/Curriculum/NoCV.pdf";
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "fotosuccessalert();", true);
        }
        protected void btnResubir_Click(object sender, EventArgs e)
        {
            curriculumok.Visible = false;
            filecurriculum.Visible = true;
            btnResubirCurriculum.Visible = false;
        }


        //////////ACCIONES CON EL GRID VIEW DE LOS ALUMNOS
        protected void ddlAlumnosReg_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarGVMaestros(Convert.ToInt32(ddlMaestrosReg.SelectedValue));
        }
        protected void gvAlumnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string currentCommand = e.CommandName;
            LimpiarCampos();

            if (currentCommand == "SelectAlum")
            {
                ChckActivo.Visible = true;
                ChckInactivo.Visible = true;
                ESTATUSDELPERSONAL.Visible = true;
                int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
                Session["EmpModif"] = Convert.ToInt32(gvAlumnos.DataKeys[currentRowIndex].Value);
                datoEmp.IDMaestro = Convert.ToInt32(Session["EmpModif"]); ;

                LimpiarCheckboxes();

                if (ejecEmp.buscarDatoAlumno("Sexo", datoEmp) == "1")
                    chckHombre.Checked = true;
                if (ejecEmp.buscarDatoAlumno("Sexo", datoEmp) == "2")
                    chckMujer.Checked = true;
                if (ejecEmp.buscarDatoAlumno("UltimoGrado", datoEmp) == "T.S.U")
                    ddlUltGrado.SelectedIndex = 0;
                if (ejecEmp.buscarDatoAlumno("UltimoGrado", datoEmp) == "Ing.")
                    ddlUltGrado.SelectedIndex = 1;
                if (ejecEmp.buscarDatoAlumno("UltimoGrado", datoEmp) == "Lic.")
                    ddlUltGrado.SelectedIndex = 2;
                if (ejecEmp.buscarDatoAlumno("UltimoGrado", datoEmp) == "Mtr.")
                    ddlUltGrado.SelectedIndex = 3;
                if (ejecEmp.buscarDatoAlumno("UltimoGrado", datoEmp) == "Dr.")
                    ddlUltGrado.SelectedIndex = 4;
                if (ejecEmp.buscarDatoAlumno("UltimoGrado", datoEmp) == "Dra.")
                    ddlUltGrado.SelectedIndex = 4;
                

                txtNomEmp.Text = ejecEmp.buscarDatoAlumno("NomMaestro", datoEmp);
                txtApePatEmp.Text = ejecEmp.buscarDatoAlumno("ApePatMaestro", datoEmp);
                txtApeMatEmp.Text = ejecEmp.buscarDatoAlumno("ApeMatMaestro", datoEmp);
                txtCedula.Text = ejecEmp.buscarDatoAlumno("CedulaMaestro", datoEmp);
                txtGradoEmp.Text = ejecEmp.buscarDatoAlumno("GradoAcademicoMaestro", datoEmp);
                imgFotoEmp.ImageUrl = ejecEmp.buscarDatoAlumno("FotoMaestro", datoEmp);
                filecurriculum.Visible = false;
                curriculumok.Visible = true;
                Session["RutaCurriculum"] = ejecEmp.buscarDatoAlumno("CurriculumMaestro", datoEmp);
                curriculumok.Text = "<a href ='" + ejecEmp.buscarDatoAlumno("CurriculumMaestro", datoEmp) + "'>Ver Curriculum</a>";

                txtDireccEmp.Text = ejecEmp.buscarDatoAlumno("DireccionMaestro", datoEmp);
                int IDMunicipio = Convert.ToInt32(ejecEmp.buscarDatoAlumno("IDMunicipioMaestro", datoEmp));
                datoMuni.IDMunicipio = IDMunicipio;
                int IDEstado = Convert.ToInt32(ejecMuni.buscarDatoMunicipio("IDEstado", datoMuni));
                datoEstado.IDEstado = IDEstado;
                int IDPais = Convert.ToInt32(ejecEstado.buscarDatoEstado("IDPais", datoEstado));
                txtTelAlum.Text = ejecEmp.buscarDatoAlumno("TelMaestro", datoEmp);
                TxtCorreoEmp.Text = Convert.ToString(ejecEmp.buscarDatoAlumno("CorreoMaestro", datoEmp));
                ddlPaisEmp.SelectedValue = IDPais.ToString();
                ddlEstadoEmp.SelectedValue = IDEstado.ToString();
                ddlMunicipioEmp.SelectedValue = IDMunicipio.ToString();

                //datoPermiso.IDTipoMaestro = Convert.ToInt32(ejecEmp.buscarDatoAlumno("IDTipoMaestro", datoEmp));
                //if (ejecPermiso.buscarDatoPermiso("Directivo", datoPermiso) == "1")
                //    chckDirectivo.Checked = true;
                //if (ejecPermiso.buscarDatoPermiso("SecreAdmin", datoPermiso) == "1")
                //    chckSecretariaAdm.Checked = true;
                //if (ejecPermiso.buscarDatoPermiso("SecreAcade", datoPermiso) == "1")
                //    chckSecretariaAca.Checked = true;
                //if (ejecPermiso.buscarDatoPermiso("ControlEsc", datoPermiso) == "1")
                //    chckControl.Checked = true;
                //if (ejecPermiso.buscarDatoPermiso("Docente", datoPermiso) == "1")
                //    chckDocente.Checked = true;
                if (ejecEmp.buscarDatoStatus("StatusMaestro", datoEmp) == "1")
                   ChckActivo.Checked = true;
                else
                    ChckInactivo.Checked = true;


                LlenarGVAsignaciones();
                UpdatePanel1.Update();

                btnAgregarAlumno.Visible = false;
                btnModifAlumno.Visible = true;
                btnAsignarGrupo.Visible = true;
                btnResubirCurriculum.Visible = true;
            }
            ActualizarDatos();
        }
        protected void gvAlumnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAlumnos.PageIndex = e.NewPageIndex;
            LlenarGVMaestros(Convert.ToInt32(ddlMaestrosReg.SelectedValue));

        }

        protected void LLenarDDLMunicipioAlumno(int IDEstado)
        {
            ddlMunicipioEmp.Items.Clear();
            ddlMunicipioEmp.DataSource = ejecMuni.LlenarDropDownList(IDEstado);
            ddlMunicipioEmp.DataTextField = "Nombre";
            ddlMunicipioEmp.DataValueField = "IDMunicipio";
            ddlMunicipioEmp.DataBind();
        }


        //////////////////////////////ACCIONES CON LOS PAISES
        protected void ddlPaisEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            LLenarDDLEstadoEmpleado(Convert.ToInt32(ddlPaisEmp.SelectedValue));
        }
        protected void ddlPaisAddEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarGVEstado(Convert.ToInt32(ddlPaisAddEstado.SelectedValue));
        }
        protected void ddlPaisAddMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            LLenarDDLEstadoMunicipio(Convert.ToInt32(ddlPaisAddMunicipio.SelectedValue));
        }
        protected void gvAddPais_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAddPais.PageIndex = e.NewPageIndex;
            LlenarGVPais();
        }
        protected void btnAddNewPais_Click(object sender, EventArgs e)
        {
            if (txtAddPais.Text != string.Empty)
            {
                datoPais.Nombre = txtAddPais.Text;
                ejecPais.agregarPais(datoPais);
                LlenarGVPais();
                LLenarDDLPaisEmpleado();
                LLenarDDLPaisEstado();
                LLenarDDLPaisMunicipio();
                lbAdvAddPais.Visible = false;
                txtAddPais.Text = string.Empty;
                ActualizarDatos();
                ActualizarModals();
            }
            else
            {
                lbAdvAddPais.Text = "¡Ingrese el nombre del país!";
                lbAdvAddPais.Visible = true;
                upAddPais.Update();
            }
        }
        protected void gvAddPais_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAddPais.EditIndex = -1;
            LlenarGVPais();

        }
        protected void gvAddPais_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAddPais.EditIndex = e.NewEditIndex;
            LlenarGVPais();
        }
        protected void gvAddPais_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label id = gvAddPais.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
            TextBox name = gvAddPais.Rows[e.RowIndex].FindControl("txt_Name") as TextBox;
            datoPais.IDPais = Convert.ToInt32(id.Text);
            datoPais.Nombre = name.Text;
            ejecPais.modificarInfoPais(datoPais);
            gvAddPais.EditIndex = -1;
            LlenarGVPais();
        }


        //////////////////////////////ACCIONES CON LOS ESTADOS
        protected void ddlEstadoEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarDDLMunicipioEmpleado(Convert.ToInt32(ddlEstadoEmp.SelectedValue));
        }
        protected void ddlEstadoAddMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarGVMunicipio(Convert.ToInt32(ddlEstadoAddMunicipio.SelectedValue));
        }
        protected void gvAddEstado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAddEstado.PageIndex = e.NewPageIndex;
            LlenarGVEstado(Convert.ToInt32(ddlPaisAddEstado.SelectedValue));
        }

        protected void ddlEstadoAlum_SelectedIndexChanged(object sender, EventArgs e)
        {
            LLenarDDLMunicipioAlumno(Convert.ToInt32(ddlEstadoEmp.SelectedValue));
        }
        protected void btnAddEstado_Click(object sender, EventArgs e)
        {
            if (txtAddEstado.Text != string.Empty)
            {
                datoEstado.Nombre = txtAddEstado.Text;
                datoEstado.IDPais = Convert.ToInt32(ddlPaisAddEstado.SelectedValue);
                ejecEstado.agregarEstado(datoEstado);
                LlenarGVEstado(Convert.ToInt32(ddlPaisAddEstado.SelectedValue));
                LLenarDDLEstadoEmpleado(Convert.ToInt32(ddlPaisEmp.SelectedValue));
                LLenarDDLEstadoMunicipio(Convert.ToInt32(ddlPaisAddMunicipio.SelectedValue));
                lbAddEstado.Visible = false;
                txtAddEstado.Text = string.Empty;
                ActualizarDatos();
                ActualizarModals();
            }
            else
            {
                lbAddEstado.Text = "¡Ingrese el nombre del estado!";
                lbAddEstado.Visible = true;
                upAddEstado.Update();
            }

        }
        protected void gvAddEstado_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label id = gvAddEstado.Rows[e.RowIndex].FindControl("lbl_IDAddEstado") as Label;
            TextBox name = gvAddEstado.Rows[e.RowIndex].FindControl("txt_NameAddEstado") as TextBox;
            datoEstado.IDEstado = Convert.ToInt32(id.Text);
            datoEstado.Nombre = name.Text;
            ejecEstado.modificarInfoEstado(datoEstado);
            gvAddPais.EditIndex = -1;
            LlenarGVEstado(Convert.ToInt32(ddlPaisAddEstado.SelectedValue));
        }
        protected void gvAddEstado_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAddEstado.EditIndex = e.NewEditIndex;
            gvAddEstado.DataBind();
        }
        protected void gvAddEstado_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAddEstado.EditIndex = -1;
            LlenarGVEstado(Convert.ToInt32(ddlPaisAddEstado.SelectedValue));

        }


        //////////////////////////////ACCIONES CON LOS MUNICIPIOS
        protected void gvAddMunicipio_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAddMunicipio.PageIndex = e.NewPageIndex;
            LlenarGVMunicipio(Convert.ToInt32(ddlEstadoAddMunicipio.SelectedValue));

        }

        protected void gvAddMunicipio_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAddMunicipio.EditIndex = e.NewEditIndex;
            LlenarGVMunicipio(Convert.ToInt32(ddlEstadoAddMunicipio.SelectedValue));
        }

        protected void gvAddMunicipio_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label id = gvAddMunicipio.Rows[e.RowIndex].FindControl("lbl_IDAddMuni") as Label;
            TextBox name = gvAddMunicipio.Rows[e.RowIndex].FindControl("txt_NameAddMuni") as TextBox;
            datoMuni.IDMunicipio = Convert.ToInt32(id.Text);
            datoMuni.Nombre = name.Text;
            ejecMuni.modificarInfoMuni(datoMuni);
            gvAddMunicipio.EditIndex = -1;
            LlenarGVMunicipio(Convert.ToInt32(ddlEstadoAddMunicipio.SelectedValue));
            LLenarDDLMunicipioAlumno(Convert.ToInt32(ddlEstadoEmp.SelectedValue));
            ActualizarUPDatos();
        }

        protected void gvAddMunicipio_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAddMunicipio.EditIndex = -1;
            LlenarGVMunicipio(Convert.ToInt32(ddlEstadoAddMunicipio.SelectedValue));
        }
        protected void btnAddMunicipio_Click(object sender, EventArgs e)
        {
            if (txtAddMunicipio.Text != string.Empty)
            {
                datoMuni.Nombre = txtAddMunicipio.Text;
                datoMuni.IDEstado = Convert.ToInt32(ddlEstadoAddMunicipio.SelectedValue);
                ejecMuni.agregarMunicipio(datoMuni);
                LlenarGVMunicipio(Convert.ToInt32(ddlEstadoAddMunicipio.SelectedValue));
                LlenarDDLMunicipioEmpleado(Convert.ToInt32(ddlEstadoEmp.SelectedValue));
                lbAdvMunicipio.Visible = false;
                txtAddMunicipio.Text = string.Empty;
                ActualizarDatos();
                ActualizarModals();
            }
            else
            {
                lbAdvMunicipio.Text = "¡Ingrese el nombre del municipio!";
                lbAdvMunicipio.Visible = true;
                upAddMunicipio.Update();
            }

        }

        protected void chckHombre_CheckedChanged(object sender, EventArgs e)
        {


        }

        protected void chckMujer_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void ChckInactivo_CheckedChanged(object sender, EventArgs e)
        {
            ChckActivo.Checked = false;
        }
        protected void ChckActivo_CheckedChanged(object sender, EventArgs e)
        {
            ChckInactivo.Checked = false;
        }

        //protected void chckDirectivo_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chckDirectivo.Checked == true)
        //    {
        //        chckControl.Checked = true;
        //        chckSecretariaAca.Checked = true;
        //        chckSecretariaAdm.Checked = true;
        //        chckDocente.Checked = true;
        //    }
        //}

        //protected void chckSecretariaAdm_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chckSecretariaAdm.Checked == false)
        //        chckDirectivo.Checked = false;
        //}

        //protected void chckSecretariaAca_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chckSecretariaAca.Checked == false)
        //        chckDirectivo.Checked = false;

        //}

        //protected void chckControl_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chckControl.Checked == false)
        //        chckDirectivo.Checked = false;

        //}

        //protected void chckDocente_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chckDocente.Checked == false)
        //        chckDirectivo.Checked = false;

        //}

        protected void ddlUltGrado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlUltGrado.DataBind();
        }


        protected void ddlPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LLenarDDLGruposAsignacion(Convert.ToInt32(ddlPeriodo.SelectedValue));
        }

        protected void ddlGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LLenarDDLMateriasAsignacion(Convert.ToInt32(ddlGrupo.SelectedValue));
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            datoMaestroGrupo.IDMaestro = Convert.ToInt32(Session["EmpModif"]);
            datoMaestroGrupo.IDGrupo = Convert.ToInt32(ddlGrupo.SelectedValue);
            datoMaestroGrupo.IDPeriodo = Convert.ToInt32(ddlPeriodo.SelectedValue);
            datoMaestroGrupo.IDAsignatura = Convert.ToInt32(ddlMateria.SelectedValue);
            ejecMaestrosGrupos.agregarMaestroGrupo(datoMaestroGrupo);
            LlenarGVAsignaciones();
        }

        protected void ActualizarUPDatos()
        {
            upDatosGen.Update();
            //upDatosTut.Update();
            upDatosDir.Update();
            //upDatosEscPro.Update();
            //upDatosDocs.Update();
            upBotones.Update();
        }

        protected void gvAsignaciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAsignaciones.PageIndex = e.NewPageIndex;
            LlenarGVAsignaciones();

        }
    }
}