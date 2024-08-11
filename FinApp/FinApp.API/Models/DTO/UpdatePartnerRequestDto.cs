namespace FinApp.API.Models.DTO {
    public class UpdatePartnerRequestDto {
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
    }
}
