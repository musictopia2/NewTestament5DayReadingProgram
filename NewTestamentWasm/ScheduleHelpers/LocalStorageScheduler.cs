namespace NewTestamentWasm.ScheduleHelpers;
public class LocalStorageScheduler : IScheduleStorage
{
    private readonly string _key = "newtestamentschedule";
    private readonly IJSRuntime _js;
    public LocalStorageScheduler(IJSRuntime js)
    {
        _js = js;
    }
    async Task<BasicList<DailyReaderModel>> IScheduleStorage.GetSavedReadingListAsync()
    {
        if (_js.ContainsKey(_key) == false)
        {
            return new(); //this means something else will happen.
        }
        var output = await _js.StorageGetItemAsync<BasicList<DailyReaderModel>>(_key);
        return output;
    }
    async Task IBibleStorage.SaveDailyReadingSchedule(BasicList<DailyReaderModel> list)
    {
        await _js.StorageSetItemAsync(_key, list);
    }
}