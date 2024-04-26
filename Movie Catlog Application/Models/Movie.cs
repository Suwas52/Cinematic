using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Catlog_Application.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }

        public  string Title { get; set; }
        public string Description { get; set; }

        public DateTime  ReleaseDate { get; set; }

        public int Runtime { get; set; }

        public string? MovieImage { get; set; }
        public string? Cast { get; set; }

        public string? Director { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public ICollection<Review> Reviews { get; set; }

    }
}
