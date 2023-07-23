using TUBAFPlaner.ViewModel;

namespace TUBAF_Planer;

public partial class PlanbuilderPage : ContentPage
{
	public PlanbuilderPage(PlanBuilderViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}
	
}