namespace NewTestamentWasm.ScheduleHelpers;
public interface IScheduleStorage : IBibleStorage
{
    //if getting the list returns 0 items, then needs to ask for the complete list.
    Task<BasicList<DailyReaderModel>> GetSavedReadingListAsync();
}