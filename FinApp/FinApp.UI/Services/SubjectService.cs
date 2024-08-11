using FinApp.UI.Models.DTO;
using FinApp.UI.Services.Interfaces;

namespace FinApp.UI.Services {
    public class SubjectService : IBaseService<SubjectDto> {
        private readonly IHttpClientService httpClientService;
        private readonly IConfiguration configuration;
        private readonly string? serviceUrl;

        public SubjectService(IHttpClientService httpClientService, IConfiguration configuration) {
            this.httpClientService = httpClientService;
            this.configuration = configuration;
            this.serviceUrl = configuration["AppConfiguration:ApiUrl"];
        }

        public async Task<SubjectDto?> CreateAsync(SubjectDto subject) {
            var response = await httpClientService.PostAsync<SubjectDto, SubjectDto>($"{serviceUrl}/subject/{subject.Id}", subject);
            return response;
        }

        public async Task<SubjectDto?> DeleteAsync(Guid id) {
            var response = await httpClientService.DeleteAsync<SubjectDto>($"{serviceUrl}/subject/{id}");
            return response;
        }

        public async Task<List<SubjectDto>> GetAllAsync() {
            var response = await httpClientService.GetAsync<List<SubjectDto>>($"{serviceUrl}/subject");
            return response ?? [];
        }

        public async Task<SubjectDto?> GetByIdAsync(Guid id) {
            var response = await httpClientService.GetAsync<SubjectDto>($"{serviceUrl}/subject/{id}");
            return response;
        }

        public async Task<SubjectDto?> UpdateAsync(SubjectDto subject) {
            var response = await httpClientService.PutAsync<SubjectDto, SubjectDto>($"{serviceUrl}/subject/{subject.Id}", subject);
            return response;
        }
    }
}
