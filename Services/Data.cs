namespace ORCA.Services;

public class Data : IData
{
    private readonly string filename = "data.json";
    private readonly string folder = FileSystem.AppDataDirectory;
    private List<Competency> competencies;
    private List<ProgramItem> programItems;

    public event DataChangedEventHandler DataChanged;

    public Data()
    {
        programItems = new List<ProgramItem>();
    }

    public Task AddProgramItem(ProgramItem programItem)
    {
        if (programItems == null || programItem == null)
            return Task.CompletedTask;
        programItems.Add(programItem);
        OnDataChanged(programItem, DataChangedEventAction.Added);
        return Task.CompletedTask;
    }

    public Task DeleteProgramItem(ProgramItem programItem)
    {
        if (programItems == null || programItem == null)
            return Task.CompletedTask;
        programItems.Remove(programItem);
        OnDataChanged(programItem, DataChangedEventAction.Deleted);
        return Task.CompletedTask;
    }

    public Task UpdateProgramItem(ProgramItem programItem)
    {
        var oldItem = programItems.FirstOrDefault(x => x.Id == programItem.Id);
        var index = programItems.IndexOf(oldItem);
        if (index == -1) return Task.CompletedTask;
        programItems.RemoveAt(index);
        programItems.Insert(index, programItem);
        OnDataChanged(programItem, DataChangedEventAction.Modified);
        return Task.CompletedTask;
    }

    public Task<ProgramItem> GetProgramItem(Guid guid)
    {
        var item = programItems.FirstOrDefault(x => x.Id == guid);
        return Task.FromResult(item);
    }

    public async Task<List<Competency>> GetCompetencies()
    {
        if (competencies == null)
        {
            try
            {
                using var stream = await FileSystem.Current.OpenAppPackageFileAsync("competencies.json");
                using var reader = new StreamReader(stream);
                string json = await reader.ReadToEndAsync();
                competencies = JsonConvert.DeserializeObject<List<Competency>>(json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"BERNI: {ex.Message}");
                return await Task.FromResult(competencies).ConfigureAwait(false);
            }
        }
        return await Task.FromResult(competencies).ConfigureAwait(false);
    }

    public async Task<List<ProgramItem>> GetProgramItems()
    {
        if (programItems == null)
            programItems = new List<ProgramItem>();
        return await Task.FromResult(programItems).ConfigureAwait(false);
    }

    private void OnDataChanged(ProgramItem programItem, DataChangedEventAction action)
    {
        DataChanged?.Invoke(this, new DataChangedEventArgs(programItem, action));
    }

    private void OnDataChanged(IEnumerable<ProgramItem> programItems, DataChangedEventAction action)
    {
        DataChanged?.Invoke(this, new DataChangedEventArgs(programItems.Count(), programItems, action));
    }

    public Task AddProgramItems(IEnumerable<ProgramItem> programItems)
    {
        if (!(bool)(programItems?.Any()))
            return Task.CompletedTask;
        this.programItems.AddRange(programItems);
        OnDataChanged(programItems, DataChangedEventAction.Added);
        return Task.CompletedTask;
    }

    public Task DeleteAllProgramItems()
    {
        programItems.Clear();
        OnDataChanged(programItems, DataChangedEventAction.Deleted);
        return Task.CompletedTask;
    }

    public Task Load()
    {
        try
        {
            var file = Path.Combine(folder, filename);
            if (File.Exists(file))
            {
                var json = File.ReadAllText(file);
                programItems.Clear();
                programItems.AddRange(JsonConvert.DeserializeObject<IEnumerable<ProgramItem>>(json));
                OnDataChanged(programItems, DataChangedEventAction.Reloaded);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"BERNI: {ex.Message}");
            return Task.CompletedTask;
        }
        return Task.CompletedTask;
    }

    public Task Save()
    {
        try
        {
            var file = Path.Combine(folder, filename);
            var json = JsonConvert.SerializeObject(programItems);
            File.WriteAllText(file, json);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"BERNI: {ex.Message}");
            return Task.CompletedTask;
        }
        return Task.CompletedTask;
    }
}
