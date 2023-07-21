using TUBAFPlaner.ViewModel;

namespace TUBAF_Planer.View;

public partial class ModulDetailPage : ContentPage
{
	public ModulDetailPage(ModulDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}