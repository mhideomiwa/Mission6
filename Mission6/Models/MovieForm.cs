using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6.Models;

public class MovieForm
{
    [Key]
    [Required]
    public int MovieId { get; set; }
    
    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    [Range(1888, int.MaxValue, ErrorMessage = "Year must be between after 1888")]
    public int Year { get; set; }
    public string? Director { get; set; }
    public string? Rating { get; set; }
    public int Edited { get; set; }
    public string? LentTo { get; set; }
    
    [Required]
    public int CopiedToPlex { get; set; }
    [MaxLength(25)]
    public string? Notes { get; set; }
}