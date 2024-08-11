namespace FinApp.API.Models.Domain
{
    public class BaseModel
    {
        /// <summary>
        /// Id of table
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Record Create Date
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Created User
        /// </summary>
        public required string CreateUserName { get; set; }
        /// <summary>
        /// Last Update date of record
        /// </summary>
        public DateTime? LastUpdateDate { get; set; }
        /// <summary>
        /// Last update user
        /// </summary>
        public string? LastUpdateUserName { get; set; }

        /// <summary>
        /// Kayıt Durumu
        /// 0:Pasif 1:Aktif
        /// </summary>
        public int RecordStatus { get; set; }
    }
}
