namespace ClientsManagement_Api.Models.Dtos;

public class ViaCepResponseDto
{
    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public string Localidade { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Erro { get; set; }
}