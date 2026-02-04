using System.ComponentModel.DataAnnotations;

namespace Movies_EFCore.Entities;

public class Movie
{
    public int MovieId { get; set; }

    [Required] [MaxLength(100)] 
    public string MovieTitle { get; set; } = "";
    
    public int ReleaseYear { get; set; }

    public List<Actor> Actors { get; set; } = new List<Actor>();

    public List<Genre> Genres { get; set; } = new(); 
    
    
    // Creates 1-M relationship between movies and director 
    public int DirectorId { get; set; } 
    public Director? Director { get; set; }
    
    
}