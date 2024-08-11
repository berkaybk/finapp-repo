namespace FinApp.API.Models.Domain
{
    public class Partner : BaseModel
    {
        /// <summary>
        /// Name of partner
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// Mail adress of partner
        /// </summary>
        public required string Email { get; set; }
        /// <summary>
        /// Phone number
        /// </summary>
        public required string Phone { get; set; }

        //Navigation properties

        public ICollection<Agreement> Agreements { get; set; }
    }
}
