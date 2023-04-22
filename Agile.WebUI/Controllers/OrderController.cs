using Agile.Business.Abstract.ReadServices;
using Agile.Business.Abstract.WriteServices;
using Agile.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Agile.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderReadService _orderReadService;
        private readonly IOrderWriteService _orderWriteService;
        private readonly ICustomerReadService _customerReadService;
        private readonly IProductReadService _productReadService;
        private readonly IProductWriteService _productWriteService;
        public OrderController(IOrderWriteService orderWriteService, IOrderReadService orderReadService, ICustomerReadService customerReadService, IProductReadService productReadService, IProductWriteService productWriteService)
        {
            _orderReadService = orderReadService;
            _orderWriteService = orderWriteService;
            _customerReadService = customerReadService;
            _productReadService = productReadService;
            _productWriteService = productWriteService;

        }
        public async Task<IActionResult> Index()
        {
            return View(await _orderReadService.GetAllAsync());
        }
        public async Task<IActionResult> Product(int? id)
        {
            return View(await _orderReadService.GetAllOrdersByProductIdAsync(id));
        }
        public async Task<IActionResult> Customer(int? id)
        {
            return View(await _orderReadService.GetAllOrdersByCustomerIdAsync(id));
        }
        public async Task<IActionResult> Detail(int? id)
        {
            return View(await _orderReadService.GetByIdAsync(id));
        }
        public async Task<IActionResult> Create(int? id, int productId, int quantity)
        {
            ViewBag.CustomerId = await _customerReadService.GetByIdAsync(id);
            ViewBag.Products = await _productReadService.GetAllProductsForAddOrderAsync();
            var model = _orderReadService.GetCreate(id);

            _productReadService.GetProductNewQuantity(productId, quantity);

            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? customerId, int productId, int quantity, DateTime orderDate, DateTime expectedOrderDate)
        {
            var result = await _orderWriteService.CreateAsync(customerId, productId, quantity, orderDate, expectedOrderDate);
            await _productWriteService.CreateNewQuanity(productId, quantity);
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
        public async Task<IActionResult> Edit(int? id, int productId, int quantity)
        {
            var updateOrder = await _orderReadService.GetByIdAsync(id);
            ViewBag.Products = await _productReadService.GetAllProductsForAddOrderAsync();
            _productReadService.GetProductNewQuantity(productId, quantity);
            if (updateOrder != null)
            {
                return View(updateOrder);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int customerId, int productId, int quantity, DateTime orderDate, DateTime expectedOrderDate)
        {
            var result = await _orderWriteService.UpdateAsync(id, customerId, productId, quantity, orderDate, expectedOrderDate);
            await _productWriteService.CreateNewQuanity(productId, quantity);
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
        public async Task<IActionResult> Delete(Order model, int? id)
        {
            var result = await _orderWriteService.DeleteAsync(model, id);
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
