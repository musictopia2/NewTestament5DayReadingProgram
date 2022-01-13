namespace NewTestamentWasm.TranslationHelpers;

public interface ITranslationStorage
{
    Task SaveTranslationAsync(string translation);
    Task GetTranslationAsync(); //no need to return string because you have the string afterwards
    string CurrentTranslation { get; }
}