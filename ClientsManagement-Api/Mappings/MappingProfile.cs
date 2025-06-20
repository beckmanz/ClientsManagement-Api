using AutoMapper;
using ClientsManagement_Api.Models.Dtos;
using ClientsManagement_Api.Models.Entity;

namespace ClientsManagement_Api.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ViaCepResponseDto, EnderecoModel>()
            .ForMember(dest => dest.Cidade, m => m.MapFrom(orig => orig.Localidade))
            .ForMember(dest => dest.Cliente, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}