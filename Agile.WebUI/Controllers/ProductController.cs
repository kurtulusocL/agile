using Agile.Business.Abstract.ReadServices;
using Agile.Business.Abstract.WriteServices;
using Agile.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Agile.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductWriteService _productWriteService;
        private readonly IProductReadService _productReadService;
        private readonly ICompanyReadService _companyReadService;
        public ProductController(IProductWriteService productWriteService, IProductReadService productReadService, ICompanyReadService companyReadService)
        {
            _productWriteService = productWriteService;
            _productReadService = productReadService;
            _companyReadService = companyReadService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _productReadService.GetAllAsync());
        }
        public async Task<IActionResult> Company(int? id)
        {
            return View(await _productReadService.GetAllProductsByCompanyIdAsync(id));
        }
        public async Task<IActionResult> Detail(int? id)
        {
            return View(await _productReadService.GetByIdAsync(id));
        }
        public async Task<IActionResult> Create(int? id)
        {
            ViewBag.CompanyId = await _companyReadService.GetByIdAsync(id);
            var model = _productReadService.GetCreate(id);
            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? companyId, int quantity, string name, string description, decimal price)
        {
            var result = await _productWriteService.CreateAsync(companyId, quantity, name, description, price);
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
            var updateProduct = await _productReadService.GetByIdAsync(id);
            if (updateProduct != null)
            {
                return View(updateProduct);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? companyId, int id, string name, int quantity, string description, decimal price)
        {
            var result = await _productWriteService.UpdateAsync(companyId, id, quantity, name, description, price);
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
        public async Task<IActionResult> Delete(Product model, int? id)
        {
            var result = await _productWriteService.DeleteAsync(model, id);
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
