using System.ComponentModel.DataAnnotations;

namespace TaskManagementApi.DTOs;

public class ReadTaskDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Owner { get; set; }
}