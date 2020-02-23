using Epam.ExtUsersLibrary.Dao.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Epam.ExtUsersLibrary.Entities;

namespace Epam.ExtUsersLibrary.DAL.DB
{
    public class AwardDao : IAwardDao
    {
        private readonly string  _connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;
        public Award Add(Award award)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddAward";
                var nameParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Name",
                    Value = award.Name,
                    Direction = ParameterDirection.Input,
                };
                command.Parameters.Add(nameParameter);

                var imgParameter = new SqlParameter()
                {
                    DbType = DbType.Binary,
                    ParameterName = "@Img",
                    Value = award.ImageBytes,
                    Direction = ParameterDirection.Input,
                };
                command.Parameters.Add(imgParameter);

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = award.Id,
                    Direction = ParameterDirection.Output,
                };
                command.Parameters.Add(idParameter);
                connection.Open();
                command.ExecuteNonQuery();
                award.Id = (int)idParameter.Value;
                return award;
            }
        }

        public IEnumerable<Award> GetAll()
        {
            var awards = new Dictionary<int,Award>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAllAwards";
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var award = new Award(reader["name"] as string, reader["image"] as byte[]);
                        award.Id = (int)reader["id"];
                        awards.Add(award.Id, award);
                    }

                }
            }
            return awards.Values;
        }

        public Award GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.GetAwardById";
                Award award = null;
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
                        award = new Award(reader["name"] as string,reader["image"] as byte[]);
                        award.Id = (int) reader["id"];
                    }
                    
                }

                return award;
            }
        }

        public int Remove(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.RemoveAwardById";
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

        public Award Update(int awardId, string name, byte[] imgBytes)
        {
            var award = new Award(name,imgBytes);
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.UpdateAward";
                var nameParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Name",
                    Value = name,
                    Direction = ParameterDirection.Input,
                };
                command.Parameters.Add(nameParameter);

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
                    Value = awardId,
                    Direction = ParameterDirection.Input,
                };
                command.Parameters.Add(idParameter);

                connection.Open();
                command.ExecuteNonQuery();
                award.Id = (int)idParameter.Value;
                return award;
            }
        }
    }
}
