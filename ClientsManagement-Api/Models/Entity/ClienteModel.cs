namespace ClientsManagement_Api.Models.Entity;

public class ClienteModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.Now;
    public ContatoModel Contato { get; set; }
    public EnderecoModel Endereco { get; set; }
}