namespace FinApp.API.Models.DTO {
    public class AddAgreementRequestDto {

        public Guid PartnerId { get; set; }
        public Guid RiskLevelId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Amount { get; set; }
        public string Keywords { get; set; }
    }
}
