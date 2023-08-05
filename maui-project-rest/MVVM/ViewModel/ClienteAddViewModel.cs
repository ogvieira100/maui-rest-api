using maui_project_rest.MVVM.Model;
using maui_project_rest.Util;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Input;

namespace maui_project_rest.MVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class ClienteAddViewModel
    {

        public string CPF { get; set; }

        public string Nome { get; set; }

        public bool IsLoading { get; set; }  = false;

        public string Endereco { get; set; }

        HttpClient _client;
        public ClienteAddViewModel()
        {
            _client = HttpHelper.GetHttpClient(port: 44340);

        }

        public ICommand Salvar => new Command(async () =>
        {
            await SalvarCliente();
        });

        public async Task SalvarCliente()
        {
            var clienteViewModelSend = new ClienteRestPost
            {
                CPF = CPF,
                Nome = Nome,
                Endereco = Endereco
            };

            var _serializerOptions = new JsonSerializerOptions { WriteIndented = true };
            var serialize = JsonSerializer.Serialize(clienteViewModelSend, _serializerOptions);
            StringContent content = new StringContent(serialize, encoding: Encoding.UTF8, "application/json");
            IsLoading = true;
            var resp = await _client.PostAsync("api/clientes", content);
            if (resp.IsSuccessStatusCode)
            {


                CPF = "";
                Nome = "";
                Endereco = "";

            }
            IsLoading = false;
        }
    }
}
