using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sisca.Clases;
using System.Data;
using MySql.Data.MySqlClient;

namespace Sisca.MConfiguracion
{
    public partial class Creacion_Usuario : System.Web.UI.Page
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

            if (!Page.IsPostBack)
            {
                string mesn = (string)(Session["ssmes"]);
                string periodon = (string)(Session["ssperiodo"]);
                //DropDownListaMes.SelectedValue = mesn;
                // DropDownListaPeriodo.SelectedValue = periodon;
                String rutpro = obtieneultRut(rut_login);
                //cargaProveedor(rutpro);


            }
        }

        protected void IBtnEdicion_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void IBtnNuevo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void IBtnBuscar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void IBtnImpresion_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void IBtnExcel_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void IBtnGrabar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void IBtnSinGrabar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void IBtnPrimero_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void IBtnAnterior_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void IBtnsiguiente_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void IBtnUltimo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void TBObs_TextChanged(object sender, EventArgs e)
        {

        }

        protected void RBtListTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void cargaUsuario(string rut)
        {
            TBRut.Text = rut;
            TBDVRut.Text = obtienevalor("dv", rut);
            TBNombre.Text = obtienevalor("nombre", rut);
            TBDirecion.Text = obtienevalor("direccion", rut);
            DDListRegion.SelectedValue = obtienevalor("region", rut);
            TBComuna.Text = obtienevalor("comuna", rut);
            TBCiudad.Text = obtienevalor("ciudad", rut);
            TBGiro.Text = obtienevalor("giro", rut);
            TBTelefono.Text = obtienevalor("telefonos", rut);
            TBFax.Text = obtienevalor("fax", rut);
            TBEMail.Text = obtienevalor("email", rut);
            TBContacto.Text = obtienevalor("contacto", rut);
            RBtListTipo.SelectedValue = obtienevalor("tipocompra", rut);

            return;
        }

        protected string obtienevalor(string campo, String Rut)
        {
            string vb = "";
            DataTable tabla = new DataTable();
            String sql = "SELECT " + campo + "  FROM tbusuarios WHERE Rut=" + Rut + " ; ";
            conexion.conectar();
            MySqlDataAdapter datos = new MySqlDataAdapter(sql, conexion.con);
            conexion.cerrar();
            datos.Fill(tabla);
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in tabla.Rows)
                { vb = fila[0].ToString(); }
            }
            return vb;
        }

    }
}