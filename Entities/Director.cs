using System.ComponentModel.DataAnnotations;

namespace Movies_EFCore.Entities;

public class Director
{
    public int DirectorId { get; set; } 
    
    [Required] [MaxLength(50)]
    public string? Name { get; set; }
    
    public int Age { get; set; }

    public List<Movie> Movies { get; set; } = new(); 
}