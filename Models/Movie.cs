using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fall2024_Assignment3_erweber3.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = default!;

        [Url]
        public string? ImdbLink { get; set; }

        public string Genre { get; set; } = default!;

        [Range(1900, 2100)]
        public int YearOfRelease { get; set; }

        [Url]
        public string? PosterUrl { get; set; }

        // Navigation property for the many-to-many relationship with Actor
        public virtual ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
    }
}
