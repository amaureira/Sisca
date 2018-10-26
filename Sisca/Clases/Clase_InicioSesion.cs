using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
using System.Windows.Forms;
using Sisca.Clases;

namespace Sisca.Clases
{
    public class Clase_InicioSesion
    {
        public string rut;
        public string pass;

        //instancia clase conexion
        Clase_Conexion conexion = new Clase_Conexion();

        //metodo para vereficar usuario en la BD
        public int vereficar_usuario(String rutemp, String user, String password)
        {
            int retorno = 0;
            try
            {
                String sql = "SELECT EmpRut, CodUser , Pass FROM usuarios_acceso WHERE empRut='" + rutemp + "' AND CodUser='" + user + "' AND Pass='" + password + "' ";
                //transformar datos a una tabla
                DataTable tablaLog = new DataTable();
                conexion.conectar();
                //ejecutar consulta sql
                MySqlDataAdapter datos = new MySqlDataAdapter(sql, conexion.con);
                conexion.cerrar();
                //enviar los datos a la tabla
                datos.Fill(tablaLog);
                //contar cantidad de filas de la tabla
                int contador = tablaLog.Rows.Count;
                //preguntar por la cantidad de filas
                if (contador > 0)
                    retorno = 1;

            }
            catch (Exception e)
            {
                Console.Write("Error" + e.ToString());
            }
            return retorno;
        }



        //metodo para mostrar persona en el formulario principal
        public DataTable mostrar_DatoUsuario(String user)
        {
            DataTable tabla = new DataTable();
            try
            {
                String sql = "SELECT EmpRut.rut AS Rut , NomEmpr AS Nombre FROM Usuarios_acceso WHERE CodUser='" + user + "'";
                conexion.conectar();
                MySqlDataAdapter datos = new MySqlDataAdapter(sql, conexion.con);
                conexion.cerrar();
                datos.Fill(tabla);
            }
            catch (Exception e)
            {
                //MessageBox.Show(error.ToString());
            }
            return tabla;


        }
    }
}