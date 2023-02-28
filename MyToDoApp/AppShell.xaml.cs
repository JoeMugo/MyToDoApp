using MyToDoApp.Views;

namespace MyToDoApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(AddTaskPageView), typeof(AddTaskPageView));
	}
}
