using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using Sisca.Clases;

namespace Sisca
{
    public partial class Pagina : System.Web.UI.MasterPage
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
            rutusuariosp= (string)(Session["ssRutUsuariosp"]);
            LblRut.Text = (string)(Session["ssRutUsuariocp"]);
            LblNombre.Text = (string)(Session["ssNombreUsuario"]);
            //LblRut.Text = (string)(Session["ssRutUsuario"]);
            //LblNombre.Text = (string)(Session["ssNombreUsuario"]);
        }

        protected void LinkBtnPerfil_Click(object sender, EventArgs e)
        {

        }

        protected void LinkBtnAlmuerzos_Click(object sender, EventArgs e)
        {

        }

        protected void LinkBtnRegistro_Click(object sender, EventArgs e)
        {

        }

        protected void LinkBtnCFG_Click(object sender, EventArgs e)
        {
            // string valor = permisos.Permiso_Boton(rutusuariosp, LinkBtnCFG.Text);
            if (!string.IsNullOrEmpty(permisos.Permiso_Boton(rutusuariosp, LinkBtnCFG.Text)))
            {
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", valor, false);
                return;
            }
            else
            { Response.Redirect("~/MConfiguracion/Menu_Configuracion.aspx", false); }
        }


    }
}