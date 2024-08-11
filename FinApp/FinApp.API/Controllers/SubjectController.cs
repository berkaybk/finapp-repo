using AutoMapper;
using FinApp.API.Models.Domain;
using FinApp.API.Models.DTO;
using FinApp.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinApp.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase {
        private readonly ISubjectRepository repository;
        private readonly IMapper mapper;

        public SubjectController(ISubjectRepository repository, IMapper mapper) {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() {
            var Subjects = await repository.GetAllAsync();

            return Ok(mapper.Map<List<SubjectDto>>(Subjects));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id) {
            // Get Subject From Database
            var SubjectDomain = await repository.GetByIdAsync(id);

            if (SubjectDomain == null) {
                return NotFound();
            }

            // Return DTO back to client
            return Ok(mapper.Map<SubjectDto>(SubjectDomain));
        }

        [HttpPost]
        //[ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddSubjectRequestDto addSubjectRequestDto) {
            // Map or Convert DTO to Domain Model
            var SubjectDomainModel = mapper.Map<Subject>(addSubjectRequestDto);

            // Use Domain Model to create Subject
            SubjectDomainModel = await repository.CreateAsync(SubjectDomainModel);

            // Map Domain model back to DTO
            var SubjectDto = mapper.Map<SubjectDto>(SubjectDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = SubjectDto.Id }, SubjectDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        //[ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateSubjectRequestDto updateSubjectRequestDto) {

            // Map DTO to Domain Model
            var SubjectDomainModel = mapper.Map<Subject>(updateSubjectRequestDto);

            // Check if Subject exists
            SubjectDomainModel = await repository.UpdateAsync(id, SubjectDomainModel);

            if (SubjectDomainModel == null) {
                return NotFound();
            }

            return Ok(mapper.Map<SubjectDto>(SubjectDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer,Reader")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) {
            var SubjectDomainModel = await repository.DeleteAsync(id);

            if (SubjectDomainModel == null) {
                return NotFound();
            }

            return Ok(mapper.Map<SubjectDto>(SubjectDomainModel));
        }
    }
}
