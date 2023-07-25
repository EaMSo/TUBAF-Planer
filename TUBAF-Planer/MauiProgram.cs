using Microsoft.Extensions.Logging;
using Modulmethods;
using TUBAF_Planer.View;
using TUBAFPlaner.ViewModel;

namespace TUBAF_Planer;

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
        CustomModule.CreateTable();
        

#if DEBUG
        builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<PlanViewModel>();
		builder.Services.AddTransient<ModulDetailViewModel>();
		builder.Services.AddTransient<ModulDetailPage>();	
		builder.Services.AddSingleton<PlanBuilderViewModel>();
		builder.Services.AddSingleton<PlanbuilderPage>();

		return builder.Build();
	}
}
