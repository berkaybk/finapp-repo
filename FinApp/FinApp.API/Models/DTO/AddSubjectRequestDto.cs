using System.ComponentModel.DataAnnotations;

namespace FinApp.API.Models.DTO {
    public class AddSubjectRequestDto {
        [Required]
        public Guid AgreementId { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Minumum length is 3 characters.")]
        [MaxLength(100, ErrorMessage = "Maximum length is 100 characters.")]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public decimal Cost { get; set; }
    }
}
