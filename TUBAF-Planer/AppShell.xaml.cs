using TUBAF_Planer.View;

namespace TUBAF_Planer;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ModulDetailPage), typeof(ModulDetailPage));
	}
}
