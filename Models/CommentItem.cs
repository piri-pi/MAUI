namespace ORCA.Models;

public partial class CommentItem : ObservableObject
{
    [ObservableProperty]
    string comment = "";

    [ObservableProperty]
    ObservableCollection<string> observedCompetencies = new();

    [ObservableProperty]
    Guid id = Guid.NewGuid();
}
