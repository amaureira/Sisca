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
    public class Clase_Varios
    {
        //instancia clase conexion
        Clase_Conexion conexion = new Clase_Conexion();


        public string formatearRutsP(string rut)
        {
            int cont = 0;
            string format;
            if (rut.Length == 0)
            {
                return "";
            }
            else
            {
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                format = "-" + rut.Substring(rut.Length - 1);
                for (int i = rut.Length - 2; i >= 0; i--)
                {
                    format = rut.Substring(i, 1) + format;
                    cont++;
                    if (cont == 3 && i != 0)
                    {
                        // format = "." + format;
                        cont = 0;
                    }
                }
                return format;
            }
        }

        public string formatearRutcP(string rut)
        {
            int cont = 0;
            string format;
            if (rut.Length == 0)
            {
                return "";
            }
            else
            {
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                format = "-" + rut.Substring(rut.Length - 1);
                for (int i = rut.Length - 2; i >= 0; i--)
                {
                    format = rut.Substring(i, 1) + format;
                    cont++;
                    if (cont == 3 && i != 0)
                    {
                        format = "." + format;
                        cont = 0;
                    }
                }
                return format;
            }
        }

        //metodo para extraer nombre  usuario en la BD
        public string NombreUsuario(String rut_login)
        {

            DataTable tabla = new DataTable();

            string vb = null;
            try
            {
                String sql = "SELECT Nombres FROM vtusuarios WHERE rutDV='" + rut_login + "' ";
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

    }
}