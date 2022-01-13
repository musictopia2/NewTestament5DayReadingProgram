namespace NewTestamentWasm.TranslationHelpers;
public class InMemoryTranslationStorage : ITranslationStorage
{
    public InMemoryTranslationStorage()
    {
        CurrentTranslation = dd.DefaultTranslation; //start out with default translation.
    }
    public string CurrentTranslation { get; private set; }

    public Task GetTranslationAsync()
    {
        return Task.CompletedTask; //nothing is needed now.
    }

    public Task SaveTranslationAsync(string translation)
    {
        CurrentTranslation = translation;
        return Task.CompletedTask;
    }
}
