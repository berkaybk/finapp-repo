using AutoMapper;
using FinApp.API.CustomActionFilter;
using FinApp.API.Models.Domain;
using FinApp.API.Models.DTO;
using FinApp.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinApp.API.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class AgreementController : ControllerBase {

        private readonly IAgreementRepository repository;
        private readonly IMapper mapper;

        public AgreementController(IAgreementRepository repository, IMapper mapper) {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() {
            var agreements = await repository.GetAllAsync();

            return Ok(mapper.Map<List<AgreementDto>>(agreements));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id) {
            // Get Agreement From Database
            var agreementDomain = await repository.GetByIdAsync(id);

            if (agreementDomain == null) {
                return NotFound();
            }

            // Return DTO back to client
            return Ok(mapper.Map<AgreementDto>(agreementDomain));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddAgreementRequestDto addAgreementRequestDto) {
            // Map or Convert DTO to Domain Model
            var agreementDomainModel = mapper.Map<Agreement>(addAgreementRequestDto);

            // Use Domain Model to create Agreement
            agreementDomainModel = await repository.CreateAsync(agreementDomainModel);

            // Map Domain model back to DTO
            var AgreementDto = mapper.Map<AgreementDto>(agreementDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = AgreementDto.Id }, AgreementDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateAgreementRequestDto updateAgreementRequestDto) {

            // Map DTO to Domain Model
            var agreementDomainModel = mapper.Map<Agreement>(updateAgreementRequestDto);

            // Check if Agreement exists
            agreementDomainModel = await repository.UpdateAsync(id, agreementDomainModel);

            if (agreementDomainModel == null) {
                return NotFound();
            }

            return Ok(mapper.Map<AgreementDto>(agreementDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) {
            var agreementDomainModel = await repository.DeleteAsync(id);

            if (agreementDomainModel == null) {
                return NotFound();
            }

            return Ok(mapper.Map<AgreementDto>(agreementDomainModel));
        }
    }
}
