using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SignInController : ControllerBase
    {
        private string connectionString = "Server=rnr56s6e2uk326pj.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;Port=3306;Database=sb5y44iffp397jlz;Uid=s62lx43ius8m0zat;Pwd=bdlhxalgz5ueuq7f;";

        [HttpPost]
        public IActionResult SignIn(SignInRequest signInRequest)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Id FROM Client WHERE Email = @Email AND Password = @Password";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", signInRequest.Email);
                        command.Parameters.AddWithValue("@Password", signInRequest.Password);

                        object result = command.ExecuteScalar();

                        if (result != null) // User found
                        {
                            return Ok(new { success = true, message = "Sign in successful" });
                        }
                        else // User not found
                        {
                            return Unauthorized(new { success = false, message = "Invalid email or password" });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "An error occurred: " + ex.Message });
            }
        }
    }

    public class SignInRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
