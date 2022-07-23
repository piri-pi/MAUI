using ORCA_MAUI;

namespace ORCA;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Services
        builder.Services.AddSingleton<IData>(new Data());

        //ViewModels
        builder.Services.AddSingleton<RecordPageViewModel>();
        builder.Services.AddTransient<AddNewProgramItemPageViewModel>();

        //Views
        builder.Services.AddSingleton<RecordPage>();
        builder.Services.AddTransient<AddNewProgramItemPage>();

        return builder.Build();
    }
}
