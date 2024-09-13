using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CRUD_CSharp_MySQL.Config;
using CRUD_CSharp_MySQL.Models;

using MySql.Data.MySqlClient;

namespace CRUD_CSharp_MySQL.DAL
{
    internal class EstudianteDAL
    {
        private ConexionDB con = new ConexionDB();

        public void AgregarEstudiante(Estudiante estudiante)
        {
            string query = "" +
                "INSERT INTO Estudiante (Nombre, Apellido, Email, FechaNacimiento)" +
                "VALUES ('" + estudiante.Nombre +"', '" + estudiante.Apellido + "', '" + estudiante.Email + "', '" + estudiante.FechaNacimiento.ToString("yyyy-MM-dd") + "')";
            con.EjecutarComando(query);
        }

        public void ActualizarEstudiante(Estudiante estudiante)
        {
            string query = "" +
                "UPDATE Estudiante " +
                "SET Nombre = '" + estudiante.Nombre + "', Apellido = '" + estudiante.Apellido + "', Email = '" + estudiante.Email + "', FechaNacimiento = '" + estudiante.FechaNacimiento.ToString("yyyy-MM-dd") + "' " +
                "WHERE EstudianteID = " + estudiante.EstudianteID;
            con.EjecutarComando(query);
        }

        public void EliminarEstudiante(int estudianteID)
        {
            string query = "" +
                "DELETE FROM Estudiante " +
                "WHERE EstudianteID = " + estudianteID;
            con.EjecutarComando(query);
        }

        public List<Estudiante> ObtenerEstudiantes()
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            string query = "" +
                "SELECT * " +
                "FROM Estudiante";
            MySqlDataReader reader = con.EjecutarQuery(query);

            while (reader.Read())
            {
                Estudiante estudiante = new Estudiante
                {
                    EstudianteID = int.Parse(reader["EstudianteID"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    Apellido = reader["Apellido"].ToString(),
                    Email = reader["Email"].ToString(),
                    FechaNacimiento = DateTime.Parse(reader["FechaNacimiento"].ToString())
                };
                estudiantes.Add(estudiante);
            }
            reader.Close();
            con.CerrarConexion();
            return estudiantes;
        }
    }
}
