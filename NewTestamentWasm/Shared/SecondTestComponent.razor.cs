namespace NewTestamentWasm.Shared;
public partial class SecondTestComponent
{
    [Inject]
    private YearlyBibleReadingService? _service { get; set; }
    [Inject]
    private IBibleContent? _content { get; set; }
    [Parameter]
    public DateOnly DateToUse { get; set; } //so several days can be checked for testing.
    [Parameter]
    public EventCallback<DateOnly> DateToUseChanged { get; set; } //for data binding.
    private ReaderModel _tempModel = new();
    private CurrentModel? _model;
    private BasicList<string> _verses = new();
    private bool _processing;
    protected override async Task OnParametersSetAsync()
    {
        _processing = true;
        _tempModel.Reset();
        dd.DateToUse = DateToUse;
        _model = _service!.GetCurrentReadingOnly();
        _verses = await _content!.GetBookChaperDataAsync(_model.CurrentReading.Book, _model.CurrentReading.Chapter);
        _processing = false;
    }
    private void CheckNewReading()
    {
        DateOnly newDate = DateToUse.AddDays(1);
        DateToUseChanged.InvokeAsync(newDate); 
    }
}