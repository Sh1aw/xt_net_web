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
    public class UserDao : IUserDao
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;
        public User Add(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddUser";
                var nameParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Name",
                    Value = user.Name,
                    Direction = ParameterDirection.Input,
                };
                command.Parameters.Add(nameParameter);

                var dobParameter = new SqlParameter()
                {
                    DbType = DbType.DateTime,
                    ParameterName = "@Dob",
                    Value = user.DateOfBirth,
                    Direction = ParameterDirection.Input,
                };
                command.Parameters.Add(dobParameter);

                var imgParameter = new SqlParameter()
                {
                    DbType = DbType.Binary,
                    ParameterName = "@Img",
                    Value = user.ImageBytes,
                    Direction = ParameterDirection.Input,
                };
                command.Parameters.Add(imgParameter);

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Direction = ParameterDirection.Output,
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                command.ExecuteNonQuery();
                user.Id = (int)idParameter.Value;
            }
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            var users = new Dictionary<int, User>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllUsers";
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var user = new User(reader["name"] as string, (DateTime)reader["dob"], reader["image"] as byte[]);
                        user.Id = (int)reader["id"];
                        users.Add(user.Id, user);
                    }

                }
            }
            return users.Values;
        }

        public User GetById(int id)
        {
            User user = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetUserById";
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
                        user = new User(reader["name"] as string, (DateTime)reader["dob"], reader["image"] as byte[]);
                        user.Id = (int)reader["id"];
                    }

                }
            }
            return user;
        }

        public int Remove(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.RemoveUserById";
                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = id,
                    Direction = ParameterDirection.Input,
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                command.ExecuteNonQuery();
            }
            return id;
        }

        public User Update(int userId, string name, DateTime dob, byte[] imgBytes)
        {
            var user = new User(name,dob,imgBytes);
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.UpdateUser";
                var nameParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Name",
                    Value = name,
                    Direction = ParameterDirection.Input,
                };
                command.Parameters.Add(nameParameter);

                var dobParameter = new SqlParameter()
                {
                    DbType = DbType.DateTime,
                    ParameterName = "@Dob",
                    Value = dob,
                    Direction = ParameterDirection.Input,
                };
                command.Parameters.Add(dobParameter);

                var imgParameter = new SqlParameter()
                {
                    DbType = DbType.Binary,
                    ParameterName = "@Img",
                    Value = imgBytes,
                    Direction = ParameterDirection.Input,
                };
                command.Parameters.Add(imgParameter);

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = userId,
                    Direction = ParameterDirection.Input,
                };
                command.Parameters.Add(idParameter);

                connection.Open();
                command.ExecuteNonQuery();
                user.Id = (int)idParameter.Value;
            }
            return user;
        }
    }
}
