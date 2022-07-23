namespace ORCA.Models;

public class Competency
{
    public string Name { get; set; }
    public string FullName { get; set; }
    public string Description { get; set; }
    public string Bedeutung { get; set; }
    public Dictionary<int, string> GradingOptions { get; set; }
    public List<ObItem> OBs { get; set; }
}
public class ObItem
{
    public string Identifyer { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Bedeutung { get; set; }
    public string PraktischesBeispiel { get; set; }
}
