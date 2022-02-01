namespace NewTestamentWasm.Shared;
public partial class ScheduleReaderComponent
{
    [Inject]
    private IBibleContent? Content { get; set; }
    [Inject]
    private ITranslationService? TranslationService { get; set; }
    [Inject]
    private ITranslationStorage? TranslationStorage { get; set; }
    [Inject]
    private IScheduleService? ScheduleService { get; set; }
    private readonly ReaderModel _tempModel = new();
    private CurrentModel? _model;
    private BasicList<string> _verses = new();
    private bool _processing;
    private string _title = "";
    private bool ShowBars => !_showTranslation;
    private bool _showTranslation;
    private readonly BasicList<MenuItem> _menus = new();
    private BasicList<TranslationInformation> _translations = new();
    private BasicList<DailyReaderModel> _dailyList = new();
    protected override void OnInitialized()
    {
        _menus.Add(new MenuItem()
        {
            Text = "Change Translation",
            Clicked = ChangeTranslation
        });
    }
    protected override async Task OnInitializedAsync()
    {
        await TranslationStorage!.GetTranslationAsync(); //do this first.
        UpdateTitle();
        _translations = await TranslationService!.ListTranslationsAsync();
        _processing = true;
        _tempModel.Reset();
        _dailyList = await ScheduleService!.GetReadingListAsync();
        _model = ScheduleService.GetCurrentInfo(_dailyList);
        _verses = await Content!.GetBookChaperDataAsync(_model.CurrentReading.Book, _model.CurrentReading.Chapter);
        _processing = false;
    }
    private void ChangeTranslation() //for now has to break out of the standard.  will change after rethinking.
    {
        _showTranslation = true;
        StateHasChanged();
    }
    private void UpdateTitle()
    {
        _title = $"Read {TranslationStorage!.CurrentTranslation}";
    }
    private async Task ChoseTranslationAsync(TranslationInformation translation)
    {
        _tempModel.Reset(); //has to reset the highlighter i think.
        _showTranslation = false;
        await TranslationStorage!.SaveTranslationAsync(translation.TranslationAbb);
        UpdateTitle();
        _verses = await Content!.GetBookChaperDataAsync(_model!.CurrentReading.Book, _model.CurrentReading.Chapter);
    }
    private async Task FinishReadingAsync()
    {
        //you may have another reading.  has to save what you have done.
        _model!.CurrentReading.Completed = true;
        await ScheduleService!.SaveReadingListAsync(_dailyList);
        _model = ScheduleService.GetCurrentInfo(_dailyList); //hopefully will just work now.

    }
}