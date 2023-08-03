using data;
using domain;
using MediatR;


namespace mongo_api.Models.Cliente
{
    public class ClienteHandler
                : IRequestHandler<ClienteInserirCommand, ClienteResponse>,
                  IRequestHandler<ClienteAtualizarCommand, ClienteResponse>,
                  IRequestHandler<ClienteDeletarCommand, ClienteResponse>

    {

        readonly IUnitOfWork _unitOfWork;
        readonly IBaseRepository<Clientes> _clienteRepository;



        public ClienteHandler(IUnitOfWork unitOfWork,
                             IClienteQuery clienteQuery,
                             IBaseRepository<Clientes> clienteRepository)
        {
            _unitOfWork = unitOfWork;
            _clienteRepository = clienteRepository;
        }
        public async Task<ClienteResponse> Handle(ClienteInserirCommand request,
                                                 CancellationToken cancellationToken)
        {
            var resp = new ClienteResponse();

            var novoCliente = new Clientes();
            novoCliente.CPF = request.CPF;
            novoCliente.Nome = request.Nome;
            novoCliente.Endereco = request.Endereco;

            await _clienteRepository.AddAsync(novoCliente);
            await _unitOfWork.CommitAsync();
            return resp;
        }

        public async Task<ClienteResponse> Handle(ClienteAtualizarCommand request,
            CancellationToken cancellationToken)
        {
            var cliAtualizar = (await _clienteRepository.RepositoryConsult.SearchAsync(x => x.Id == request.Id))?.FirstOrDefault();
            var resp = new ClienteResponse();
            if (cliAtualizar is not null)
            {
                cliAtualizar.CPF = request.CPF;
                cliAtualizar.Nome = request.Nome;
                cliAtualizar.Endereco = request.Endereco;
            }
            await _unitOfWork.CommitAsync();
            return resp;
        }

        public async Task<ClienteResponse> Handle(ClienteDeletarCommand request,
                                                  CancellationToken cancellationToken)
        {
            var cliDeletar = (await _clienteRepository.RepositoryConsult.SearchAsync(x => x.Id == request.Id))?.FirstOrDefault();
            var resp = new ClienteResponse();
            if (cliDeletar is not null)
            {
                _clienteRepository.Remove(cliDeletar);
                /*atualizando as informações*/
                await _unitOfWork.CommitAsync();
            }

            return resp;

        }
    }
}
