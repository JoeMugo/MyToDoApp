using MyToDoApp.ViewModels;

namespace MyToDoApp.Views;

public partial class TaskListPageView : ContentPage
{
	public TaskViewModel viewModel;

	public TaskListPageView(TaskViewModel taskViewModel)
	{
		InitializeComponent();
		viewModel = taskViewModel;
		this.BindingContext = taskViewModel;
	}

    protected override void OnAppearing()
    {
		base.OnAppearing();
		{
			viewModel.GetTaskListCommand.Execute(null);
		}
    }
}