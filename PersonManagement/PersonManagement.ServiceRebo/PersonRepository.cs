using Microsoft.Extensions.Options;
using PersonManagement.Model;
using PersonManagement.Rebository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.ServiceRebo
{
   

    public class PersonRepository : IPersonRepository
    {
        private readonly string _connection;
        public PersonRepository(IOptions<ConnectionStrings> options)
        {
            _connection = options.Value.DefaultConnection;
        }

        //public PersonRepository(ConnectionStrings connection)
        //{
        //    _connection = connection.DefaultConnection;
        //}

        // Insert into persons output INSERTED.Id

        public async Task<int> Create(PersonRebo person)
        {
            using(SqlConnection connection=new SqlConnection(_connection))
            {
                var query = "insert into person output inserted.id values (@Name,@Position,@BirthDate)";

                SqlCommand command = new SqlCommand(query,connection);

                command.Parameters.AddWithValue("Name", person.Name);
                command.Parameters.AddWithValue("Position", person.Position);
                command.Parameters.AddWithValue("BirthDate", person.BirthDate);

                connection.Open();

                var reader =await command.ExecuteScalarAsync();


                  
                connection.Close();

                return (int)reader;
                
            }
        }

        public async Task Delete(int Id)
        {
            using(SqlConnection connection=new SqlConnection(_connection))
            {
                var query = "delete from person where Id=@Id";
                SqlCommand command = new SqlCommand(query,connection);

                command.Parameters.AddWithValue("Id", Id);

                connection.Open();

                var res =await command.ExecuteNonQueryAsync();

                connection.Close();

               
            }
        }

        public async Task<PersonRebo> GetPerson(int Id)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                var query = "select * from person where id=@Id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("id", Id);

                connection.Open();

                var res = await command.ExecuteReaderAsync();

                PersonRebo person =null;

                while (await res.ReadAsync())
                {
                    person =new PersonRebo()
                    {
                        Id = res.GetInt32(0),
                        Name=res.GetString(1),
                        Position=res.GetString(2),
                        BirthDate=res.GetDateTime(3)

                    };
                }

                connection.Close();

                return person;

            }
        }
        public async Task<List<PersonRebo>> GetPersons()
        {
            List<PersonRebo> person  = new List<PersonRebo>();
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                var query = "Select * from Person";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                var res = await command.ExecuteReaderAsync();

               

                while (await res.ReadAsync())
                {
                    person.Add(new PersonRebo{

                           Id = res.GetInt32(0),
                            Name = res.GetString(1),
                            Position = res.GetString(2),
                            BirthDate = res.GetDateTime(3)


                    });
                   
                }

                connection.Close();

                return person;

            }
        }

        public  async Task Update(PersonRebo person)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                var query = "update person set Name=@Name,Position=@Position,BirthDate=@BirthDate where id=@id"; 
                    
                SqlCommand command = new SqlCommand(query, connection);


                command.Parameters.AddWithValue("Id", person.Id);
                command.Parameters.AddWithValue("Name", person.Name);
                command.Parameters.AddWithValue("Position", person.Position);
                command.Parameters.AddWithValue("BirthDate", person.BirthDate);

                connection.Open();

                var res = await command.ExecuteNonQueryAsync();             


                connection.Close();

               

            }
        }
    }
}
