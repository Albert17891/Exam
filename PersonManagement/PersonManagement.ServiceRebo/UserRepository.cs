using Microsoft.Extensions.Options;
using PersonManagement.Model;
using PersonManagement.Model.Login_Model;
using PersonManagement.Rebository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.ServiceRebo
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connection;


        private string SECRET = "HELLO";
             

        public UserRepository(IOptions<ConnectionStrings> options)
        {
            _connection = options.Value.DefaultConnection;
        }
        //insert into person output inserted.id values (@Name,@Position,@BirthDate)
        public async Task<string> Create(UserRepo userRepo)
        {
            using(SqlConnection connection=new SqlConnection(_connection))
            {
                string query = "insert into [users] output inserted.UserName values (@FirstName,@LastName,@UserName,@Password)";
                SqlCommand command = new SqlCommand(query,connection);

                command.Parameters.AddWithValue("FirstName", userRepo.FirstName);
                command.Parameters.AddWithValue("LastName", userRepo.LastName);
                command.Parameters.AddWithValue("UserName", userRepo.UserName);
                var password = GenerateMdh5(SECRET + userRepo.Password);
                command.Parameters.AddWithValue("Password", password);

                connection.Open();

                var result =await command.ExecuteScalarAsync();

                connection.Close();

                return (string)result;
            }

           
        }

        public async Task<UserRepo> Login(string username, string password)
        {
           using(SqlConnection connection=new SqlConnection(_connection))
            {
                string query = "Select * From [Users] Where  UserName=@UserName and Password=@Password";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("UserName", username);
                var pass = GenerateMdh5(SECRET + password);
                command.Parameters.AddWithValue("Password", pass);

                connection.Open();

                var res =await command.ExecuteReaderAsync();


                UserRepo user = null;

                while (await res.ReadAsync())
                {
                    user = new UserRepo()
                    {
                        Id = res.GetInt32(0),
                        FirstName = res.GetString(1),
                        LastName = res.GetString(2),
                        UserName = res.GetString(3)
                       
                    };
                    
                }

                connection.Close();

                return user;
            }
        }




        private string GenerateMdh5(string input)
        {
            using(MD5 mD= MD5.Create() )
            {
                byte[] inp = Encoding.UTF8.GetBytes(input);
                byte[] hashValues = mD.ComputeHash(inp);

                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < hashValues.Length; i++)
                {
                    builder.Append(hashValues[i].ToString("X2"));
                }

                return builder.ToString() ;
            }
        }
    }
}
