namespace FinApp.UI.Models.DTO {
    public class SubjectDto : BaseDto {
        public Guid AgreementId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public decimal Cost { get; set; }
    }
}
