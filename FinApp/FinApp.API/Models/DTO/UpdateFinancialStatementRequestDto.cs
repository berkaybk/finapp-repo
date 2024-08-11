using System.ComponentModel.DataAnnotations;

namespace FinApp.API.Models.DTO {
    public class UpdateFinancialStatementRequestDto {
        [Required]
        public decimal Revenue { get; set; }
        [Required]
        public decimal Expenses { get; set; }
        [Required]
        public decimal NetIncome { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? LastUpdateDate { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Minumum length is 2 charecters.")]
        public string? LastUpdateUserName { get; set; }
        public int RecordStatus { get; set; }
    }
}
