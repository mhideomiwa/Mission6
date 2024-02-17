using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mission6.Models;

public class MovieForm
{
    [Key]
    [Required]
    public int MovieID { get; set; }
    [Required]
    public string Category { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    public string Director { get; set; }
    [Required]
    public string Rating { get; set; }
    public bool Edited { get; set; }
    public string LentTo { get; set; }
    [MaxLength(25)]
    public string Notes { get; set; }

    public MovieForm()
    {
        LentTo = string.Empty;
        Notes = string.Empty;

    }
}