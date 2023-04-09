using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NToastNotify;
using PharmaciesManagement.Models;
using PharmaciesManagement.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaciesManagement.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IToastNotification _toastNotification;
        protected readonly IValidator<PurchaseViewModel> _validator;
        private readonly IMapper _mapper;
        private readonly ILogger<PurchaseController> _logger;


        public PurchaseController(ApplicationDbContext context, IToastNotification toastNotification, IValidator<PurchaseViewModel> validator, IMapper mapper, ILogger<PurchaseController> logger)
        {
            _context = context;
            _toastNotification = toastNotification;
            _validator = validator;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var purshase = await _context.Purchases.ToListAsync();

            return View(purshase);
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = new PurchaseViewModel
            {
                Stores = await _context.Stores.OrderBy(m => m.Branch).ToListAsync(),
                Items = await _context.Items.OrderBy(m => m.Name).ToListAsync()
            };

            return View("PurchaseForm", viewModel);
        }
        public IActionResult GetBalance(int storeId, int itemId)
        {
            var balance = _context.Purchases.Where(s => s.StoreId == storeId && s.ItemId == itemId).Sum(q => q.Quantity);
            return Ok(balance);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PurchaseViewModel model)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);
                model.Stores = await _context.Stores.OrderBy(m => m.Branch).ToListAsync();
                model.Items = await _context.Items.OrderBy(m => m.Name).ToListAsync();
                return View("PurchaseForm", model);
            }
            var purchase = _mapper.Map<Purchase>(model);
            _context.Purchases.Add(purchase);
            _context.SaveChanges();
            _toastNotification.AddSuccessToastMessage("تم إنشاء المشتريات بنجاح");
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var purchase = await _context.Purchases.FindAsync(id);

            if (purchase == null)
                return NotFound();

            _context.Purchases.Remove(purchase);
            _context.SaveChanges();

            return Ok();
        }
    }
}
