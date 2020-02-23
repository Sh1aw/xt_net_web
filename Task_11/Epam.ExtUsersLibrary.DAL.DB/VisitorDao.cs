using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.ExtUsersLibrary.Dao.Interfaces;
using Epam.ExtUsersLibrary.Entities;

namespace Epam.ExtUsersLibrary.DAL.DB
{
    public class VisitorDao : IVisitorDao
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;
        public Visitor Add(Visitor visitor)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddVisitor";
                var loginParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Login",
                    Value = visitor.Login,
                    Direction = ParameterDirection.Input,
                };
                command.Parameters.Add(loginParameter);

                var passwordParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Password",
                    Value = visitor.Password,
                    Direction = ParameterDirection.Input,
                };
                command.Parameters.Add(passwordParameter);

                var idRoleParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@RoleId",
                    Value = visitor.IdRole,
                    Direction = ParameterDirection.Input,
                };
                command.Parameters.Add(idRoleParameter);

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Direction = ParameterDirection.Output,
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                    visitor.Id = (int) idParameter.Value;
                }
                catch (SqlException e)
                {
                    visitor = null;
                }
                finally
                {
                    connection.Close();
                }
            }
            return visitor;
        }

        public void DepriveRole(int id, int idRole)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Visitor> GetAll()
        {
            var visitors = new Dictionary<int, Visitor>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllVisitors";
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var visitor = new Visitor(reader["login"] as string,reader["password"] as string, reader["id_role"] as int?);
                        visitor.Id = (int)reader["id"];
                        visitors.Add(visitor.Id,visitor);
                    }

                }
            }

            return visitors.Values;
        }

        public Visitor GetById(int id)
        {
            Visitor visitor = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetVisitorById";
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
                        visitor = new Visitor(reader["login"] as string, reader["password"] as string, reader["id_role"] as int?);
                        visitor.Id = (int)reader["id"];
                    }

                }
            }
            return visitor;
        }

        public Visitor GetByLogin(string login)
        {
            if (login == null)
            {
                return null;
            }
            Visitor visitor = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetVisitorByLogin";
                var loginParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Login",
                    Value = login,
                    Direction = ParameterDirection.Input,
                };
                command.Parameters.Add(loginParameter);
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        visitor = new Visitor(reader["login"] as string,reader["password"] as string, reader["id_role"] as int?);
                        visitor.Id = (int)reader["id"];
                    }

                }
            }
            return visitor;
        }

        public int GiveRole(int id, int idRole)
        {
            int idRoleO = idRole;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GiveVisitorRole";
                var UserIdParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@VisitorId",
                    Value = id,
                    Direction = ParameterDirection.Input,
                };
                command.Parameters.Add(UserIdParameter);

                var RoleIdParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@RoleId",
                    Value = idRole,
                    Direction = ParameterDirection.InputOutput,
                };
                command.Parameters.Add(RoleIdParameter);
                connection.Open();
                command.ExecuteNonQuery();
                idRoleO = (int)RoleIdParameter.Value;
            }

            return idRoleO;
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
