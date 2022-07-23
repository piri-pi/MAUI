namespace ORCA_MAUI;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(AddNewProgramItemPage), typeof(AddNewProgramItemPage));
    }
}
