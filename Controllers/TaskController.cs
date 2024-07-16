using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
    public IEnumerable<ReadTaskDto> GetAllTasks([FromQuery] int skip = 0, int take = 50)
    {
        return _mapper.Map<List<ReadTaskDto>>(_taskContext.Tasks.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult GetTask(int id)
    {
        var task = _taskContext.Tasks.FirstOrDefault(task => task.Id == id);
        if (task == null) return NotFound();
        var taskDto = _mapper.Map<ReadTaskDto>(task);
        return Ok(taskDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTask(int id, [FromBody] UpdateTaskDto taskDto)
    {
        var task = _taskContext.Tasks.FirstOrDefault(task => task.Id == id);
        if (task == null) return NotFound();
        _mapper.Map(taskDto, task);
        _taskContext.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdatePartialTask(int id, JsonPatchDocument<UpdateTaskDto> patch)
    {
        var task = _taskContext.Tasks.FirstOrDefault(task => task.Id == id);
        if (task == null) return NotFound();
        var taskToUpdate = _mapper.Map<UpdateTaskDto>(task);

        patch.ApplyTo(taskToUpdate, ModelState);
        if (!TryValidateModel(taskToUpdate))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(taskToUpdate, task);
        _taskContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete]
    public IActionResult DeleteAllTasks()
    {
        var tasks = GetAllTasks();
        _taskContext.Tasks.RemoveRange(tasks);
        _taskContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete]
    public IActionResult DeleteTask(int id)
    {
        var task = _taskContext.Tasks.FirstOrDefault(task => task.Id == id);
        if (task == null) return NotFound();
        _taskContext.Remove(task);
        _taskContext.SaveChanges();
        return NoContent();
    }
}