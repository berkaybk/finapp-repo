using FinApp.UI.Models.DTO;
using FinApp.UI.Services.Interfaces;

namespace FinApp.UI.Services {
    public class AgreementService : IAgreementService {
        private readonly IHttpClientService httpClientService;
        private readonly IConfiguration configuration;
        private readonly string? serviceUrl;

        public AgreementService(IHttpClientService httpClientService, IConfiguration configuration) {
            this.httpClientService = httpClientService;
            this.configuration = configuration;
            this.serviceUrl = configuration["AppConfiguration:ApiUrl"];
        }

        public async Task<AgreementDto?> CreateAsync(AgreementDto agreement) {
            var response = await httpClientService.PostAsync<AgreementDto, AgreementDto>($"{serviceUrl}/agreement", agreement);
            return response;
        }

        public async Task<AgreementDto?> DeleteAsync(Guid id) {
            var response = await httpClientService.DeleteAsync<AgreementDto>($"{serviceUrl}/agreement/{id}");
            return response;
        }

        public async Task<List<AgreementDto>> GetAllAsync() {
            var response = await httpClientService.GetAsync<List<AgreementDto>>($"{serviceUrl}/agreement");
            return response ?? [];
        }

        public async Task<AgreementDto?> GetByIdAsync(Guid id) {
            var response = await httpClientService.GetAsync<AgreementDto>($"{serviceUrl}/agreement/{id}");
            return response;
        }

        public async Task<AgreementDto?> UpdateAsync(AgreementDto agreement) {
            var response = await httpClientService.PutAsync<AgreementDto, AgreementDto>($"{serviceUrl}/agreement/{agreement.Id}", agreement);
            return response;
        }

        public async Task<List<RiskLevelDto>> GetRiskLevels() {
            var response = await httpClientService.GetAsync<List<RiskLevelDto>>($"{serviceUrl}/agreement/risklevels");
            return response ?? [];
        }
    }
}
