using AutoMapper;
using FinApp.API.Models.Domain;
using FinApp.API.Models.DTO;
using FinApp.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerRepository repository;
        private readonly IMapper mapper;

        public PartnerController(IPartnerRepository repository, IMapper mapper) {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() {
            var Partners = await repository.GetAllAsync();

            return Ok(mapper.Map<List<PartnerDto>>(Partners));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id) {
            // Get Partner From Database
            var PartnerDomain = await repository.GetByIdAsync(id);

            if (PartnerDomain == null) {
                return NotFound();
            }

            // Return DTO back to client
            return Ok(mapper.Map<PartnerDto>(PartnerDomain));
        }

        [HttpPost]
        //[ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddPartnerRequestDto addPartnerRequestDto) {
            // Map or Convert DTO to Domain Model
            var PartnerDomainModel = mapper.Map<Partner>(addPartnerRequestDto);

            // Use Domain Model to create Partner
            PartnerDomainModel = await repository.CreateAsync(PartnerDomainModel);

            // Map Domain model back to DTO
            var PartnerDto = mapper.Map<PartnerDto>(PartnerDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = PartnerDto.Id }, PartnerDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        //[ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePartnerRequestDto updatePartnerRequestDto) {

            // Map DTO to Domain Model
            var PartnerDomainModel = mapper.Map<Partner>(updatePartnerRequestDto);

            // Check if Partner exists
            PartnerDomainModel = await repository.UpdateAsync(id, PartnerDomainModel);

            if (PartnerDomainModel == null) {
                return NotFound();
            }

            return Ok(mapper.Map<PartnerDto>(PartnerDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer,Reader")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) {
            var PartnerDomainModel = await repository.DeleteAsync(id);

            if (PartnerDomainModel == null) {
                return NotFound();
            }

            return Ok(mapper.Map<PartnerDto>(PartnerDomainModel));
        }
    }
}
