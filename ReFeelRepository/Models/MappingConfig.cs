using AutoMapper;
using ReFeelRepository.Models.DTo.Entities;
using ReFeelRepository.Models.Entitites;


namespace ReFeelRepository.Models
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            //CreateMap<LoginReponseDTO, UserDTo>();
            //CreateMap<UserDTo, LoginReponseDTO>();

            CreateMap<UserDTo, UserCreateDTo>().ReverseMap();
            CreateMap<UserDTo, UserCreateDTo>().ReverseMap();
        }
    }
}
