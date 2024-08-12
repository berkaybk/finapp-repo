using FinApp.UI.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace FinApp.UI.Models.ViewModels {
    public class AgreementViewModel {
        public AddAgreementViewModel Agreement { get; set; }
        
        public IEnumerable<PartnerDto>? Partners { get; set; }
        public IEnumerable<RiskLevelDto>? RiskLevels { get; set; }
    }
}
