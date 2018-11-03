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

        //metodo para vereficar usuario en la BD
        public int Vereficar_Boton_Usuario(String rut_login, String usuario, String nboton)
        {
            int retorno = 0;
            try
            {
                String sql = "SELECT per_usuario, per_boton FROM permisos_web WHERE rut_login='" + rut_login + "' AND per_usuario='" + usuario + "' AND per_boton='" + nboton + "' ";
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
                if (contador > 0 || usuario == "ADMIN")
                    retorno = 1;
            }
            catch (Exception e)
            {
                //Console.Write("Error" + e.ToString());
            }
            return retorno;
        }
 

        public void Agregar_Boton(String rut_login, String usuario, String nboton)
        {
            try
            {
                String sql = "INSERT permisos_web SET rut_login='" + rut_login + "',per_usuario='" + usuario + "',per_boton='" + nboton + "',per_vb=0";
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

        public DataTable Consultar_Permiso_Boton(String rut_login, String usuario, String nboton)
        {
            DataTable tabla = new DataTable();
            try
            {

                String sql = "SELECT per_vb FROM permisos_web " + "WHERE rut_login='" + rut_login + "' AND per_usuario='" + usuario + "' AND per_boton='" + nboton + "'";
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

        public DataTable Listado_Permisos_Botones_Usuarios(String rut_login, String usuario)
        {
            DataTable tabla = new DataTable();
            try
            {
                if (usuario == "")
                {
                    String sql = "SELECT per_usuario,per_boton, per_vb FROM permisos_web WHERE rut_login='" + rut_login + "' AND us_username <> 'admin' ORDER BY 1 ASC";
                    conexion.conectar();
                    MySqlDataAdapter datos = new MySqlDataAdapter(sql, conexion.con);
                    conexion.cerrar();
                    datos.Fill(tabla);
                }
                else
                {
                    String sql = "SELECT per_usuario, per_boton, per_vb FROM permisos_web WHERE rut_login='" + rut_login + "' AND per_usuario='" + usuario + "' AND us_username <> 'admin' ORDER BY 2 ASC";
                    conexion.conectar();
                    MySqlDataAdapter datos = new MySqlDataAdapter(sql, conexion.con);
                    conexion.cerrar();
                    datos.Fill(tabla);
                }
            }
            catch (Exception error)
            {
                //MessageBox.Show(error.ToString());
            }
            return tabla;
        }

        public void Actualizar_Permiso_Boton(String rut_login, String usuario, String nboton, String vb)
        {
            try
            {
                String sql = "UPDATE permisos_web SET per_vb=" + vb + "  WHERE rut_login='" + rut_login + "' AND per_usuario='" + usuario + "' AND per_boton='" + nboton + "'";
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


        public DataTable Lista_Botones_Filtrado_Usuarios(String rut_login, String usuario, String nboton)
        {
            DataTable tabla = new DataTable();
            try
            {

                String sql = "SELECT per_usuario, per_boton, per_vb FROM permisos_web WHERE rut_login='" + rut_login + "' AND per_usuario='" + usuario + "' AND per_boton LIKE '" + nboton + "%' ORDER BY 1 ASC";
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