using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace Sisca.Clases
{
    public class Clase_Permisos
    {
        //Instancia de clases
        Clase_Conexion conexion = new Clase_Conexion();
        public Boolean ValidaAdmin (String rut)
        {
            bool estado = false;
            try
            {
                String sql;
                sql = "SELECT rutdv FROM vtusuarios_acceso WHERE rutdv='" + rut + "' AND admin= 1 ";
                //transformar datos a una tabla
                DataTable tabla = new DataTable();
                conexion.conectar();
                //ejecutar consulta sql
                MySqlDataAdapter datos = new MySqlDataAdapter(sql, conexion.con);
                conexion.cerrar();
                //enviar los datos a la tabla
                datos.Fill(tabla);
                //contar cantidad de filas de la tabla
                int contador = tabla.Rows.Count;
                //preguntar por la cantidad de filas
                if (contador > 0 )
                    { estado = true; }
            }
            catch (Exception e)
            {
                //Console.Write("Error" + e.ToString());
            }
            return estado;
        }

        public string Permiso_Boton(String rut_login, String nboton)
        {
            string vb, script="";
            bool Admin = false;
            Admin = ValidaAdmin(rut_login);
            int valor = Vereficar_Boton_Usuario(rut_login, nboton);
            if (valor == 0)
            {
                Agregar_Boton(rut_login, nboton);
                if (Admin)
                {
                    Actualizar_Permiso_Boton(rut_login, nboton, "1");
                }
                else
                {
                    script = @"<script type='text/javascript'> alert('\Estimado usuario,\n no tiene acceso al boton " + nboton + ",\\n favor contactarse con el administrador para su habilitacion...!!\');</script>";
                }
            }
            else
            {
                vb = Consultar_Permiso_Boton(rut_login, nboton);
                if (string.IsNullOrEmpty(vb))
                    { script = @"<script type='text/javascript'> alert('\Estimado usuario,\n no tiene acceso al boton " + nboton + ",\\n favor contactarse con el administrador para su habilitacion...!!\');</script>"; }
                else
                    { script = ""; }
            }
            return script;
        }

        //metodo para vereficar usuario en la BD
        public int Vereficar_Boton_Usuario(String rut_login,  String nboton)
        {
            int retorno = 0;
            bool Admin = false;
            try
            {
                Admin = ValidaAdmin(rut_login);
                String sql;
                if (Admin)
                    { sql = "SELECT rutdv, per_boton from tbpermisos"; }
                else
                    { sql = "SELECT rutdv, per_boton FROM permisos_web WHERE rutdv='" + rut_login + "' AND per_boton='" + nboton + "' "; }
                //transformar datos a una tabla
                DataTable tabla = new DataTable();
                conexion.conectar();
                //ejecutar consulta sql
                MySqlDataAdapter datos = new MySqlDataAdapter(sql, conexion.con);
                conexion.cerrar();
                //enviar los datos a la tabla
                datos.Fill(tabla);
                //contar cantidad de filas de la tabla
                int contador = tabla.Rows.Count;
                //preguntar por la cantidad de filas
                if (contador > 0 || Admin)
                    { retorno = 1; }
            }
            catch (Exception e)
            {
                //Console.Write("Error" + e.ToString());
            }
            return retorno;
        }

        public void Agregar_Boton(String rut_login, String nboton)
        {
            try
            {
                String sql = "INSERT permisos_web SET rutdv='" + rut_login + "',per_boton='" + nboton + "',per_vb=0";
                conexion.conectar();
                MySqlCommand datos = new MySqlCommand(sql, conexion.con);
                datos.ExecuteScalar();
                conexion.cerrar();
            }
            catch (Exception error)
            {
                //MessageBox.Show(error.ToString());
            }
        }

        public String Consultar_Permiso_Boton(String rut_login, String nboton)
        {
            DataTable tabla = new DataTable();
            bool Admin = false;
            string vb = null;
            String sql;
            try
            {
                Admin = ValidaAdmin(rut_login);
                if (Admin)
                    { sql = "SELECT per_vb from permisos_web"; }
                else
                    { sql = "SELECT per_vb FROM permisos_web " + "WHERE rutdv='" + rut_login + "' AND per_boton='" + nboton + "'"; }

                conexion.conectar();
                MySqlDataAdapter datos = new MySqlDataAdapter(sql, conexion.con);
                conexion.cerrar();
                datos.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    foreach (DataRow fila in tabla.Rows)
                    {
                        vb = fila[0].ToString();
                    }
                }
            }
            catch (Exception error)
            {
                //MessageBox.Show(error.ToString());
            }
            return vb;
        }

        public DataTable Listado_Permisos_Botones_Usuarios(String rut_login)
        {
            DataTable tabla = new DataTable();
            String sql;
            bool Admin = false;
            try
            {
                Admin = ValidaAdmin(rut_login);
                if (Admin)
                    { sql = "SELECT rutdv, per_boton, per_vb FROM permisos_web WHERE rutdv='" + rut_login + "'  ORDER BY 1 ASC"; }
                else
                    { sql = "SELECT rutdv, per_boton, per_vb FROM permisos_web WHERE rutdv='" + rut_login + "' ORDER BY 2 ASC"; }
                conexion.conectar();
                MySqlDataAdapter datos = new MySqlDataAdapter(sql, conexion.con);
                conexion.cerrar();
                datos.Fill(tabla);
            }
            catch (Exception error)
            {
                //MessageBox.Show(error.ToString());
            }
            return tabla;
        }

        public void Actualizar_Permiso_Boton(String rut_login, String nboton, String vb)
        {
            try
            {
                String sql = "UPDATE tbpermios SET per_vb=" + vb + "  WHERE rutdv='" + rut_login + "' AND per_boton='" + nboton + "'";
                conexion.conectar();
                MySqlCommand datos = new MySqlCommand(sql, conexion.con);
                datos.ExecuteScalar();
                conexion.cerrar();
            }
            catch (Exception error)
            {
                //MessageBox.Show(error.ToString());
            }
        }

        public DataTable Lista_Botones_Filtrado_Usuarios(String rut_login, String nboton)
        {
            DataTable tabla = new DataTable();
            try
            {
                String sql = "SELECT RutDV, Nombres, per_boton, per_vb FROM vtpermisos_usuarios WHERE RutDv='" + rut_login +  "' AND per_boton LIKE '" + nboton + "%' ORDER BY 1 ASC";
                conexion.conectar();
                MySqlDataAdapter datos = new MySqlDataAdapter(sql, conexion.con);
                conexion.cerrar();
                datos.Fill(tabla);
            }
            catch (Exception error)
            {
                //MessageBox.Show(error.ToString());
            }
            return tabla;
        }

    }
}