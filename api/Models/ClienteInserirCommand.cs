using MediatR;

namespace mongo_api.Models.Cliente
{
    public class ClienteInserirCommand : IRequest<ClienteResponse>
    {
        public string CPF { get; set; } = "";
        public string? Nome { get; set; } = "";
        public string Endereco { get; set; }


        public ClienteInserirCommand()
        {
            
        }

    }
}
