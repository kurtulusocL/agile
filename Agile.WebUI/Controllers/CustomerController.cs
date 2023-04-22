using Agile.Business.Abstract.ReadServices;
using Agile.Business.Abstract.WriteServices;
using Agile.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Agile.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerWriteService _customerWriteService;
        private readonly ICustomerReadService _customerReadService;
        public CustomerController(ICustomerReadService customerReadService, ICustomerWriteService customerWriteService)
        {
            _customerReadService = customerReadService;
            _customerWriteService = customerWriteService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _customerReadService.GetAllAsync());
        }
        public async Task<IActionResult> Detail(int? id)
        {
            return View(await _customerReadService.GetByIdAsync(id));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer model)
        {
            var result = await _customerWriteService.CreateAsync(model);
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
            var updateCustomer = await _customerReadService.GetByIdAsync(id);
            if (updateCustomer != null)
            {
                return View(updateCustomer);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Customer model)
        {
            var result = await _customerWriteService.UpdateAsync(model);
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
        public async Task<IActionResult> Delete(Customer model, int? id)
        {
            var result = await _customerWriteService.DeleteAsync(model, id);
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