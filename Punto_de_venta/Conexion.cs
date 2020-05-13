using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Punto_de_venta
{
    class Conexion
    {
        private MySqlConnection connection;
        private string Hostname;
        private string database;
        private string user;
        private string password;

        public Conexion()
        {
            iniciar();
        }
        private void iniciar()
        {
            try
            {
                Hostname = "sql3.freesqldatabase.com";
                database = "sql3339480";
                user = "sql3339480";
                password = "rpSgcK6fmM";
                string connectionString;
                connectionString = "SERVER=" + Hostname + ";" + "DATABASE=" +
                database + ";" + "UID=" + user + ";" + "PASSWORD=" + password + ";";
                connection = new MySqlConnection(connectionString);

            }
            catch (Exception e)
            {
                Console.WriteLine("No se conecto: " + e.Message);
            }
        }
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                Console.WriteLine("Se conecto");
                
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine( ex.Number);
               
                return false;
            }
        }


        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

    }
}
