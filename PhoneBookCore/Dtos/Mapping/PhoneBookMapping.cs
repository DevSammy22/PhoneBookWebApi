using AutoMapper;
using PhoneBookCore.Dtos.Request;
using PhoneBookCore.Dtos.Response;
using PhoneBookInfrastructure.Models;

namespace PhoneBookCore.Dtos.Mapping
{
    public class PhoneBookMapping : Profile
    {
        public PhoneBookMapping()
        {
            CreateMap<Entry, EntryRequestDto>().ReverseMap();
            CreateMap<Entry, EntryResponseDto>().ReverseMap();
            CreateMap<PhoneBookDto, PhoneBook>()
                .ForMember(y => y.Entries, y => y.MapFrom(s => s.Entries)).ReverseMap();
        }
    }
}
