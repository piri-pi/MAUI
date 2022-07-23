namespace ORCA.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    [AlsoNotifyChangeFor(nameof(IsNotBusy))]
    bool isBusy = false;

    public bool IsNotBusy { get => !isBusy; }
}
