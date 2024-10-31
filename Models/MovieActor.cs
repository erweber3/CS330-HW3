using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fall2024_Assignment3_erweber3.Models
{
    public class MovieActor
    {
        [Key]
        public int Id { get; set; }

        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; } = default!;

        public int ActorId { get; set; }
        public virtual Actor Actor { get; set; } = default!;
    }
}
