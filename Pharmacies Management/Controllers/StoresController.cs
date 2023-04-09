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
using System.Threading.Tasks;

namespace Pharmacies_Management.Controllers
{
    public class StoresController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IToastNotification _toastNotification;
        protected readonly IValidator<StoreViewModel> _validator;
        private readonly IMapper _mapper;
        private readonly ILogger<StoresController> _logger;
        public StoresController(ApplicationDbContext context, IToastNotification toastNotification, IValidator<StoreViewModel> validator, IMapper mapper, ILogger<StoresController> logger)
        {
            _context = context;
            _toastNotification = toastNotification;
            _validator = validator;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var stores = await _context.Stores.ToListAsync();
            return View(stores);
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = new StoreViewModel
            {
            };

            return View("StoreForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StoreViewModel model)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);
                return View("StoreForm", model);
            }
            var store = _mapper.Map<Store>(model);

            _context.Stores.Add(store);
            _context.SaveChanges();

            _toastNotification.AddSuccessToastMessage("تم إنشاء الفرع بنجاح");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return BadRequest();

            var store = await _context.Stores.FindAsync(id);

            if (store == null)
                return NotFound();

            var viewModel = new StoreViewModel
            {
                Id = store.Id,
                Branch = store.Branch,
            };

            return View("StoreForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StoreViewModel model)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);
                return View("StoreForm", model);
            }

            var store = await _context.Stores.FindAsync(model.Id);

            if (store == null)
                return NotFound();
            store.Branch = model.Branch;
            _context.SaveChanges();
            _toastNotification.AddSuccessToastMessage("تم تعديل الفرع بنجاح");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var store = await _context.Stores.FindAsync(id);

            if (store == null)
                return NotFound();

            _context.Stores.Remove(store);
            _context.SaveChanges();

            return Ok();
        }
    }
}
