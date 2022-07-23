namespace ORCA.ViewModels;

public partial class AddNewProgramItemPageViewModel : BaseViewModel
{
    [ObservableProperty]
    // [AlsoNotifyCanExecuteFor(nameof(AddCommand))] doesn't work
    ProgramItem programItem = new();

    readonly IData data; //set in ctor

    public AddNewProgramItemPageViewModel(IData data)
    {
        this.data = data;
        ProgramItem.PropertyChanged += (s, e) => AddCommand.NotifyCanExecuteChanged(); // workaround
    }

    [ICommand]
    async Task Cancel()
    {
        await Shell.Current.GoToAsync("..");
    }
    [ICommand(CanExecute = nameof(CanAdd))]
    async Task Add()
    {
        await data.AddProgramItem(ProgramItem);
        await Shell.Current.GoToAsync("..");
    }
    bool CanAdd()
    {
        return !String.IsNullOrWhiteSpace(ProgramItem.Name);
    }
}

