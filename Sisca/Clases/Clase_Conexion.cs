using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Sisca
{
    public class Clase_Conexion
    {
        //
        public MySqlConnection con;
        public void conectar()
        {
            //con = new MySqlConnection("server=190.54.104.172;user id=sisca;password=Csac2018;database=sisca;port=3306");
            con = new MySqlConnection("server=localhost;user id=sisca;password=Csac2018;database=sisca;port=3306");
            con.Open();
        }
        //metodo para cerrar
        public void cerrar()
        {
            con.Close();
        }
    }
}