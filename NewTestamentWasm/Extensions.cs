namespace NewTestamentWasm;
public static class Extensions
{
    public static IServiceCollection RegisterTestServices(this IServiceCollection services)
    {
        services.RegisterBlazorBeginningClasses()
        .RegisterFlexibleTranslationServices<FlexibleDefaultTranslationClass>() //so can be more flexible.
        .AddTransient<IDateOnlyPicker, FlexibleMockDate>()
        .AddScoped<YearlyBibleReadingService>()
        .AddScoped<ITranslationStorage, LocalStorageTranslationStorage>() //changing over to localstorage.
        .AddTransient<IBibleContent, BibleContent>();
        return services;
    }
}