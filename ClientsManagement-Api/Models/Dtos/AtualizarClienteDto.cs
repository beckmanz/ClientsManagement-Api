namespace ClientsManagement_Api.Models.Dtos;

public class AtualizarClienteDto
{
    public string? Nome { get; set; }
    public NovoContatoDto? Contato { get; set; }
    public NovoEnderecoDto? Endereco { get; set; }
}