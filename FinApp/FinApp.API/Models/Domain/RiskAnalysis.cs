using FinApp.API.Models.DTO;

namespace FinApp.API.Models.Domain
{
    public class RiskAnalysis : BaseDto
    {
        public Guid AgreementId { get; set; }
        public decimal RiskScore { get; set; }
        public string? Comments { get; set; }

        //Navigation Properties
        public Agreement Agreement { get; set; }

    }
}
