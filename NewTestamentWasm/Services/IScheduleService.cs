namespace NewTestamentWasm.Services;
public interface IScheduleService
{
    Task<BasicList<DailyReaderModel>> GetReadingListAsync();
    Task SaveReadingListAsync(BasicList<DailyReaderModel> list);
    CurrentModel GetCurrentInfo(BasicList<DailyReaderModel> list);

}