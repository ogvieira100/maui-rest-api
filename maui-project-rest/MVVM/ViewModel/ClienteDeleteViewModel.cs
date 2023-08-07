using maui_project_rest.Util;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace maui_project_rest.MVVM.ViewModel
{

    [AddINotifyPropertyChangedInterface]
    public class ClienteDeleteViewModel
    {

        public Guid Id { get; set; }

        public string CPF { get; set; }

        public string Nome { get; set; }

        public string Endereco { get; set; }

        public bool IsLoading { get; set; } = false;

        HttpClient _client;

        public ICommand Salvar => new Command(async () =>
        {
            await AtualizarCliente();
        });

        public async Task AtualizarCliente()
        {
            IsLoading = true;
            var resp = await _client.DeleteAsync("api/clientes");
            if (resp.IsSuccessStatusCode)
            {


            }
            IsLoading = false;
        }

        public ClienteDeleteViewModel()
        {
            _client = HttpHelper.GetHttpClient(port: 44340);
        }
    }
}
