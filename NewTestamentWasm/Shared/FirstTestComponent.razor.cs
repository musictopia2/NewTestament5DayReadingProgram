namespace NewTestamentWasm.Shared;
public partial class FirstTestComponent
{
    [Inject]
    private YearlyBibleReadingService? _service { get; set; }
    [Parameter]
    public DateOnly DateToUse { get; set; } //so several days can be checked for testing.
    [Parameter]
    public EventCallback<DateOnly> DateToUseChanged { get; set; } //for data binding.
    private CurrentModel? _model;
    protected override void OnParametersSet()
    {
        dd.DateToUse = DateToUse;
        _model = _service!.GetCurrentReadingOnly();
        base.OnParametersSet();
    }
    private void CheckNewReading()
    {
        //hopefully does onparameterset again.
        DateOnly newDate = DateToUse.AddDays(1);
        DateToUseChanged.InvokeAsync(newDate); //hopefully this simple. (2 way data binding).
        //dd.DateToUse = dd.DateToUse.AddDays(1);
        //_model = _service!.GetCurrentReadingOnly();
    }
}