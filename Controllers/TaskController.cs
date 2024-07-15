using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApi.Data;
using TaskManagementApi.DTOs;
using TaskManagementApi.Models;

namespace TaskManagementApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private TaskContext _taskContext;
    private IMapper _mapper;

    public TaskController(TaskContext taskContext, IMapper mapper)
    {
        _taskContext = taskContext;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddTask([FromBody] CreateTaskDto taskDto)
    {
        TaskModel task = _mapper.Map<TaskModel>(taskDto);
        _taskContext.Tasks.Add(task);
        _taskContext.SaveChanges();
        return CreatedAtAction(nameof(GetTaskId), new { id = task.Id }, task);
    }

    [HttpGet]
    public IEnumerable<TaskModel> GetAllTask([FromQuery] int skip = 0, int take = 50)
    {
        return _taskContext.Tasks.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult GetTaskId(int id)
    {
        var filme = _taskContext.Tasks.FirstOrDefault(task => task.Id == id);
        if (filme == null) return NotFound();
        return Ok(filme);
    }
}