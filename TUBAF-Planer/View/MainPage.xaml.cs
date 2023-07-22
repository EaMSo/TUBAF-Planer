using Modulmethods;

namespace TUBAF_Planer;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
		Modul modul = new Modul("#SPLUSCB0264");
		But.Text = modul.ToString();
	}

	
}

