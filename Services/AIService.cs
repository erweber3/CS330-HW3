using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fall2024_Assignment3_erweber3.Models
{
    public class Actor
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = default!;

        public string? Gender { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }

        [Url]
        public string? ImdbLink { get; set; }

        public byte[]? PhotoUrl { get; set; }

        // Navigation property for the many-to-many relationship with Movie
        public virtual ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
    }
}
        