using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Input;
using MyToDoApp.Models;
using MyToDoApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDoApp.ViewModels
{
    [QueryProperty(nameof(AddTask),"AddTask")]
    public partial class AddTaskViewModel : ObservableObject
    {
        [ObservableProperty]

        public TaskModel taskDetails;
        private readonly ITaskService _taskService;
        public AddTaskViewModel(ITaskService taskService)
        {
            _taskService = taskService;

            TaskDetails = new TaskModel();
        }

       

        [ICommand]

        public async void AddTask()
        {
            var response = await _taskService.AddTask(TaskDetails);
            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Task Added","Task Added Successfully","OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Not Added","Something went wrong", "OK");
            }
        }

        
    }
}
