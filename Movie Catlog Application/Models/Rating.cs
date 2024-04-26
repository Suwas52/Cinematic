using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Catlog_Application.Models
{
    public class Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RatingId { get; set; }

        public decimal RatingValue { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser User  { get; set; }

        [ForeignKey("Movie")]
        public int MovieId { get; set; }

        public Movie Movie  { get; set; }

       
    }
}
