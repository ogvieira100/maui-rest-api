using maui_project_rest.MVVM.ViewModel;

namespace maui_project_rest.MVVM.View;

public partial class ClienteDeleteView : ContentPage
{

    ClienteDeleteViewModel _viewModel;

    public ClienteDeleteView(ClienteDeleteViewModel viewModel):this()
    {
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
    public ClienteDeleteView()
	{
		InitializeComponent();
	}

    private async void btnDelete_Clicked(object sender, EventArgs e)
    {
        await _viewModel.DeletarCliente();
        await App.Current.MainPage.DisplayAlert("Mensagem do Sistema", "Dados atualizados com sucesso", "Ok");
        await Navigation.PopAsync();

    }
}