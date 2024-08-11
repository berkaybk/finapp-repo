namespace FinApp.API.Models.DTO {
    public class AddSubjectRequestDto {
        public Guid AgreementId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public decimal Cost { get; set; }
    }
}
