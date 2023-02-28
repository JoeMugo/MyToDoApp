using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Input;
using MyToDoApp.Models;
using MyToDoApp.Services;
using MyToDoApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDoApp.ViewModels
{
    public partial class TaskViewModel : ObservableObject
    {
        public ObservableCollection<TaskModel> Tasks { get; set; } = new ObservableCollection<TaskModel>();
        public readonly ITaskService _taskService;
        public TaskViewModel(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [ICommand]
        public async void GetTaskList()
        {

            var tasks = await _taskService.GetAllTasks();
           
            if (tasks?.Count>0)
            {
                Tasks.Clear();
                foreach (var task in tasks)
                {
                    Tasks.Add(task);
                }
            }
        }

        [RelayCommand]

        public async void AddTask()
        {
            await AppShell.Current.GoToAsync(nameof(AddTaskPageView));
        }

        [ICommand]

        public async void DisplayAction(TaskModel taskModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                var navparam = new Dictionary<string, object>();
                navparam.Add("AddTask", taskModel);

                await AppShell.Current.GoToAsync(nameof(AddTaskPageView), navparam);
            }


            if (response == "Delete")
            {
                var deleteResponse = await _taskService.DeleteTask(taskModel);
                if (deleteResponse > 0)
                {
                    GetTaskList();
                }
               
            }
           
        }
    }
}
