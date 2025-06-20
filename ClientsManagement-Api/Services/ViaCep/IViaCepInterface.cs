using ClientsManagement_Api.Models.Entity;

namespace ClientsManagement_Api.Services.Cliente;

public interface IViaCepInterface
{
    Task<EnderecoModel> ConsutarCep(string cep);
}