using ClientsManagement_Api.Data;
using ClientsManagement_Api.Exceptions;
using ClientsManagement_Api.Models.Dtos;
using ClientsManagement_Api.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace ClientsManagement_Api.Services.Cliente;

public class ClienteService : IClienteInterface
{
    private readonly AppDbContext _context;
    private readonly IViaCepInterface _viaCepInterface;

    public ClienteService(AppDbContext context, IViaCepInterface viaCepInterface)
    {
        _context = context;
        _viaCepInterface = viaCepInterface;
    }
    public async Task<ResponseModel<ClienteModel>> RegistrarNovoCliente(NovoClienteDto ClienteDto)
    {
        ResponseModel<ClienteModel> response = new ResponseModel<ClienteModel>();
        var Endereco = await _viaCepInterface.ConsutarCep(ClienteDto.Endereco.Cep);
        if (Endereco is null)
        {
            throw new BadRequestException("CEP inválido.");
        }
        var novoCliente = new ClienteModel
        {
            Nome = ClienteDto.Nome
        };
        var Contato = new ContatoModel
        {
            Tipo = ClienteDto.Contato.Tipo,
            Texto = ClienteDto.Contato.Texto,
            Cliente = novoCliente,
            ClienteId = novoCliente.Id,
        };
        Endereco.Cliente = novoCliente;
        Endereco.ClienteId = novoCliente.Id;
        Endereco.Numero = ClienteDto.Endereco.Numero;
        Endereco.Complemento = ClienteDto.Endereco.Complemento;
        novoCliente.Endereco = Endereco;
        novoCliente.Contato = Contato;
            
        await _context.Clientes.AddAsync(novoCliente);
        await _context.SaveChangesAsync();
        response.Data = novoCliente;
        response.Message = "Cliente registrado com sucesso!";
        response.Success = true;
        return response;
    }
    public async Task<ResponseModel<List<ClienteModel>>> ListarClientes()
    {
        ResponseModel<List<ClienteModel>> response = new ResponseModel<List<ClienteModel>>();
        var Clientes = await _context.Clientes
                .AsNoTracking()
                .Include(c => c.Contato)
                .Include(c => c.Endereco)
                .ToListAsync();
        
        response.Data = Clientes;
        response.Message = "Clientes listado com sucesso!";
        response.Success = true;
        return response;
        
    }
    public async Task<ResponseModel<ClienteModel>> ObterClientePorId(int Id)
    {
        ResponseModel<ClienteModel> response = new ResponseModel<ClienteModel>();
        var Cliente = await _context.Clientes
            .AsNoTracking()
            .Include(c => c.Contato)
            .Include(c => c.Endereco)
            .FirstOrDefaultAsync(c => c.Id == Id);
        if (Cliente is null)
        {
            throw new NotFoundException("Cliente não encontrado.");
        }
        response.Data = Cliente;
        response.Message = "Cliente encontrado com sucesso!";
        response.Success = true;
        return response;
    }
    public async Task<ResponseModel<List<ClienteModel>>> ObterClientePorNome(string nome)
    {
        ResponseModel<List<ClienteModel>> response = new ResponseModel<List<ClienteModel>>();
        var Clientes = await _context.Clientes
            .AsNoTracking()
            .Include(c => c.Contato)
            .Include(c => c.Endereco)
            .Where(c => c.Nome.ToLower().Contains(nome.ToLower()))
            .ToListAsync();
        response.Data = Clientes;
        response.Message = "Clientes encontrado com sucesso!";
        response.Success = true;
        return response;
    }
    public async Task<ResponseModel<ClienteModel>> AtualizarCliente(int Id, AtualizarClienteDto ClienteDto)
    {
        ResponseModel<ClienteModel> response = new ResponseModel<ClienteModel>();
        var Cliente = await _context.Clientes
            .Include(c => c.Contato)
            .Include(c => c.Endereco)
            .FirstOrDefaultAsync(c => c.Id == Id);
        if (Cliente is null)
        {
            throw new NotFoundException("Cliente não encontrado.");
        }
        if (ClienteDto.Nome is not null)
            Cliente.Nome = ClienteDto.Nome;
        if (ClienteDto.Endereco is not null)
        {
            var enderecoApi = await _viaCepInterface.ConsutarCep(ClienteDto.Endereco.Cep);

            if (enderecoApi is null)
            {
                throw new BadRequestException("CEP inválido");
            }

            Cliente.Endereco.Cep = enderecoApi.Cep;
            Cliente.Endereco.Logradouro = enderecoApi.Logradouro;
            Cliente.Endereco.Cidade = enderecoApi.Cidade;
            Cliente.Endereco.Numero = ClienteDto.Endereco.Numero;
            Cliente.Endereco.Complemento = ClienteDto.Endereco.Complemento;
        }

        if (ClienteDto.Contato is not null)
        {
            Cliente.Contato.Tipo = ClienteDto.Contato.Tipo;
            Cliente.Contato.Texto = ClienteDto.Contato.Texto;
        }
        await _context.SaveChangesAsync();
        
        response.Data = Cliente;
        response.Message = "Cliente atualizado com sucesso!";
        response.Success = true;
        return response;
    }
    public async Task<ResponseModel<ClienteModel>> DeletarCliente(int Id)
    {
        ResponseModel<ClienteModel> response = new ResponseModel<ClienteModel>();
        var Cliente = _context.Clientes.FirstOrDefault(c => c.Id == Id);
        if (Cliente is null)
        {
            throw new NotFoundException("Cliente não encontrado.");
        }
        _context.Remove(Cliente);
        await _context.SaveChangesAsync();
        response.Message = "Cliente deletado com sucesso!";
        response.Success = true;
        return response;
    }
}