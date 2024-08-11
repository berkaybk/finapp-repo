using AutoMapper;
using FinApp.API.Models.Domain;
using FinApp.API.Models.DTO;

namespace FinApp.API.Mappings {
    public class AutoMapperProfiles : Profile {
        public AutoMapperProfiles() {
            CreateMap<Agreement, AgreementDto>().ReverseMap();
            CreateMap<Agreement, AddAgreementRequestDto>().ReverseMap();
            CreateMap<Agreement, UpdateAgreementRequestDto>().ReverseMap();

            CreateMap<FinancialStatement, FinancialStatementDto>().ReverseMap();
            CreateMap<FinancialStatement, AddFinancialStatementRequestDto>().ReverseMap();
            CreateMap<FinancialStatement, UpdateFinancialStatementRequestDto>().ReverseMap();

            CreateMap<Partner, PartnerDto>().ReverseMap();
            CreateMap<Partner, AddPartnerRequestDto>().ReverseMap();
            CreateMap<Partner, UpdatePartnerRequestDto>().ReverseMap();

            CreateMap<RiskAnalysis, RiskAnalysisDto>().ReverseMap();
            CreateMap<RiskAnalysis, AddRiskAnalysisRequestDto>().ReverseMap();
            CreateMap<RiskAnalysis, UpdateRiskAnalysisRequestDto>().ReverseMap();

            CreateMap<Subject, SubjectDto>().ReverseMap();
            CreateMap<Subject, AddSubjectRequestDto>().ReverseMap();
            CreateMap<Subject, UpdateSubjectRequestDto>().ReverseMap();

            CreateMap<RiskLevel, RiskLevelDto>().ReverseMap();
        }
    }
}
