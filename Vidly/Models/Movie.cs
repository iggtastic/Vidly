using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Display(Name="Genre")]
        public byte GenreId { get; set; }

        [Required]
        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Required] // don't need to add this here since it's a struct (has to be non-null by default), but it helps for clarity and intent
        [Range(1,20)]
        [Display(Name="Number in Stock")]
        public int NumberInStock { get; set; }

        [Display(Name ="Number Available")]
        public int NumberAvailable { get; set; }
    }
}