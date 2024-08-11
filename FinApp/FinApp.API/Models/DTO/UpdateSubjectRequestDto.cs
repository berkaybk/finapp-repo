using System.ComponentModel.DataAnnotations;

namespace FinApp.API.Models.DTO {
    public class UpdateSubjectRequestDto {
        [Required]
        [MinLength(3, ErrorMessage = "Minumum length is 3 charecters.")]
        [MaxLength(100, ErrorMessage = "Maximum length is 100 charecters.")]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public decimal Cost { get; set; }
    }
}
