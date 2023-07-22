using Modulmethods;
using System.Collections.Generic;
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
		/*List<Modul> fullmodulelist = FullmoduleList.GetFullmoduleList();
		string modulstring = "";
		foreach(Modul modul in fullmodulelist)
		{
			modulstring += modul.ToString();
		}
		But.Text = modulstring;*/

    }


		


	
}

