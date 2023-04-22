using Agile.Business.Abstract.ReadServices;
using Agile.Business.Abstract.WriteServices;
using Agile.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Agile.WebUI.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyWriteService _companyWriteService;
        private readonly ICompanyReadService _companyReadService;
        public CompanyController(ICompanyWriteService companyWriteService, ICompanyReadService companyReadService)
        {
            _companyWriteService = companyWriteService;
            _companyReadService = companyReadService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _companyReadService.GetAllAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Company model)
        {
            var result = await _companyWriteService.CreateAsync(model);
            if (result == true)
            {
                TempData["successCreated"] = "Created";
                return RedirectToAction(nameof(Create));
            }
            else
            {
                TempData["errorCreated"] = "Mistake";
                return RedirectToAction(nameof(Create));
            }
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var updateCompany = await _companyReadService.GetByIdAsync(id);
            if (updateCompany != null)
            {
                return View(updateCompany);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Company model)
        {
            var result = await _companyWriteService.UpdateAsync(model);
            if (result == true)
            {
                TempData["successUpdated"] = "Updated";
                return RedirectToAction(nameof(Edit));
            }
            else
            {
                TempData["errorUpdated"] = "Mistake";
                return RedirectToAction(nameof(Edit));
            }
        }
        public async Task<IActionResult> Delete(Company model, int? id)
        {
            var result = await _companyWriteService.DeleteAsync(model, id);
            if (result == true)
            {
                TempData["successDeleted"] = "Deleted";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["errorDeleted"] = "Mistake";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
