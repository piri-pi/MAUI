namespace ORCA.ViewModels;

public partial class RecordPageViewModel : BaseViewModel
{
    [ObservableProperty]
    List<Competency> competencies; // set in ctor

    [ObservableProperty]
    ObservableCollection<ProgramItem> program; // set in ctor

    readonly IData data;

    public RecordPageViewModel(IData data)
    {
        this.data = data;
        Program = new(data.GetProgramItems().Result);

        data.DataChanged += DataChanged;
    }

    public async Task OnAppearing()
    {
        Competencies = await data.GetCompetencies();
        Program = new(await data.GetProgramItems());
    }
    async void DataChanged(object sender, DataChangedEventArgs e)
    {
        if (e.NumberOfChangedItems == 1)
        {
            var item = e.Data.FirstOrDefault();
            if (e.Action == DataChangedEventAction.Added)
            {
                Program.Add(item);
                return;
            }
            if (e.Action == DataChangedEventAction.Deleted)
            {
                Program.Remove(item);
                return;
            }
            if (e.Action == DataChangedEventAction.Modified)
            {
                var oldItem = Program.FirstOrDefault(x => x.Id == item.Id);
                var index = Program.IndexOf(oldItem);
                Program.RemoveAt(index);
                Program.Insert(index, item);
                return;
            }
        }
        var items = await data.GetProgramItems();
        Program = new(items);
    }

    [ICommand]
    async Task DeleteAllProgramItems()
    {
        if (!await Shell.Current.DisplayAlert("Delete everything", "Really?", "Yes", "No"))
            return;
        await data.DeleteAllProgramItems();
    }

    [ICommand]
    async Task DeleteProgramItem(ProgramItem item)
    {
        if (item == null)
            return;
        if (!await Shell.Current.DisplayAlert("Delete program item", "Really?", "Yes", "No"))
            return;
        await data.DeleteProgramItem(item);
    }

    [ICommand]
    async void AddProgramItem()
    {
        await Shell.Current.GoToAsync(nameof(AddNewProgramItemPage));
    }

    [ICommand]
    void AddCommentForCM1(ProgramItem item)
    {
        if (item == null) return;
        item.CommentsForCM1.Add(new CommentItem());
    }

    [ICommand]
    void AddCommentForCM2(ProgramItem item)
    {
        if (item == null) return;
        item.CommentsForCM2.Add(new CommentItem());
    }

    [ICommand]
    async Task DeleteComment(CommentItem item)
    {
        if (item == null) return;
        // Zeige Alert nur, wenn das Comment nicht leer ist!
        if (!String.IsNullOrWhiteSpace(item.Comment))
        {
            if (!await Shell.Current.DisplayAlert("Delete Comment", "Really?", "Yes", "No"))
                return;
        }
        var pItem = Program.SingleOrDefault(x => x.CommentsForCM1.Contains(item));
        if (pItem != null)
        {
            pItem.CommentsForCM1.Remove(item);
            return;
        }
        pItem = Program.SingleOrDefault(x => x.CommentsForCM2.Contains(item));
        if (pItem != null) pItem.CommentsForCM2.Remove(item);
    }
}
