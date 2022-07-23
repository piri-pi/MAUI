namespace ORCA.Views;

public partial class AddNewProgramItemPage : ContentPage
{
	public AddNewProgramItemPage(AddNewProgramItemPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}