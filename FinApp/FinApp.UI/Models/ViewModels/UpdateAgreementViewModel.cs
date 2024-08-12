using System.ComponentModel.DataAnnotations;

namespace FinApp.UI.Models.ViewModels {
    public class UpdateAgreementViewModel : AddAgreementViewModel {
        /// <summary>
        /// Id of table
        /// </summary>
        [Required]
        public Guid Id { get; set; }
        public int RecordStatus { get; set; }
    }
}
