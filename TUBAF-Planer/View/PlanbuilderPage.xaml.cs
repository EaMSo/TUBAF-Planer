using TUBAFPlaner.ViewModel;

namespace TUBAF_Planer;

public partial class PlanbuilderPage : ContentPage
{
	public PlanbuilderPage(PlanBuilderViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}
    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        PlanBuilderViewModel viewModel = (PlanBuilderViewModel)BindingContext;
        string searchText = e.NewTextValue.ToLower();

        if (string.IsNullOrWhiteSpace(searchText))
        {
            // Show all items when the search text is empty or null
            Modulcollection.ItemsSource = viewModel.Module;
            Custommodulcollection.ItemsSource = viewModel.CustomModules;
        }
        else
        {
            // Filter the items based on the search query
            var filteredItems = viewModel.Module.Where(item => item.Coursename.ToLower().Contains(searchText)).ToList();
            Modulcollection.ItemsSource = filteredItems;
            var filteredItemscustom = viewModel.CustomModules.Where(item => item.Coursename.ToLower().Contains(searchText)).ToList();
            Custommodulcollection.ItemsSource = filteredItemscustom;
        }
    }

}