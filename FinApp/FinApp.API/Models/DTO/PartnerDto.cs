using FinApp.API.Models.Domain;

namespace FinApp.API.Models.DTO {
    public class PartnerDto : BaseDto {
        /// <summary>
        /// Name of partner
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Mail adress of partner
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Phone number
        /// </summary>
        public string Phone { get; set; }

        //Navigation properties

        public ICollection<AgreementDto> Agreements { get; set; }
    }
}
