using System.ComponentModel.DataAnnotations;

namespace FinApp.API.Models.DTO {
    public class AddAgreementRequestDto {

        [Required]
        public Guid PartnerId { get; set; }
        [Required]
        public Guid RiskLevelId { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Minumum length is 3 characters.")]
        [MaxLength(100, ErrorMessage = "Maximum length is 100 characters.")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Minumum length is 2 characters.")]
        [MaxLength(100, ErrorMessage = "Maximum length is 50 characters.")]
        public string Keywords { get; set; }
    }
}
