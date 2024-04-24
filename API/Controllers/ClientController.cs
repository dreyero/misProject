using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using api.Models; // Import the Client class

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private string connectionString = "Server=rnr56s6e2uk326pj.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;Port=3306;Database=sb5y44iffp397jlz;Uid=s62lx43ius8m0zat;Pwd=bdlhxalgz5ueuq7f;";

        [HttpPost]
        [Route("signup")]
        public IActionResult Signup(Client client)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO Client (FirstName, LastName, Email, Password, PhoneNumber) 
                                     VALUES (@FirstName, @LastName, @Email, @Password, @PhoneNumber)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", client.FirstName);
                        command.Parameters.AddWithValue("@LastName", client.LastName);
                        command.Parameters.AddWithValue("@Email", client.Email);
                        command.Parameters.AddWithValue("@Password", client.Password);
                        command.Parameters.AddWithValue("@PhoneNumber", client.PhoneNumber);

                        command.ExecuteNonQuery();
                    }
                }

                return Ok(new { success = true, message = "User signed up successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Failed to signup: " + ex.Message });
            }
        }
    }
}
