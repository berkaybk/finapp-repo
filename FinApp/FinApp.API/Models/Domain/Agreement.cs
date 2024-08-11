using System.ComponentModel;

namespace FinApp.API.Models.Domain
{
    public class Agreement : BaseModel
    {
        public Guid PartnerId { get; set; }

        public Guid RiskLevelId { get; set; }

        public required string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Amount { get; set; }

        public required string Keywords { get; set; }


        //Navigation properties

        public RiskLevel RiskLevel { get; set; }

        public Partner Partner { get; set; }

        public ICollection<Subject> Subjects { get; set; }

        public ICollection<RiskAnalysis> RiskAnalyses { get; set; }

        public ICollection<FinancialStatement> FinancialStatements { get; set; }
    }
}
