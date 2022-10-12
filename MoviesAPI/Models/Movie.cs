using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models;

public class Movie
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "The title is empty")]
    public string Title { get; set; }
    [StringLength(30, ErrorMessage = "The description is too long. Max 30 characters")]
    public string Genre { get; set; }
    public int Year { get; set; }
    [Range(1, 600, ErrorMessage = "The duration must be between 1 and 600 minutes")]
    public int Duration { get; set; }
    public string Director { get; set; }
}