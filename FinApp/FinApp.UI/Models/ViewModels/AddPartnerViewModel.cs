using System.ComponentModel.DataAnnotations;

namespace FinApp.UI.Models.ViewModels
{
    public class AddPartnerViewModel
    {
        [Required]
        [MinLength(3, ErrorMessage = "Minumum length is 3 characters.")]
        [MaxLength(100, ErrorMessage = "Maximum length is 100 characters.")]
        public string Name { get; set; }
        /// <summary>
        /// Mail adress of partner
        /// </summary>
        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [MinLength(6, ErrorMessage = "Maximum length is 6 characters.")]
        [MaxLength(100, ErrorMessage = "Maximum length is 100 characters.")]
        public string Email { get; set; }
        /// <summary>
        /// Phone number
        /// </summary>
        [Required]
        [Phone]
        [MaxLength(14, ErrorMessage = "Maximum length is 14 characters.")]
        public string Phone { get; set; }

    }
}
