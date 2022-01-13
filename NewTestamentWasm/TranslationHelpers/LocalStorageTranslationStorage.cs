namespace NewTestamentWasm.TranslationHelpers;

public class LocalStorageTranslationStorage : ITranslationStorage
{
    private readonly IJSRuntime _js;
    public LocalStorageTranslationStorage(IJSRuntime js)
    {
        CurrentTranslation = dd.DefaultTranslation; //start out with default translation.
        _js = js;
    }
    public string CurrentTranslation { get; private set; }

    public async Task GetTranslationAsync()
    {
        string text = await _js.StorageGetStringAsync("translationUsed");
        if (string.IsNullOrEmpty(text) == false)
        {
            CurrentTranslation = text;
        }
    }

    public async Task SaveTranslationAsync(string translation)
    {
        await _js.StorageSetStringAsync("translationUsed", translation);
        CurrentTranslation = translation;
    }
}
