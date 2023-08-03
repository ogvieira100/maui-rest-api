using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public interface IClienteQuery
    {

        Task<PagedDataResponse<Clientes>> PagedCliente(ClientePagedRequest clientePagedRequest);
    }
}
