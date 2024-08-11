using AutoMapper;
using FinApp.API.CustomActionFilter;
using FinApp.API.Models.Domain;
using FinApp.API.Models.DTO;
using FinApp.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialStatementController : ControllerBase
    {
        private readonly IFinancialStatementRepository repository;
        private readonly IMapper mapper;

        public FinancialStatementController(IFinancialStatementRepository repository, IMapper mapper) {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() {
            var FinancialStatements = await repository.GetAllAsync();

            return Ok(mapper.Map<List<FinancialStatementDto>>(FinancialStatements));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id) {
            // Get FinancialStatement From Database
            var FinancialStatementDomain = await repository.GetByIdAsync(id);

            if (FinancialStatementDomain == null) {
                return NotFound();
            }

            // Return DTO back to client
            return Ok(mapper.Map<FinancialStatementDto>(FinancialStatementDomain));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddFinancialStatementRequestDto addFinancialStatementRequestDto) {
            // Map or Convert DTO to Domain Model
            var FinancialStatementDomainModel = mapper.Map<FinancialStatement>(addFinancialStatementRequestDto);

            // Use Domain Model to create FinancialStatement
            FinancialStatementDomainModel = await repository.CreateAsync(FinancialStatementDomainModel);

            // Map Domain model back to DTO
            var FinancialStatementDto = mapper.Map<FinancialStatementDto>(FinancialStatementDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = FinancialStatementDto.Id }, FinancialStatementDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateFinancialStatementRequestDto updateFinancialStatementRequestDto) {

            // Map DTO to Domain Model
            var FinancialStatementDomainModel = mapper.Map<FinancialStatement>(updateFinancialStatementRequestDto);

            // Check if FinancialStatement exists
            FinancialStatementDomainModel = await repository.UpdateAsync(id, FinancialStatementDomainModel);

            if (FinancialStatementDomainModel == null) {
                return NotFound();
            }

            return Ok(mapper.Map<FinancialStatementDto>(FinancialStatementDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) {
            var FinancialStatementDomainModel = await repository.DeleteAsync(id);

            if (FinancialStatementDomainModel == null) {
                return NotFound();
            }

            return Ok(mapper.Map<FinancialStatementDto>(FinancialStatementDomainModel));
        }
    }
}
