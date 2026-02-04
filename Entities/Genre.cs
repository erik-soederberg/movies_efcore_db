using System.ComponentModel.DataAnnotations;

namespace Movies_EFCore.Entities;

public class Genre
{
    public int GenreId { get; set; }
    
    [Required] [MaxLength(50)]
    public string? GenreName { get; set; }

    public List<Movie> Movies { get; set; } = new(); 
}