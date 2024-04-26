using System.ComponentModel.DataAnnotations;

namespace Movie_Catlog_Application.DTOs.User
{
    public class Login
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
