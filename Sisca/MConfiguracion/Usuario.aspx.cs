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
            cargaddlist();
            if (!Page.IsPostBack)
            {
                string mesn = (string)(Session["ssmes"]);
                string periodon = (string)(Session["ssperiodo"]);
                // DropDownListaMes.SelectedValue = mesn;
                // DropDownListaPeriodo.SelectedValue = periodon;
                String rutUsuario = obtieneultRut();
                cargaUsuario(rutUsuario);


            }
        }

        protected void cargaddlist()
        {
            DDListCargo.DataSource = cargaCargos();
            DDListCargo.DataTextField = "DesProf";
            DDListCargo.DataValueField = "CodProf";
            DDListCargo.DataBind();
            DDListCargo.Items.Insert(0, new ListItem("Seleccione Cargo...", "0"));
            return;
        }

        protected void IBtnEdicion_Click(object sender, ImageClickEventArgs e)
        {
            cambiaestadoTB(true);
            cambiaestadoBoton(false, true);
        }

        protected void IBtnNuevo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void IBtnBuscar_Click(object sender, ImageClickEventArgs e)
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
            String rut = obtienePriRut();
            cargaUsuario(rut);
        }

        protected void IBtnAnterior_Click(object sender, ImageClickEventArgs e)
        {
            if (TBRut.Text != obtienePriRut())
            {
                String rut = obtieneAntRut(TBRut.Text);
                cargaUsuario(rut);
            }
        }

        protected void IBtnsiguiente_Click(object sender, ImageClickEventArgs e)
        {
            {
                if (TBRut.Text != obtieneultRut())
                {
                    String rut = obtieneSigRut(TBRut.Text);
                    cargaUsuario(rut);
                }
            }
        }

        protected void IBtnUltimo_Click(object sender, ImageClickEventArgs e)
        {
            String rut = obtieneultRut();
            cargaUsuario(rut);
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


        protected void cambiaestadoTB(Boolean estado)
        {
            TBNombre.Enabled = estado;
            TBApePater.Enabled = estado;
            TBApeMater.Enabled = estado;
            DDListCargo.Enabled = estado;
            TBEMail.Enabled = estado;
            TBObs.Enabled = estado;
        }

        protected void cambiaestadoBoton(Boolean estado, Boolean estado2)
        {
            IBtnEdicion.Enabled = estado;
            IBtnNuevo.Enabled = estado;
            IBtnElimina.Enabled = estado2;
            IBtnBuscar.Enabled = estado;
            IBtnGrabar.Enabled = estado2;
            IBtnSinGrabar.Enabled = estado2;
            IBtnPrimero.Enabled = estado;
            IBtnAnterior.Enabled = estado;
            IBtnsiguiente.Enabled = estado;
            IBtnUltimo.Enabled = estado;
        }


        protected void cargaUsuario(string rut)
        {
            TBRut.Text = rut;
            TBDVRut.Text = obtienevalor("dv", rut);
            TBNombre.Text = obtienevalor("nombre", rut);
            TBApePater.Text = obtienevalor("apellidopaterno", rut);
            TBApeMater.Text = obtienevalor("apellidomaterno", rut);
            DDListCargo.SelectedValue = obtienevalor("CodProf", rut);
            TBEMail.Text = obtienevalor("correo", rut);
            return;
        }

        protected string obtienePriRut()
        {
            string vb = "";
            DataTable tabla = new DataTable();
            String sql = "SELECT Rut FROM tbusuarios ORDER BY rut ASC LIMIT 1;";
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

        protected string obtieneSigRut(string rut)
        {
            string vb = "";
            DataTable tabla = new DataTable();
            String sql = "SELECT Rut FROM tbusuarios WHERE rut>" + rut + " ORDER BY rut ASC LIMIT 1;";
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

        protected string obtieneAntRut(string rut)
        {
            string vb = "";
            DataTable tabla = new DataTable();
            String sql = "SELECT Rut FROM tbusuarios WHERE rut<" + rut + " ORDER BY rut DESC LIMIT 1;";
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

        protected string obtieneultRut()
        {
            string vb = "";
            DataTable tabla = new DataTable();
            String sql = "SELECT Rut FROM tbusuarios ORDER BY rut DESC LIMIT 1;";
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

        protected DataTable cargaCargos()
        {
            string vb = "";
            DataTable tabla = new DataTable();
            String sql = "SELECT CodProf, DesProf FROM tbprofesion ";
            conexion.conectar();
            MySqlDataAdapter datos = new MySqlDataAdapter(sql, conexion.con);
            conexion.cerrar();
            datos.Fill(tabla);
            return tabla;
        }

    }
}