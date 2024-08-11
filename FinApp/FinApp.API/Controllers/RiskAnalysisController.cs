using AutoMapper;
using FinApp.API.Models.Domain;
using FinApp.API.Models.DTO;
using FinApp.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinApp.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RiskAnalysisController : ControllerBase {
        private readonly IRiskAnalysisRepository repository;
        private readonly IMapper mapper;

        public RiskAnalysisController(IRiskAnalysisRepository repository, IMapper mapper) {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() {
            var RiskAnalysiss = await repository.GetAllAsync();

            return Ok(mapper.Map<List<RiskAnalysisDto>>(RiskAnalysiss));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id) {
            // Get RiskAnalysis From Database
            var RiskAnalysisDomain = await repository.GetByIdAsync(id);

            if (RiskAnalysisDomain == null) {
                return NotFound();
            }

            // Return DTO back to client
            return Ok(mapper.Map<RiskAnalysisDto>(RiskAnalysisDomain));
        }

        [HttpPost]
        //[ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRiskAnalysisRequestDto addRiskAnalysisRequestDto) {
            // Map or Convert DTO to Domain Model
            var RiskAnalysisDomainModel = mapper.Map<RiskAnalysis>(addRiskAnalysisRequestDto);

            // Use Domain Model to create RiskAnalysis
            RiskAnalysisDomainModel = await repository.CreateAsync(RiskAnalysisDomainModel);

            // Map Domain model back to DTO
            var RiskAnalysisDto = mapper.Map<RiskAnalysisDto>(RiskAnalysisDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = RiskAnalysisDto.Id }, RiskAnalysisDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        //[ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRiskAnalysisRequestDto updateRiskAnalysisRequestDto) {

            // Map DTO to Domain Model
            var RiskAnalysisDomainModel = mapper.Map<RiskAnalysis>(updateRiskAnalysisRequestDto);

            // Check if RiskAnalysis exists
            RiskAnalysisDomainModel = await repository.UpdateAsync(id, RiskAnalysisDomainModel);

            if (RiskAnalysisDomainModel == null) {
                return NotFound();
            }

            return Ok(mapper.Map<RiskAnalysisDto>(RiskAnalysisDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer,Reader")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) {
            var RiskAnalysisDomainModel = await repository.DeleteAsync(id);

            if (RiskAnalysisDomainModel == null) {
                return NotFound();
            }

            return Ok(mapper.Map<RiskAnalysisDto>(RiskAnalysisDomainModel));
        }
    }
}
