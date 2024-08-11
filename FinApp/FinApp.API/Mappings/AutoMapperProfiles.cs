using AutoMapper;
using FinApp.API.Models.Domain;
using FinApp.API.Models.DTO;

namespace FinApp.API.Mappings {
    public class AutoMapperProfiles : Profile {
        public AutoMapperProfiles() {
            CreateMap<Agreement, AgreementDto>().ReverseMap();
        }
    }
}
