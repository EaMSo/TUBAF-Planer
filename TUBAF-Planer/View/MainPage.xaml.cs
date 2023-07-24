using Modulmethods;
using System.Collections.Generic;
using Microsoft.Maui.Storage;
using TUBAFPlaner.ViewModel;


namespace TUBAF_Planer;

public partial class MainPage : ContentPage
{

	public MainPage(PlanBuilderViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }	
}

