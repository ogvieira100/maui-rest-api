using maui_project_rest.MVVM.ViewModel;

namespace maui_project_rest.MVVM.View;

public partial class MenuView : ContentPage
{
	public MenuView()
	{
		InitializeComponent();
		
    }

    private async void btnConsultaClientes_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClienteSearchView());
    }
}