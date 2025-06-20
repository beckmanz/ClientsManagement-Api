using AutoMapper;
using ClientsManagement_Api.Exceptions;
using ClientsManagement_Api.Models.Dtos;
using ClientsManagement_Api.Models.Entity;
using ClientsManagement_Api.Services.Cliente;
using Newtonsoft.Json;

namespace ClientsManagement_Api.Services.ViaCep;

public class ViaCepService :  IViaCepInterface
{
    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;

    public ViaCepService(HttpClient httpClient, IMapper mapper)
    {
        _httpClient = httpClient;
        _mapper = mapper;
    }
    public async Task<EnderecoModel> ConsutarCep(string cep)
    {
        var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var ViaCepResponse = JsonConvert.DeserializeObject<ViaCepResponseDto>(json);
            if (ViaCepResponse != null && string.IsNullOrEmpty(ViaCepResponse.Erro))
            {
                return _mapper.Map<EnderecoModel>(ViaCepResponse);
            }
        }
        return null;
    }
}