using maui_project_rest.MVVM.ViewModel;

namespace maui_project_rest.MVVM.View;

public partial class ClienteAddView : ContentPage
{

    ClienteAddViewModel _cliViewModel;
    public ClienteAddView()
	{
		InitializeComponent();
        _cliViewModel = new ClienteAddViewModel();
        BindingContext = _cliViewModel;
	}

    private  async void btnSalvar_Clicked(object sender, EventArgs e)
    {
         await _cliViewModel.SalvarCliente();   
         await App.Current.MainPage.DisplayAlert("Mensagem do Sistema","Dados atualizados com sucesso","Ok");
         await Navigation.PopAsync();  
    }
}