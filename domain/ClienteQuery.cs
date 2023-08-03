using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class ClienteQuery : IClienteQuery
    {
        IBaseRepository<Clientes> _repositoryCliente;
        public ClienteQuery(IBaseRepository<Clientes> repositoryCliente)
        {
                _repositoryCliente = repositoryCliente;
        }
        public async Task<PagedDataResponse<Clientes>> PagedCliente(ClientePagedRequest clientePagedRequest)
        {
            var query = _repositoryCliente.RepositoryConsult.GetQueryable();
            return await query.PaginateAsync(clientePagedRequest,null);
        }
    }
}
