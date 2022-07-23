namespace ORCA.Services;

public class CompetencyColors
{
    public static Dictionary<string, Color> ColorLookup { get; } = new Dictionary<string, Color>()
        {
            {"KNO", Colors.YellowGreen},
            {"PRO", Colors.CornflowerBlue},
            {"COM", Colors.Orange},
            {"FPA", Colors.Red},
            {"FPM", Colors.SpringGreen},
            {"LTW", Colors.Firebrick},
            {"PSD", Colors.Yellow},
            {"SAW", Colors.DeepSkyBlue},
            {"WLM", Colors.ForestGreen}
        };
}
