using LabWebForms.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LabMVC.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        private static string ConnectionString = ConfigurationManager.ConnectionStrings["MinhaConexao"].ConnectionString;

        public override string ToString()
        {
            return this.Nome;
        }

        public static List<Usuario> Todos()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sql = "SELECT id, nome, uf FROM Usuarios";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuario usuario = new Usuario();
                            usuario.Id = reader.GetInt32(0);
                            usuario.Login = reader.GetString(50);
                            usuario.Senha = reader.GetString(50);
                            usuario.Nome = reader.GetString(50);
                            usuario.Email = reader.GetString(50);
                            /*  usuario.Add(usuario); */
                        }
                    }
                }
            }

            return usuarios;
        }
    }
}
