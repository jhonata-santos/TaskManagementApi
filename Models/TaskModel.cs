using System.ComponentModel.DataAnnotations;

namespace TaskManagementApi.Models;

public class TaskModel
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "The task title is mandatory")]
    [MaxLength(50, ErrorMessage = "Title length cannot exceed 50 characters")]
    public required string Title { get; set; }
    
    public string? Description { get; set; }

    [Required]
    public required string Status { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required(ErrorMessage = "The task owner is mandatory")]
    [MaxLength(50, ErrorMessage = "Owner length cannot exceed 50 characters")]
    public required string Owner { get; set; }
}