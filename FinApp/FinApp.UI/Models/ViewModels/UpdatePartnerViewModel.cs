namespace FinApp.UI.Models.ViewModels
{
    public class UpdatePartnerViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
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
