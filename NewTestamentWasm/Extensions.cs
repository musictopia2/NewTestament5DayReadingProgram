namespace NewTestamentWasm;
public static class Extensions
{
    public static IServiceCollection RegisterTestServices(this IServiceCollection services)
    {
        services.RegisterBlazorBeginningClasses()
        .RegisterFlexibleTranslationServices<NewKingJamesDefaultTranslationClass>()
        .AddTransient<IDateOnlyPicker, FlexibleMockDate>()
        .AddScoped<YearlyBibleReadingService>()
        .AddTransient<IBibleContent, BibleContent>();
        return services;
    }
}