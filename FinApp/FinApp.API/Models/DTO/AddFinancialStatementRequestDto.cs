using System.ComponentModel.DataAnnotations;

namespace FinApp.API.Models.DTO {
    public class AddFinancialStatementRequestDto {
        [Required]
        public Guid AgreementId { get; set; }
        [Required]
        public decimal Revenue { get; set; }
        [Required]
        public decimal Expenses { get; set; }
        [Required]
        public decimal NetIncome { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Minumum length is 2 characters.")]
        public string CreateUserName { get; set; }
    }
}
