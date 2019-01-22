using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sisca.Clases;

namespace Sisca.MConfiguracion
{
    public partial class MenuConfiguracion : System.Web.UI.MasterPage
    {
        //Instanciar clases
        // Clase_InicioSesion inicioSesion = new Clase_InicioSesion();
        Clase_Conexion conexion = new Clase_Conexion();
        Clase_Permisos permisos = new Clase_Permisos();
        Clase_Varios varios = new Clase_Varios();
        //Variables publicas
        public string rutusuariocp, rutusuariosp, nombreusuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["valor"] == null)
                { Response.Redirect("~/InicioSesion.aspx"); }
            rutusuariosp = (string)(Session["ssRutUsuariosp"]);
            // LblRut.Text = (string)(Session["ssRutUsuariocp"]);
            // LblNombre.Text = (string)(Session["ssNombreUsuario"]);

            if (!Page.IsPostBack)
            {
                string mesn = (string)(Session["ssmes"]);
                string periodon = (string)(Session["ssperiodo"]);
                //DropDownListaMes.SelectedValue = mesn;
                // DropDownListaPeriodo.SelectedValue = periodon;
                String rutpro = obtieneultRut(rut_login);
                cargaProveedor(rutpro);
            }

        }

        protected void Btn01_Click(object sender, EventArgs e)
        {
            // string valor = permisos.Permiso_Boton(rutusuariosp, LinkBtnCFG.Text);
            if (!string.IsNullOrEmpty(permisos.Permiso_Boton(rutusuariosp, Btn01.Text)))
            {
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", valor, false);
                return;
            }
            else
            { Response.Redirect("~/MConfiguracion/Usuario.aspx", false); }

        }

        protected void Btn02_Click(object sender, EventArgs e)
        {

        }

        protected void Btn03_Click(object sender, EventArgs e)
        {

        }

        protected void Btn04_Click(object sender, EventArgs e)
        {

        }

        protected void Btn05_Click(object sender, EventArgs e)
        {

        }
    }
}