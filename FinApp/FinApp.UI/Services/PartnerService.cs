using FinApp.UI.Models.DTO;
using FinApp.UI.Services.Interfaces;

namespace FinApp.UI.Services {
    public class PartnerService : IBaseService<PartnerDto> {
        private readonly IHttpClientService httpClientService;
        private readonly IConfiguration configuration;
        private readonly string? serviceUrl;

        public PartnerService(IHttpClientService httpClientService, IConfiguration configuration) {
            this.httpClientService = httpClientService;
            this.configuration = configuration;
            this.serviceUrl = configuration["AppConfiguration:ApiUrl"];
        }

        public async Task<PartnerDto?> CreateAsync(PartnerDto partnerDto) {
            var response = await httpClientService.PostAsync<PartnerDto, PartnerDto>($"{serviceUrl}/partner/{partnerDto.Id}", partnerDto);
            return response;
        }

        public async Task<PartnerDto?> DeleteAsync(Guid id) {
            var response = await httpClientService.DeleteAsync<PartnerDto>($"{serviceUrl}/partner/{id}");
            return response;
        }

        public async Task<List<PartnerDto>> GetAllAsync() {
            var response = await httpClientService.GetAsync<List<PartnerDto>>($"{serviceUrl}/partner");
            return response ?? [];
        }

        public async Task<PartnerDto?> GetByIdAsync(Guid id) {
            var response = await httpClientService.GetAsync<PartnerDto>($"{serviceUrl}/partner/{id}");
            return response;
        }

        public async Task<PartnerDto?> UpdateAsync(PartnerDto partner) {
            var response = await httpClientService.PutAsync<PartnerDto, PartnerDto>($"{serviceUrl}/partner/{partner.Id}", partner);
            return response;
        }
    }
}
