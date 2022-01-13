namespace NewTestamentWasm.Shared;
public partial class SecondTestComponent
{
    [Inject]
    private YearlyBibleReadingService? Service { get; set; }
    [Inject]
    private IBibleContent? Content { get; set; }
    [Parameter]
    public DateOnly DateToUse { get; set; } //so several days can be checked for testing.
    [Parameter]
    public EventCallback<DateOnly> DateToUseChanged { get; set; } //for data binding.
    private readonly ReaderModel _tempModel = new();
    private CurrentModel? _model;
    private BasicList<string> _verses = new();
    private bool _processing;
    protected override async Task OnParametersSetAsync()
    {
        _processing = true;
        _tempModel.Reset();
        dd.DateToUse = DateToUse;
        _model = Service!.GetCurrentReadingOnly();
        _verses = await Content!.GetBookChaperDataAsync(_model.CurrentReading.Book, _model.CurrentReading.Chapter);
        _processing = false;
    }
    private void CheckNewReading()
    {
        DateOnly newDate = DateToUse.AddDays(1);
        DateToUseChanged.InvokeAsync(newDate); 
    }
}