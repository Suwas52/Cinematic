using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Catlog_Application.Models
{
    public class MovieGenre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieGenreId { get; set; }


           
            public int? MovieId { get; set; }
            public Movie? Movie { get; set; }

          
            public int? GenreId { get; set; }
            public Genre? Genre { get; set; }

    }
}
