using domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using mongo_api.Models.Cliente;

namespace api.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : Controller
    {


        private readonly IMediator _mediator;
        readonly IClienteQuery _clienteQuery;
        public ClientesController(IMediator mediator, IClienteQuery clienteQuery)
        {
            _mediator = mediator;   
            _clienteQuery = clienteQuery;   
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
            => Ok(await _mediator.Send(new ClienteDeletarCommand { Id = id }));


        /// <summary>
        /// Get List By mongo DB
        /// </summary>
        /// <param name="clientePagedRequest"></param>
        /// <returns></returns>
        [HttpGet]

        public async Task<IActionResult> Get([FromQuery] ClientePagedRequest clientePagedRequest)
        {
            return Ok(await _clienteQuery.PagedCliente(clientePagedRequest));

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clienteSalvarRequest"></param>
        /// <returns></returns>
        [HttpPost]

        public async Task<IActionResult> Post([FromBody] ClienteInserirCommand clienteSalvarRequest)
        {
            var resp = await _mediator.Send(clienteSalvarRequest);
            return Ok(resp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clienteAtualizarCommand"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ClienteAtualizarCommand clienteAtualizarCommand)
        {
            var resp = await _mediator.Send(clienteAtualizarCommand);
            return Ok(resp);
        }
    }
}
