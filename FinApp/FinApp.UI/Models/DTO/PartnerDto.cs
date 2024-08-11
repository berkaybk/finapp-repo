namespace FinApp.UI.Models.DTO {
    public class PartnerDto : BaseDto {
        public string Name { get; set; }
        /// <summary>
        /// Mail adress of partner
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Phone number
        /// </summary>
        public string Phone { get; set; }
    }
}
