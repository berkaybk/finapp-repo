namespace FinApp.API.Models.DTO {
    public class RiskLevelDto {
        /// <summary>
        /// Id of table
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Risk Adı Low,Medium,High
        /// </summary>
        public string Name { get; set; }
    }
}
