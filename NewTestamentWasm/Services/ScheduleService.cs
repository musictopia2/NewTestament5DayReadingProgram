namespace NewTestamentWasm.Services;
public class ScheduleService : IScheduleService
{
    private readonly IScheduleStorage _storage;
    private readonly YearlyBibleReadingService _year;
    private readonly IDateOnlyPicker _picker;
    public ScheduleService(IScheduleStorage storage, YearlyBibleReadingService year, IDateOnlyPicker picker)
    {
        _storage = storage;
        _year = year;
        _picker = picker;
    }
    CurrentModel IScheduleService.GetCurrentInfo(BasicList<DailyReaderModel> list)
    {
        DailyReaderModel model = list.First(x => x.Completed == false);
        CurrentModel output = new();
        output.CurrentReading = model;
        output.IsCurrentReading = _picker.GetCurrentDate <= model.ReadDate.ToDateOnly();
        return output;
    }
    async Task<BasicList<DailyReaderModel>> IScheduleService.GetReadingListAsync()
    {
        var firsts = await _storage.GetSavedReadingListAsync();
        var nexts = firsts.Where(x => x.Completed == true).ToBasicList();
        BasicList<DailyReaderModel> output;
        if (nexts.Any() == false)
        {
            output = _year.GetReadingSchedule(_picker.CurrentYear(), false);
            return output; //i think
        }
        output = firsts;
        return output;
    }
    async Task IScheduleService.SaveReadingListAsync(BasicList<DailyReaderModel> list)
    {
        await _storage.SaveDailyReadingSchedule(list);
    }
}