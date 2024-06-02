using AutoMapper;
using DebtMaster.Models.Domain;
using DebtMaster.Models.DTOs;

namespace DebtMaster.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Debt, AddDebtRequestDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();  
            CreateMap<User,UserDto>().ReverseMap();
            
        }
    }
}
