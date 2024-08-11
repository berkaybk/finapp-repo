namespace FinApp.API.Models.Domain
{
    public class FinancialStatement : BaseModel
    {
        public Guid AgreementId { get; set; }
        public decimal Revenue { get; set; }
        public decimal Expenses { get; set; }
        public decimal NetIncome { get; set; }

        //Navigation properties

        public Agreement Agreement { get; set; }
    }
}
