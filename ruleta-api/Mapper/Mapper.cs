using AutoMapper;
using ruleta_api.Models;
using ruleta_api.Models.DTO;

namespace ruleta_api.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Bet, BetDTO>().ReverseMap();
        }
    }
}
