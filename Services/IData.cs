namespace ORCA.Services;

public interface IData
{
    Task<List<Competency>> GetCompetencies();
    Task<List<ProgramItem>> GetProgramItems();
    Task<ProgramItem> GetProgramItem(Guid guid);
    Task AddProgramItem(ProgramItem programItem);
    Task AddProgramItems(IEnumerable<ProgramItem> programItems);
    Task DeleteProgramItem(ProgramItem programItem);
    Task UpdateProgramItem(ProgramItem programItem);
    Task DeleteAllProgramItems();
    Task Load();
    Task Save();
    event DataChangedEventHandler DataChanged;
}    
