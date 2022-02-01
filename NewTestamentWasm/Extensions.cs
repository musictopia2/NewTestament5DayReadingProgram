namespace NewTestamentWasm;
public static class Extensions
{
    public static IServiceCollection RegisterTestServices(this IServiceCollection services, bool useTestDate)
    {
        services.RegisterBlazorBeginningClasses()
        .RegisterFlexibleTranslationServices<FlexibleDefaultTranslationClass>(); //so can be more flexible.
        if (useTestDate)
        {
            services.AddTransient<IDateOnlyPicker, FlexibleMockDate>();
        }
        else
        {
            services.RegisterRealDatePicker();
        }
        services.AddScoped<YearlyBibleReadingService>()
        .AddScoped<ITranslationStorage, LocalStorageTranslationStorage>() //changing over to localstorage.
        .AddTransient<IBibleContent, BibleContent>()
        .AddScoped<IScheduleService, ScheduleService>()
        .AddScoped<IScheduleStorage, LocalStorageScheduler>();
        return services;
    }
}