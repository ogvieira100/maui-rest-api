using maui_project_rest.MVVM.ViewModel;
using System.Windows.Input;

namespace maui_project_rest.MVVM.View;

public partial class ClienteSearchView : ContentPage
{



    public ClienteSearchView()
	{
		InitializeComponent();
		BindingContext = new ClienteFindViewModel();
    }

    private async void btnAdicionarCliente_Clicked(object sender, EventArgs e)
    {
       await  Navigation.PushAsync(new ClienteAddView());
    }
}