namespace ORCA.Services;

public static class Extensions
{
    public static ProgramItem DeepCopy(this ProgramItem p)
    {
        string copy = JsonConvert.SerializeObject(p);
        var result = JsonConvert.DeserializeObject<ProgramItem>(copy);
        return result;
    }
}
