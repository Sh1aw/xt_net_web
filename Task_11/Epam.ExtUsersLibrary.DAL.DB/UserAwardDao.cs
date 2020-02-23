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
    public class UserAwardDao : IUserAwardDao
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

        public IEnumerable<UserAward> GetAll()
        {
            var UserAwards = new List<UserAward>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllUserAward";
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var userAward = new UserAward((int)reader["id_user"], (int)reader["id_award"]);
                        UserAwards.Add(userAward);
                    }

                }
            }

            return UserAwards;
        }

        public int GiveUserAward(int userId, int awardId)
        {
            int responceCode = 200;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GiveUserAward";
                var idUserParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@UserId",
                    Value = userId,
                    Direction = ParameterDirection.Input,
                };
                command.Parameters.Add(idUserParameter);
                var idAwardParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@AwardId",
                    Value = awardId,
                    Direction = ParameterDirection.Input,
                };
                command.Parameters.Add(idAwardParameter);
                connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    responceCode = 8;
                }
                finally
                {
                    connection.Close();
                }
            }
            return responceCode;
        }
        

        public int RemoveUserAward(int userId, int awardId)
        {
            int responceCode = 200;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.RemoveUserAward";
                var idUserParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@UserId",
                    Value = userId,
                    Direction = ParameterDirection.Input,
                };
                command.Parameters.Add(idUserParameter);
                var idAwardParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@AwardId",
                    Value = awardId,
                    Direction = ParameterDirection.Input,
                };
                command.Parameters.Add(idAwardParameter);
                connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    responceCode = 400;
                }
                finally
                {
                    connection.Close();
                }
            }
            return responceCode;
        }
    }
}
