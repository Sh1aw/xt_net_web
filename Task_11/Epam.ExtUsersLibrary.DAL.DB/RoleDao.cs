using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Epam.ExtUsersLibrary.Dao.Interfaces;
using System.Text;
using System.Threading.Tasks;
using Epam.ExtUsersLibrary.Entities;

namespace Epam.ExtUsersLibrary.DAL.DB
{
    public class RoleDao : IRoleDao
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;
        public Role AddRole()
        {
            throw new NotImplementedException();
        }

        public Role GetRoleById(int id)
        {
            Role role = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetRoleById";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = id,
                    Direction = ParameterDirection.Input,
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        role = new Role(reader["name"] as string);
                        role.Id = (int)reader["id"];
                    }

                }
            }
            return role;
        }
    }
}
