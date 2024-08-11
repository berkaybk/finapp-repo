namespace FinApp.UI.Models.DTO {
    public class AgreementDto : BaseDto {
        public Guid PartnerId { get; set; }

        public Guid RiskLevelId { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Amount { get; set; }

        public string Keywords { get; set; }

        //public RiskLevelDto RiskLevel { get; set; }

        //public PartnerDto Partner { get; set; }

        //public ICollection<SubjectDto> Subjects { get; set; }

        //public ICollection<RiskAnalysisDto> RiskAnalyses { get; set; }

        //public ICollection<FinancialStatementDto> FinancialStatements { get; set; }
    }
}
