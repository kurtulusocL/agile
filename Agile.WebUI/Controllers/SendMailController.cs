using Agile.Business.Abstract.ReadServices;
using Agile.Business.Abstract.WriteServices;
using Agile.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Agile.WebUI.Controllers
{
    public class SendMailController : Controller
    {
        private readonly ISendMailReadService _sendMailReadService;
        private readonly ISendMailWriteService _sendMailWriteSerice;
        private readonly ICustomerReadService _customerReadService;
        public SendMailController(ISendMailWriteService sendMailWriteService, ISendMailReadService sendMailReadService, ICustomerReadService customerReadService)
        {
            _sendMailReadService = sendMailReadService;
            _sendMailWriteSerice = sendMailWriteService;
            _customerReadService = customerReadService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _sendMailReadService.GetAllAsync());
        }
        public async Task<IActionResult> Customer(int? id)
        {
            return View(await _sendMailReadService.GetAllSentMailsByCustomerIdAsync(id));
        }
        public async Task<IActionResult> Detail(int? id)
        {
            return View(await _sendMailReadService.GetByIdAsync(id));
        }
        public async Task<IActionResult> Create(int? id)
        {
            ViewBag.CustomerId = await _customerReadService.GetByIdAsync(id);
            var model = _sendMailReadService.GetCreate(id);
            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? customerId, string senderEmail, string recieverEmail, string subject, string mailText)
        {
            var result = await _sendMailWriteSerice.CreateAsync(customerId,senderEmail,recieverEmail,subject,mailText);
            if (result == true)
            {
                TempData["successCreated"] = "E-mail Sent and Saved to Database";
                return RedirectToAction(nameof(Create));
            }
            else
            {
                TempData["errorCreated"] = "Mistake";
                return RedirectToAction(nameof(Create));
            }
        }
        public async Task<IActionResult> Delete(SendMail model, int? id)
        {
            var result = await _sendMailWriteSerice.DeleteAsync(model, id);
            if (result == true)
            {
                TempData["successDeleted"] = "E-mail deleted from Database";
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
