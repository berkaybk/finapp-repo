using System.ComponentModel.DataAnnotations;

namespace FinApp.API.Models.DTO {
    public class AddPartnerRequestDto {
        /// <summary>
        /// Name of partner
        /// </summary>
        [Required]
        [MinLength(3, ErrorMessage = "Minumum length is 3 characters.")]
        [MaxLength(100, ErrorMessage = "Maximum length is 100 characters.")]
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
        public DateTime CreateDate { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Minumum length is 2 characters.")]
        public string CreateUserName { get; set; }
    }
}
