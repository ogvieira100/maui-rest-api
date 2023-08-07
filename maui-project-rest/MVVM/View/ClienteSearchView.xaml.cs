using maui_project_rest.MVVM.ViewModel;
using System.Windows.Input;

namespace maui_project_rest.MVVM.View;

public partial class ClienteSearchView : ContentPage
{


    ClienteFindViewModel _clienteFindViewModel;
    public ClienteSearchView()
	{
		InitializeComponent();
        _clienteFindViewModel = new ClienteFindViewModel();
        BindingContext = _clienteFindViewModel;
    }

    private async void btnAdicionarCliente_Clicked(object sender, EventArgs e)
    {
       await  Navigation.PushAsync(new ClienteAddView());
    }

    private async void btnExcluirClientes_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClienteDeleteView(new ClienteDeleteViewModel
        {
            CPF = _clienteFindViewModel.ClienteSelected.CPF,
            Id = _clienteFindViewModel.ClienteSelected.Id,
            Endereco = _clienteFindViewModel.ClienteSelected.Endereco,
            Nome = _clienteFindViewModel.ClienteSelected.Nome
        }));
    }

    private async void btnEditarClientes_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClienteEditView(new ClienteEditViewModel
        {
            CPF = _clienteFindViewModel.ClienteSelected.CPF,
            Id = _clienteFindViewModel.ClienteSelected.Id,
            Endereco = _clienteFindViewModel.ClienteSelected.Endereco,
            Nome = _clienteFindViewModel.ClienteSelected.Nome
        }));
       
    }
}