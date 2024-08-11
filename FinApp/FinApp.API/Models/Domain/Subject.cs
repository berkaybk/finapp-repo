namespace FinApp.API.Models.Domain
{
    public class Subject : BaseModel
    {

        public Guid AgreementId { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public decimal Cost { get; set; }

        //Navigation properties

        public Agreement Agreement { get; set; }
    }
}
