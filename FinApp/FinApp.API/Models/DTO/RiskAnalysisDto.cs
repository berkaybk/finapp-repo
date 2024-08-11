using FinApp.API.Models.Domain;

namespace FinApp.API.Models.DTO {
    public class RiskAnalysisDto : BaseDto {
        public Guid AgreementId { get; set; }
        public decimal RiskScore { get; set; }
        public string? Comments { get; set; }

        //Navigation Properties
        public AgreementDto Agreement { get; set; }

    }
}
