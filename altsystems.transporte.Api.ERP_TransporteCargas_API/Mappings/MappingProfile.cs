using altsystems.transporte.Api.ERP_TransporteCargas_API.DTOs;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using AutoMapper;

namespace altsystems.transporte.Api.ERP_TransporteCargas_API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DadosGeraisDTO, DadosGerais>().ReverseMap();
            CreateMap<ClienteCnpjDTO, ClienteCnpj>().ReverseMap();           
            CreateMap<InscricaoEstadualDTO, InscricaoEstadual>();
            CreateMap<InscricaoEstadual, InscricaoEstadualDTO>();
            CreateMap<VeiculoDTO, Veiculo>().ReverseMap();
            CreateMap<MotoristaDTO, Motorista>().ReverseMap();


        }
    }
}
