using Microsoft.AspNetCore.Identity;

namespace Movie_Catlog_Application.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public string? ProfilePicture { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<Rating> Ratings { get; set; }
    }
}
