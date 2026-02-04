using System.ComponentModel.DataAnnotations;

namespace Movies_EFCore.Entities;

public class Actor
{
    public int ActorId { get; set; }
    
    
    [Required] [MaxLength(100)]
    public string Name { get; set; } = "";
    
    
    public int Age { get; set; }

    public List<Movie> Movies { get; set; } = new List<Movie>();
}