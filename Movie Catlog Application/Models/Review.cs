using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Catlog_Application.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { get; set; }

        public string Content { get; set; }

        public DateTime DatePosted { get; set; } = DateTime.Now;


        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
