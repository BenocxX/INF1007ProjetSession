using AutoMapper;
using ProjetSessionBackend.Core.Models.DTOs.ClientBillingInfo;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Core.MapperProfiles;

public class ClientBillingInfoProfile : Profile
{
    public ClientBillingInfoProfile()
    {
        CreateMap<CreateClientBillingInfoRequest, ClientBillingInfo>();
        CreateMap<ClientBillingInfo, ClientBillingInfoResponse>();
    }
}