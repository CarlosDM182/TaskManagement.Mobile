using TaskManagement.Mobile.ViewModels;

namespace TaskManagement.Mobile.Views;


public partial class TaskDetailPage : ContentPage
{
	public TaskDetailPage(TaskDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}