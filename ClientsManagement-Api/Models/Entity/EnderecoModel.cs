using System.Text.Json.Serialization;

namespace ClientsManagement_Api.Models.Entity;

public class EnderecoModel
{
    public int Id { get; set; }
    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public string Cidade { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public int ClienteId { get; set; }
    [JsonIgnore]
    public ClienteModel Cliente { get; set; }
}