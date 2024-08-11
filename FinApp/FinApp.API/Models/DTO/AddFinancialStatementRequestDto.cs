namespace FinApp.API.Models.DTO {
    public class AddFinancialStatementRequestDto {
        public Guid AgreementId { get; set; }
        public decimal Revenue { get; set; }
        public decimal Expenses { get; set; }
        public decimal NetIncome { get; set; }
    }
}
