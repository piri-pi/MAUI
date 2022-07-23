namespace ORCA.Models;
public partial class ObservableCompetency : ObservableObject
{
    [ObservableProperty]
    bool observed = false;

    [ObservableProperty]
    string competencyName = "";
}

