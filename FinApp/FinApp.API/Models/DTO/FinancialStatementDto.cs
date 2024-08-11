using FinApp.API.Models.Domain;

namespace FinApp.API.Models.DTO {
    public class FinancialStatementDto : BaseDto {
        public Guid AgreementId { get; set; }
        public decimal Revenue { get; set; }
        public decimal Expenses { get; set; }
        public decimal NetIncome { get; set; }

        //Navigation properties

        public AgreementDto Agreement { get; set; }
    }
}
