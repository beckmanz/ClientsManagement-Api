using ClientsManagement_Api.Models.Dtos;
using ClientsManagement_Api.Models.Entity;

namespace ClientsManagement_Api.Services.Cliente;

public interface IClienteInterface
{
    Task<ResponseModel<ClienteModel>> RegistrarNovoCliente(NovoClienteDto ClienteDto);
    Task<ResponseModel<List<ClienteModel>>> ListarClientes();
    Task<ResponseModel<ClienteModel>> ObterClientePorId(int Id);
    Task<ResponseModel<List<ClienteModel>>> ObterClientePorNome(string nome);
    Task<ResponseModel<ClienteModel>> AtualizarCliente(int Id, AtualizarClienteDto ClienteDto);
    Task<ResponseModel<ClienteModel>> DeletarCliente(int Id);
}