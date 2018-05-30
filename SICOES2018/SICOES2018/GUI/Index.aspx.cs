using SICOES2018.BO;
using SICOES2018.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SICOES2018.GUI
{
    public partial class LoginGUI : System.Web.UI.Page
    {
        AlumnosBO datoAlum = new AlumnosBO();
        AlumnosDAO ejeAlum = new AlumnosDAO();
        MaestrosBO datoMaestro = new MaestrosBO();
        MaestrosDAO ejeMaestro = new MaestrosDAO();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtuser.Text != string.Empty && txtpass.Text != string.Empty)
            {
                datoAlum.UsuarioAlumno = datoAlum.EncriptarMD5(txtuser.Text);
                datoAlum.ContrasenhaAlumno = datoAlum.EncriptarMD5(txtpass.Text);
                int verifalum = Convert.ToInt32(ejeAlum.loginAlumno(datoAlum));
                if (verifalum > 0)
                {
                    Session["IDUserLoged"] = ejeAlum.ObtenerIDLogin(datoAlum);
                    datoAlum.IDAlumno = Convert.ToInt32(Session["IDUserLoged"]);
                    Response.Redirect("~/GUI/Inicio");
                }
                else
                {
                    datoMaestro.UsuarioMaestro = datoMaestro.EncriptarMD5(txtuser.Text);
                    datoMaestro.ContrasenhaMaestro = datoMaestro.EncriptarMD5(txtpass.Text);
                    int verifmaestro = Convert.ToInt32(ejeMaestro.loginMaestro(datoMaestro));
                    if (verifmaestro > 0)
                    {
                        Session["IDUserLoged"] = ejeMaestro.ObtenerIDLogin(datoMaestro);
                        datoMaestro.IDMaestro = Convert.ToInt32(Session["IDUserLoged"]);
                        
                        Response.Redirect("~/GUI/Inicio");
                    }
                }
                txtuser.Text = string.Empty;
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert();", true);
            }
        }
    }
}