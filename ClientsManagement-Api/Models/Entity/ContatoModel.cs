using System.Text.Json.Serialization;

namespace ClientsManagement_Api.Models.Entity;

public class ContatoModel
{
    public int Id { get; set; }
    public string Tipo { get; set; }
    public string Texto { get; set; }
    public int ClienteId { get; set; }
    [JsonIgnore]
    public ClienteModel Cliente { get; set; }
}
