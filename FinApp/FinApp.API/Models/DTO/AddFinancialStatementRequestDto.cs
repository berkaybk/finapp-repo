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
    }
}
