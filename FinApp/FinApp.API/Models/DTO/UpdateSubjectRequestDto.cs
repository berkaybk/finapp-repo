namespace FinApp.API.Models.DTO {
    public class UpdateSubjectRequestDto {
        public string Name { get; set; }

        public string? Description { get; set; }

        public decimal Cost { get; set; }
    }
}
