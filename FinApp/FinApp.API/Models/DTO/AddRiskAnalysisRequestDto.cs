namespace FinApp.API.Models.DTO {
    public class AddRiskAnalysisRequestDto {
        public Guid AgreementId { get; set; }
        public decimal RiskScore { get; set; }
        public string? Comments { get; set; }
    }
}
