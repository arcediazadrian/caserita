using AutoMapper;
using Caserita_Domain.Entities;

namespace Caserita_Presentation.MappingProfiles
{
    public class CaseritaMappingProfile : Profile
    {
        public CaseritaMappingProfile()
        {
            CreateMap<DTOs.Input.UserDto, User>()
                .ForMember(dest => dest.UserSettings, opt => opt.MapFrom((src) =>
                    src.SettingIds == null ?
                        new List<UserSetting>() :
                        src.SettingIds.Select(sid => new UserSetting { SettingId = sid })
                ));

            CreateMap<User, DTOs.Output.UserDto>();

            CreateMap<DTOs.Input.SettingDto, Setting>();
            CreateMap<Setting, DTOs.Output.SettingDto>();
        }
    }
}
