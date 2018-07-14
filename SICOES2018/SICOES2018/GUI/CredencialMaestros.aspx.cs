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
    public partial class CredencialMaestros : System.Web.UI.Page
    {
        
        MaestrosBO datoCred = new MaestrosBO();
        MaestrosDAO ejecCred = new MaestrosDAO();
        
        List<string> SeleccionadosNombre = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                LlenarGridViewDocentes(1);
                ListaMaestros.DataBind();
                Session.Remove("SeleccionadosId");
                Session.Remove("FotoPerfil");
            }
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
                   }

        protected void LlenarGridViewDocentes(int Status)
        {
            gvAsignaturas.DataSource = ejecCred.LlenarGridView(Status);
            gvAsignaturas.DataBind();
        }

        protected void btnElimAsig_Click(object sender, EventArgs e)

        {

            if (Session["SeleccionadosId"] != null)
            {
                if (Session["FotoPerfil"] == null)
                    Session["FotoPerfil"] = new List<string>();
                datoCred.IDMaestro = 14;
                List<string> FotoPerfil = (List<string>)Session["FotoPerfil"];
                FotoPerfil.Add(Server.MapPath(ejecCred.buscarDatoAlumno("FotoMaestro", datoCred)));
                datoCred.IDMaestro = 15;
                FotoPerfil.Add(Server.MapPath(ejecCred.buscarDatoAlumno("FotoMaestro", datoCred)));
                Session["FotoPerfil"] = FotoPerfil;

                string[] Fotos = FotoPerfil.ToArray();
                string Fconvertida = String.Join(", ", Fotos);

                Session["Fparametro"] = (Fconvertida);

                Response.Redirect("../Reports/CredencialMaestros.aspx");
            }
        }

        protected void gvAsignaturas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAsignaturas.PageIndex = e.NewPageIndex;
            LlenarGridViewDocentes(1);

        }

        protected void gvAsignaturas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            string currentCommand = e.CommandName;
            if (currentCommand == "SelectAlum")
            {
                int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
                Session["AsigModif"] = Convert.ToInt32(gvAsignaturas.DataKeys[currentRowIndex].Value);
                datoCred.IDMaestro = Convert.ToInt32(Session["AsigModif"]);

                if (Session["SeleccionadosId"] == null)
                    Session["SeleccionadosId"] = new List<string>();

                List<string> SeleccionadosId = (List<string>)Session["SeleccionadosId"];
                SeleccionadosId.Add(Convert.ToString(datoCred.IDMaestro));
                Session["SeleccionadosId"] = SeleccionadosId;
                string Nombre = ejecCred.buscarDatoCred("NomMaestro", datoCred)+ " " + (ejecCred.buscarDatoCred("ApePatMaestro", datoCred) + " " +(ejecCred.buscarDatoCred("ApeMatMaestro",datoCred)));
                SeleccionadosNombre.Add(Nombre);
                
                for (int i = 0; i < SeleccionadosNombre.Count; i++)
                {
                    ListaMaestros.Items.Add(SeleccionadosNombre.ElementAt(i));
                }

                

                string Lconvertida;
                string[] SQL = SeleccionadosId.ToArray();
                Lconvertida = String.Join(", ", SQL);
                
                Session["Lparametro"] = (Lconvertida);
                lista.Text = Convert.ToString(Session["Lparametro"]);
                ListaMaestros.DataBind();
            }




        }
    }
}