using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using SICOES2018.BO;
using SICOES2018.DAO;
using System.Web.UI.WebControls;

namespace SICOES2018.GUI
{
    public partial class CredencialAlumnos : System.Web.UI.Page
    {
        AlumnosBO datoCred = new AlumnosBO();
        AlumnosDAO ejecCred = new AlumnosDAO();
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

        protected void LlenarGridViewDocentes(int Status)
        {
            gvAlumnos.DataSource = ejecCred.LlenarGridView(Status);
            gvAlumnos.DataBind();
        }

        protected void btnElimAsig_Click(object sender, EventArgs e)

        {

            if (Session["SeleccionadosId"] != null)
            {
                if (Session["FotoPerfil"] == null)
                    Session["FotoPerfil"] = new List<string>();
                //datoCred.IDAlumno = 14;
                List<string> FotoPerfil = (List<string>)Session["FotoPerfil"];
                //FotoPerfil.Add(Server.MapPath(ejecCred.buscarDatoAlumno("FotoMaestro", datoCred)));
               // datoCred.IDAlumno = 15;
                //FotoPerfil.Add(Server.MapPath(ejecCred.buscarDatoAlumno("FotoMaestro", datoCred)));
                Session["FotoPerfil"] = FotoPerfil;

                //string[] Fotos = FotoPerfil.ToArray();
                //string Fconvertida = String.Join(", ", Fotos);

                //Session["Fparametro"] = (Fconvertida);

                Response.Redirect("../Reports/CredencialAlumnos.aspx");
            }
        }

        protected void gvAlumnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAlumnos.PageIndex = e.NewPageIndex;
            LlenarGridViewDocentes(1);

        }

        protected void gvAlumnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string currentCommand = e.CommandName;
            if (currentCommand == "SelectAlum")
            {
                int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
                Session["AsigModif"] = Convert.ToInt32(gvAlumnos.DataKeys[currentRowIndex].Value);
                datoCred.IDAlumno = Convert.ToInt32(Session["AsigModif"]);

                if (Session["SeleccionadosId"] == null)
                    Session["SeleccionadosId"] = new List<string>();

                List<string> SeleccionadosId = (List<string>)Session["SeleccionadosId"];
                SeleccionadosId.Add(Convert.ToString(datoCred.IDAlumno));
                Session["SeleccionadosId"] = SeleccionadosId;
                string Nombre = ejecCred.buscarDatoCred("NomAlumno", datoCred) + " " + (ejecCred.buscarDatoCred("ApePatAlumno", datoCred) + " " + (ejecCred.buscarDatoCred("ApeMatAlumno", datoCred)));
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