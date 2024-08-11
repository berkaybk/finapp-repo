using System.ComponentModel.DataAnnotations;

namespace FinApp.API.Models.DTO {
    public class AddRiskAnalysisRequestDto {
        [Required]
        public Guid AgreementId { get; set; }
        [Required]
        public decimal RiskScore { get; set; }
        public string? Comments { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Minumum length is 2 characters.")]
        public string CreateUserName { get; set; }
    }
}
