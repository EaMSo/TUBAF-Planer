using Modulmethods;
using System.Collections.Generic;

namespace TUBAF_Planer;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
		List<Modul> fullmodulelist = FullmoduleList.GetFullmoduleList();
		string modulstring = "";
		foreach(Modul modul in fullmodulelist)
		{
			modulstring += modul.ToString();
		}
		But.Text = modulstring;

    }

	
}

