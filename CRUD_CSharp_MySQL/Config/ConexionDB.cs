using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace CRUD_CSharp_MySQL.Config
{
    public class ConexionDB
    {
        private MySqlConnection con { get; set; }

        public ConexionDB() 
        {
            string cadenaConexion = "Server=localhost;Port=3310;Uid=root;Pwd='';Database=colegiodb;";
            con = new MySqlConnection(cadenaConexion);
        }

        public void AbrirConexion() 
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            else
            { 
                MessageBox.Show("Error al abrir la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CerrarConexion()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            else 
            {
                MessageBox.Show("Error al cerrar la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int EjecutarComando(string query)
        {
            try
            {
                AbrirConexion();
                MySqlCommand cmd = new MySqlCommand(query, con);
                return cmd.ExecuteNonQuery();
            }
            finally
            {
                CerrarConexion();
            }
        }

        public MySqlDataReader EjecutarQuery(string query)
        {
            AbrirConexion();
            MySqlCommand cmd = new MySqlCommand(query, con);
            return cmd.ExecuteReader();
        }
    }
}
