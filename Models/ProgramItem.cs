namespace ORCA.Models;

public partial class ProgramItem : ObservableObject
{
    [ObservableProperty]
    Guid id = Guid.NewGuid();

    [ObservableProperty]
    string name = "";

    [ObservableProperty]
    string description = "";

    [ObservableProperty]
    ObservableCollection<CommentItem> commentsForCM1 = new();

    [ObservableProperty]
    ObservableCollection<CommentItem> commentsForCM2 = new();
}
