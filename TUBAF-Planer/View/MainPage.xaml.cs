using Microsoft.Maui.Storage;
using Modulmethods;
using TUBAFPlaner.ViewModel;

namespace TUBAF_Planer;

public partial class MainPage : ContentPage
{
	//int count = 0;

	public MainPage(PlanViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;

		Modul modul = new Modul("#SPLUSCB0264");
		But.Text = modul.ToString();

	}

	
}

