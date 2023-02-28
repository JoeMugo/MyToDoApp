using MyToDoApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyToDoApp.Services
{
    public class TaskService : ITaskService
    {
        private SQLiteAsyncConnection _dbConnection;

        public TaskService()
        {
            SetUpDb();
        }
        private async void SetUpDb()
        {
            if(_dbConnection == null)
            {
                string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Tasks.db3");
                _dbConnection = new SQLiteAsyncConnection(dbpath);
                await _dbConnection.CreateTableAsync<TaskModel>();
            }
        }
        public Task<int> AddTask(TaskModel taskModel)
        {
            return _dbConnection.InsertAsync(taskModel);
            
        }

        public Task<int> DeleteTask(TaskModel taskModel)
        {
            return _dbConnection.DeleteAsync(taskModel);
            
        }

        public Task<List<TaskModel>> GetAllTasks()
        {
            var taskList = _dbConnection.Table<TaskModel>().ToListAsync();
            return taskList;
        }

        public Task<int> UpdateTask(TaskModel taskModel)
        {
            return _dbConnection.UpdateAsync(taskModel);
        }
    }
}
