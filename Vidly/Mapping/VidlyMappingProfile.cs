using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Mapping
{
    public class VidlyMappingProfile : Profile
    {
        public VidlyMappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Movie, MovieDto>();

            CreateMap<MembershipType, MembershipTypeDto>();

            CreateMap<Genre, GenreDto>();

            CreateMap<CustomerDto, Customer>()
                .ForMember(m => m.Id, opt => opt.Ignore());

            CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.Genre, opt => opt.Ignore());
        }
    }
}
