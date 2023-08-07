using maui_project_rest.MVVM.ViewModel;

namespace maui_project_rest.MVVM.View;

public partial class ClienteEditView : ContentPage
{


    ClienteEditViewModel _clienteEditViewModel;
    public ClienteEditView()
    {
        InitializeComponent();

    }

    public ClienteEditView(ClienteEditViewModel clienteEditViewModel) : this()
    {
        _clienteEditViewModel = clienteEditViewModel;
        BindingContext = _clienteEditViewModel;
    }

    private async void btnSalvar_Clicked(object sender, EventArgs e)
    {
        await _clienteEditViewModel.AtualizarCliente(); 
        await App.Current.MainPage.DisplayAlert("Mensagem do Sistema", "Dados atualizados com sucesso", "Ok");
        await Navigation.PopAsync();
    }
}