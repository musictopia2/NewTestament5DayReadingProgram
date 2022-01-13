namespace NewTestamentWasm.Services;
public class FlexibleDefaultTranslationClass : IFlexibleDefaultTranslationService
{
    private readonly ITranslationStorage _storage;
    public FlexibleDefaultTranslationClass(ITranslationStorage storage)
    {
        _storage = storage;
    }
    string IFlexibleDefaultTranslationService.DefaultTranslationAbb => _storage.CurrentTranslation;
}