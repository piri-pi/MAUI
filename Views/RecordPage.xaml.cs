namespace ORCA.Views;

public partial class RecordPage : ContentPage
{
	public RecordPage(RecordPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
		await (BindingContext as RecordPageViewModel).OnAppearing();
    }
}