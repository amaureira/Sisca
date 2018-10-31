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
    public partial class InicioSesion : System.Web.UI.Page
    {
        //Instanciar clases
        Clase_InicioSesion inicioSesion = new Clase_InicioSesion();
        Clase_Conexion conexion = new Clase_Conexion();
        Clase_Varios varios = new Clase_Varios();
        //Variables publicas
        public string datousuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            //DataTable tablatmp = new DataTable();
            //tablatmp = inicioSesion.Usuario_Empresa("%");

            Session.Add("ssAdmin", "ADMIN");
            Session.Add("ssPassAdmin", "A122");
            if (!Page.IsPostBack)
            {
                TxtUsuario.Text = (string)(Session["ssusuario"]);
                TxtUsuario.Focus();
                Session.Remove("valor");
            }
        }

        protected void TxtUsuario_TextChanged(object sender, EventArgs e)
        {
            if (TxtUsuario.Text == String.Empty)
            {
                string script = @"<script type='text/javascript'>
                                alert('Campos vacíos...!!');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                //MessageBox.Show("Campos Vacíos...!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TxtPass.Text = ""; TxtPass.Enabled = false;
            }
            else
            {
                TxtUsuario.Text = varios.formatearRutcP(TxtUsuario.Text);
                TxtPass.Enabled = true; TxtPass.Focus();
            }
        }

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if ( TxtUsuario.Text == String.Empty || TxtPass.Text == String.Empty)
                {
                    string script = @"<script type='text/javascript'>
                                alert('Hay campos vacíos...!!');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    //MessageBox.Show("Campos Vacíos...!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtUsuario.Text = "";
                    TxtPass.Text = "";
                    TxtUsuario.Focus();
                }
                else
                {
                    //Verificar si existe o no el usuario en la BD al loguearse  --- DownListRut1.SelectedValue.ToString()
                    int valor = inicioSesion.vereficar_usuario( TxtUsuario.Text, TxtPass.Text);
                    Session.Add("valor", valor);
                    if (TxtUsuario.Text == (string)(Session["ssAdmin"]) && TxtPass.Text == (string)(Session["ssPassAdmin"]))
                    {
                        valor = 1;
                        Session.Add("valor", valor);
                    }
                    if (valor == 0)
                    {
                        string script = @"<script type='text/javascript'>
                                alert('Datos Erroneos...!!');</script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        //MessageBox.Show("Datos Erroneos, verificar por favor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TxtUsuario.Focus();
                    }
                    else
                    {
                        Session.Add("ssusuario", TxtUsuario.Text);
                        Response.Redirect("~/MInterfaz/Menu_Principal.aspx");
                    }
                }
            }
            catch (Exception error)
            {
                //MessageBox.Show("Error..!!!");
                //MessageBox.Show(error.ToString());
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }
    }
}