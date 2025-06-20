using ClientsManagement_Api.Models.Dtos;
using ClientsManagement_Api.Models.Entity;
using ClientsManagement_Api.Services.Cliente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientsManagement_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteInterface _clienteInterface;

        public ClienteController(IClienteInterface clienteInterface)
        {
            _clienteInterface = clienteInterface;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<ClienteModel>>> RegistrarNovoCliente(NovoClienteDto ClienteDto)
        {
            var response = await _clienteInterface.RegistrarNovoCliente(ClienteDto);
            return response;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<ClienteModel>>>> ListarClientes()
        {
            var response = await _clienteInterface.ListarClientes();
            return response;
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<ResponseModel<ClienteModel>>> ObterClientePorId(int Id)
        {
            var response = await _clienteInterface.ObterClientePorId(Id);
            return response;
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<ResponseModel<ClienteModel>>> AtualizarCliente(int Id, AtualizarClienteDto ClienteDto)
        {
            var response = await _clienteInterface.AtualizarCliente(Id, ClienteDto);
            return response;
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<ResponseModel<ClienteModel>>> DeletarCliente(int Id)
        {
            var response = await _clienteInterface.DeletarCliente(Id);
            return response;
        }
    }
}
