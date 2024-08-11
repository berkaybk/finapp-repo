namespace FinApp.API.Models.Domain
{
    public class RiskLevel
    {
        /// <summary>
        /// Id of table
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Risk Adı Low,Medium,High
        /// </summary>
        public required string Name { get; set; }
    }
}
