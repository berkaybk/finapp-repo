using System.ComponentModel.DataAnnotations;

namespace FinApp.API.Models.DTO {
    public class UpdateRiskAnalysisRequestDto {
        [Required]
        public decimal RiskScore { get; set; }
        public string? Comments { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? LastUpdateDate { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Minumum length is 2 charecters.")]
        public string? LastUpdateUserName { get; set; }
        public int RecordStatus { get; set; }
    }
}
