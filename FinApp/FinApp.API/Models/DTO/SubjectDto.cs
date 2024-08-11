using FinApp.API.Models.Domain;

namespace FinApp.API.Models.DTO {
    public class SubjectDto : BaseDto {

        public Guid AgreementId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public decimal Cost { get; set; }

        //Navigation properties

        public AgreementDto Agreement { get; set; }
    }
}
