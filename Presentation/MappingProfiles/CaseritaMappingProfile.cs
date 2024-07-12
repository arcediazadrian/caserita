using AutoMapper;
using Caserita_Domain.Entities;

namespace Caserita_Presentation.MappingProfiles
{
    public class CaseritaMappingProfile : Profile
    {
        public CaseritaMappingProfile()
        {
            CreateMap<DTOs.Input.UserDto, User>()
                .ForMember(dest => dest.Settings, opt => opt.MapFrom((src) =>
                    src.SettingIds == null ?
                        new List<Setting>() :
                        src.SettingIds.Select(sid => new Setting { Id = sid })
                ));

            CreateMap<User, DTOs.Output.UserDto>();

            CreateMap<DTOs.Input.SettingDto, Setting>();
            CreateMap<Setting, DTOs.Output.SettingDto>();
        }
    }
}
