using domain;
using maui_project_rest.Util;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace maui_project_rest.MVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class ClienteFindViewModel
    {
        public ObservableCollection<ClienteViewModel> Clientes { get; set; } =
                        new ObservableCollection<ClienteViewModel>();

        public ClienteViewModel ClienteSelected { get; set; }
        public bool IsRefreshing { get; set; }

        HttpClient _client;
        public bool IsLoading { get; set; }
        public string NameSearch { get; set; }
        public ICommand SearchCommand =>
        new Command(async () =>
        {
            var result = await _client.GetAsync("api/clientes");
            if (result.IsSuccessStatusCode)
            {
                
                var response = await result.Content.ReadAsStreamAsync();
                var clientes = (await JsonSerializer.DeserializeAsync<PagedDataResponse<ClienteViewModel>>(response, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }));
                Clientes.Clear();
                foreach (var cli in clientes.Items)
                    Clientes.Add(cli);
            }
        });

        public ClienteFindViewModel()
        {
            _client = HttpHelper.GetHttpClient(port:44340); 
        }

    }
}
