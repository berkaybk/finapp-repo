using System.ComponentModel.DataAnnotations;

namespace FinApp.API.Models.DTO {
    public class UpdateRiskAnalysisRequestDto {
        [Required]
        public decimal RiskScore { get; set; }
        public string? Comments { get; set; }
    }
}
