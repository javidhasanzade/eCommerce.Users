using AutoMapper;
using eCommerce.Users.Core.Dtos;
using eCommerce.Users.Core.Entities;

namespace eCommerce.Users.Core.Mappers;

public class ApplicationUserMappingProfile : Profile
{
    public ApplicationUserMappingProfile()
    {
        CreateMap<ApplicationUser, AuthenticationResponse>()
            .ForMember(dest => dest.UserId,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Gender,
                opt => opt.Ignore())
            .ForMember(dest => dest.Token,
                opt => opt.Ignore());

        CreateMap<RegisterRequest, ApplicationUser>();
    }
}