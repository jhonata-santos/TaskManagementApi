using AutoMapper;
using TaskManagementApi.DTOs;
using TaskManagementApi.Models;

namespace TaskManagementApi.Profiles;

public class TaskProfile
{
    public TaskProfile()
    {
        CreateMap<CreateTaskDto, TaskModel>();
    }
}