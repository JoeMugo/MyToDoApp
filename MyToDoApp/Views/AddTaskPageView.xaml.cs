using MyToDoApp.ViewModels;

namespace MyToDoApp.Views;

public partial class AddTaskPageView : ContentPage
{
	public AddTaskPageView(AddTaskViewModel addTaskViewModel)
	{
		InitializeComponent();
		this.BindingContext = addTaskViewModel;
	}
}