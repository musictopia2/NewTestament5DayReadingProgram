namespace NewTestamentWasm.Shared;

public partial class FourthTestComponent
{
    [Inject]
    private IDateOnlyPicker? Picker { get; set; }
    [Inject]
    private YearlyBibleReadingService? YearService { get; set; }
    [Inject]
    private IBibleContent? Content { get; set; }
    [Inject]
    private ITranslationService? TranslationService { get; set; }
    [Inject]
    private ITranslationStorage? TranslationStorage { get; set; }
    private readonly ReaderModel _tempModel = new();
    private CurrentModel? _model;
    private BasicList<string> _verses = new();
    private bool _processing;
    private string _title = "";
    private bool ShowBars => !_showTranslation;
    private bool _showTranslation;
    private readonly BasicList<MenuItem> _menus = new();
    private BasicList<TranslationInformation> _translations = new();
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
        _model = YearService!.GetCurrentReadingOnly();
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
}
