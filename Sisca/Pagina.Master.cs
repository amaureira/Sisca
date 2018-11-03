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
        Clase_InicioSesion inicioSesion = new Clase_InicioSesion();
        Clase_Conexion conexion = new Clase_Conexion();
        Clase_Varios varios = new Clase_Varios();
        //Variables publicas
        public string rutusuario, nombreusuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            rutusuario= (string)(Session["ssRutUsuario"]);
            LblRut.Text = rutusuario;

            nombreusuario = (string)(Session["ssNombreUsuario"]);
            LblNombre.Text = nombreusuario;
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

        }


    }
}