namespace FinApp.API.Models.DTO {
    public class UpdateRiskAnalysisRequestDto {
        public decimal RiskScore { get; set; }
        public string? Comments { get; set; }
    }
}
