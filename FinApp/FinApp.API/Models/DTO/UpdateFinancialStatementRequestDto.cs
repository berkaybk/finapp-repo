namespace FinApp.API.Models.DTO {
    public class UpdateFinancialStatementRequestDto {
        public decimal Revenue { get; set; }
        public decimal Expenses { get; set; }
        public decimal NetIncome { get; set; }
    }
}
