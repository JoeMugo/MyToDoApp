using MyToDoApp.Models;
using MyToDoApp.Services;
using MyToDoApp.ViewModels;
using MyToDoApp.Views;

namespace MyToDoApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		
		//Services
		builder.Services.AddSingleton<ITaskService, TaskService>();

		//Views Registration
		builder.Services.AddSingleton<TaskListPageView>();
		builder.Services.AddTransient<AddTaskPageView>();

		//ViewModels Registration
		builder.Services.AddSingleton<TaskViewModel>();
		builder	.Services.AddTransient<AddTaskViewModel>();


		return builder.Build();
	}
}
