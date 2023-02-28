using MyToDoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDoApp.Services
{
    public interface ITaskService
    {
        Task<List<TaskModel>> GetAllTasks();
        Task<int> AddTask(TaskModel taskModel);
        Task<int> DeleteTask(TaskModel taskModel);
        Task<int> UpdateTask(TaskModel taskModel);
    }
}
