using TaskManagement.Mobile.ViewModels;

namespace TaskManagement.Mobile.Views;

public partial class EditTaskPage : ContentPage
{
	public EditTaskPage(EditTaskViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}