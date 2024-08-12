using FinApp.UI.Models.DTO;
using FinApp.UI.Models.ViewModels;
using FinApp.UI.Services;
using FinApp.UI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Drawing.Drawing2D;
using System.Net.Http;

namespace FinApp.UI.Controllers {
    public class PartnersController : Controller {
        private readonly IBaseService<PartnerDto> partnerService;
        private readonly ILogger<PartnersController> logger;

        public PartnersController(IBaseService<PartnerDto> partnerService, ILogger<PartnersController> logger) {
            this.partnerService = partnerService;
            this.logger = logger;
        }
        // GET: PartnersController
        public async Task<IActionResult> Index() {
            var partners = await partnerService.GetAllAsync();
            return View(partners);
        }

        // GET: PartnersController/Details/5
        public async Task<IActionResult> Details(Guid id) {
            var partner = await partnerService.GetByIdAsync(id);
            return View(partner);
        }

        // GET: PartnersController/Create
        public ActionResult Create() {
            return View();
        }

        // POST: PartnersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddPartnerViewModel model) {
            try {
                if (ModelState.IsValid) {
                    var partnerDto = new PartnerDto {
                        Email = model.Email,
                        Name = model.Name,
                        Phone = model.Phone,
                        CreateDate = DateTime.Now,
                        CreateUserName = "Test" //TODO build login system for this
                    };

                    var partner = await partnerService.CreateAsync(partnerDto);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex) {
                var errorId = Guid.NewGuid();
                ModelState.AddModelError(errorId.ToString(), "An error occured");
                logger.LogError(errorId.ToString(), ex);
            }
            return View(model);
        }

        // GET: PartnersController/Edit/5
        public async Task<IActionResult> Edit(Guid id) {
            var partner = await partnerService.GetByIdAsync(id);

            if (partner is not null) {
                var model = new UpdatePartnerViewModel {
                    Email = partner.Email,
                    Name = partner.Name,
                    Phone = partner.Phone,
                    Id = partner.Id
                };

                return View(model);
            }

            return View(null);
        }

        // POST: PartnersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdatePartnerViewModel model) {
            try {
                if (ModelState.IsValid) {
                    var partnerDto = new PartnerDto {
                        Id = model.Id,
                        Name = model.Name,
                        Email = model.Email,
                        Phone = model.Phone,
                        LastUpdateDate = DateTime.Now,
                        LastUpdateUserName = "Test" //TODO build login system for this
                    };
                    var respose = await partnerService.UpdateAsync(partnerDto);

                    if (respose is not null) {
                        return RedirectToAction("Index", "Partners");
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

        // GET: PartnersController/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id) {
            var partner = await partnerService.GetByIdAsync(id);

            if (partner is not null) {
                return View(partner);
            }

            return View();
        }

        // POST: PartnersController/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(PartnerDto model) {
            try {
                var partner = await partnerService.DeleteAsync(model.Id);
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View("Edit");
            }
        }
    }
}
