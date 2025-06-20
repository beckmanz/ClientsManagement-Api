using ClientsManagement_Api.Models.Dtos;
using ClientsManagement_Api.Models.Entity;

namespace ClientsManagement_Api.Services.Cliente;

public interface IClienteInterface
{
    Task<ResponseModel<ClienteModel>> RegistrarNovoCliente(NovoClienteDto ClienteDto);
    Task<ResponseModel<List<ClienteModel>>> ListarClientes();
}