﻿using maui_project_rest.MVVM.Model;
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
    public class ClienteEditViewModel
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
            var clienteViewModelSend = new ClienteRestPut
            {
                CPF = CPF,
                Nome = Nome,
                Endereco = Endereco,
                Id = Id 
            };

            var _serializerOptions = new JsonSerializerOptions { WriteIndented = true };
            var serialize = JsonSerializer.Serialize(clienteViewModelSend, _serializerOptions);
            StringContent content = new StringContent(serialize, encoding: Encoding.UTF8, "application/json");
            IsLoading = true;
            var resp = await _client.PutAsync("api/clientes", content);
            if (resp.IsSuccessStatusCode)
            {

                
            }
            IsLoading = false;
        }

        public ClienteEditViewModel()
        {
            _client = HttpHelper.GetHttpClient(port: 44340);
        }

    }
}
