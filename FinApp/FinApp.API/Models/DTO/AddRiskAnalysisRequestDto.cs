using System.ComponentModel.DataAnnotations;

namespace FinApp.API.Models.DTO {
    public class AddRiskAnalysisRequestDto {
        [Required]
        public Guid AgreementId { get; set; }
        [Required]
        public decimal RiskScore { get; set; }
        public string? Comments { get; set; }
    }
}
