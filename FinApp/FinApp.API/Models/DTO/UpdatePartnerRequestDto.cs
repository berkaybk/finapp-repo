using System.ComponentModel.DataAnnotations;

namespace FinApp.API.Models.DTO {
    public class UpdatePartnerRequestDto {
        /// <summary>
        /// Name of partner
        /// </summary>
        [Required]
        [MinLength(3, ErrorMessage = "Minumum length is 3 charecters.")]
        [MaxLength(100, ErrorMessage = "Maximum length is 100 charecters.")]
        public string Name { get; set; }
        /// <summary>
        /// Mail adress of partner
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        /// <summary>
        /// Phone number
        /// </summary>
        [Required]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? LastUpdateDate { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Minumum length is 2 charecters.")]
        public string? LastUpdateUserName { get; set; }
        public int RecordStatus { get; set; }
    }
}
