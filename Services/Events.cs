namespace ORCA.Services;

public delegate void DataChangedEventHandler(object source, DataChangedEventArgs e);
public class DataChangedEventArgs : EventArgs
{
    public int NumberOfChangedItems { get; set; }
    public DataChangedEventAction Action { get; set; }
    public IEnumerable<ProgramItem> Data { get; set; }

    public DataChangedEventArgs(int n, IEnumerable<ProgramItem> data, DataChangedEventAction action)
    {
        NumberOfChangedItems = n;
        Data = data;
        Action = action;
    }
    public DataChangedEventArgs(ProgramItem programItem, DataChangedEventAction action)
    {
        NumberOfChangedItems = 1;
        Data = new List<ProgramItem> { programItem };
        Action = action;
    }
}
public enum DataChangedEventAction
{
    Added, Deleted, Modified, Reloaded
}
