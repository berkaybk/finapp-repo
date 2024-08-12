using FinApp.UI.Models.DTO;
using FinApp.UI.Models.ViewModels;
using FinApp.UI.Services;
using FinApp.UI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinApp.UI.Controllers {
    public class AgreementsController : Controller {
        private readonly IAgreementService agreementService;
        private readonly IBaseService<PartnerDto> partnerService;
        private readonly ILogger<AgreementsController> logger;

        public AgreementsController(IAgreementService agreementService,
            IBaseService<PartnerDto> partnerService,
            ILogger<AgreementsController> logger) {
            this.agreementService = agreementService;
            this.partnerService = partnerService;
            this.logger = logger;
        }
        // GET: AgreementsController
        public async Task<IActionResult> Index() {
            var agreements = await agreementService.GetAllAsync();
            return View(agreements);
        }

        // GET: AgreementsController/Details/5
        public async Task<IActionResult> Details(Guid id) {
            var agreement = await agreementService.GetByIdAsync(id);
            return View(agreement);
        }

        // GET: AgreementsController/Create
        public async Task<IActionResult> Create() {
            var agreement = new AgreementViewModel {
                Agreement = new AddAgreementViewModel(),
                Partners = await partnerService.GetAllAsync(),
                RiskLevels = await agreementService.GetRiskLevels()
            };

            return View(agreement);
        }

        // POST: AgreementsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AgreementViewModel agreementViewModel) {
            try {
                var model = agreementViewModel.Agreement;

                if (ModelState.IsValid) {
                    var agreementDto = new AgreementDto {
                        Amount = model.Amount,
                        Name = model.Name,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate,
                        Keywords = model.Keywords,
                        PartnerId = model.PartnerId,
                        RiskLevelId = model.RiskLevelId,
                        CreateDate = DateTime.Now,
                        CreateUserName = "Test" //TODO build login system for this
                    };

                    var agreement = await agreementService.CreateAsync(agreementDto);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex) {
                var errorId = Guid.NewGuid();
                ModelState.AddModelError(errorId.ToString(), "An error occured");
                logger.LogError(errorId.ToString(), ex);
            }
            return View(agreementViewModel);
        }

        // GET: AgreementsController/Edit/5
        public async Task<IActionResult> Edit(Guid id) {
            var agreement = await agreementService.GetByIdAsync(id);

            if (agreement is not null) {
                var model = new UpdateAgreementViewModel {
                    Amount = agreement.Amount,
                    Name = agreement.Name,
                    StartDate = agreement.StartDate,
                    EndDate = agreement.EndDate,
                    Keywords = agreement.Keywords,
                    PartnerId = agreement.PartnerId,
                    RiskLevelId = agreement.RiskLevelId,
                    Id = agreement.Id
                };

                return View(model);
            }

            return View(null);
        }

        // POST: AgreementsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateAgreementViewModel model) {
            try {
                if (ModelState.IsValid) {
                    var agreementDto = new AgreementDto {
                        Amount = model.Amount,
                        Name = model.Name,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate,
                        Keywords = model.Keywords,
                        PartnerId = model.PartnerId,
                        RiskLevelId = model.RiskLevelId,
                        Id = model.Id,
                        RecordStatus = model.RecordStatus,
                        LastUpdateDate = DateTime.Now,
                        LastUpdateUserName = "Test" //TODO build login system for this
                    };
                    var respose = await agreementService.UpdateAsync(agreementDto);

                    if (respose is not null) {
                        return RedirectToAction("Index", "Agreements");
                    }
                }
                return View(model);
            }
            catch (Exception ex) {
                var errorId = Guid.NewGuid();
                ModelState.AddModelError(errorId.ToString(), "An error occured");
                logger.LogError(errorId.ToString(), ex);
            }
            return View(model);
        }

        // GET: AgreementsController/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id) {
            var agreement = await agreementService.GetByIdAsync(id);

            if (agreement is not null) {
                return View(agreement);
            }

            return View();
        }

        // POST: AgreementsController/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(AgreementDto model) {
            try {
                var agreement = await agreementService.DeleteAsync(model.Id);
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View("Edit");
            }
        }
    }
}
