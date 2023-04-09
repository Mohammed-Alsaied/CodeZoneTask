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

namespace PharmaciesManagement.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IToastNotification _toastNotification;
        protected readonly IValidator<ItemViewModel> _validator;
        private readonly IMapper _mapper;
        private readonly ILogger<ItemsController> _logger;
        public ItemsController(ApplicationDbContext context, IToastNotification toastNotification, IValidator<ItemViewModel> validator, IMapper mapper, ILogger<ItemsController> logger)
        {
            _context = context;
            _toastNotification = toastNotification;
            _validator = validator;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _context.Items.ToListAsync();
            return View(items);
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = new ItemViewModel
            {
            };

            return View("ItemForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ItemViewModel model)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);
                return View("ItemForm", model);
            }
            var item = _mapper.Map<Item>(model);

            _context.Items.Add(item);
            _context.SaveChanges();

            _toastNotification.AddSuccessToastMessage("تم إنشاء الصنف بنجاح");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return BadRequest();

            var item = await _context.Items.FindAsync(id);

            if (item == null)
                return NotFound();

            var viewModel = new ItemViewModel
            {
                Id = item.Id,
                Name = item.Name,
            };

            return View("ItemForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ItemViewModel model)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);
                return View("ItemForm", model);
            }

            var item = await _context.Items.FindAsync(model.Id);

            if (item == null)
                return NotFound();
            item.Name = model.Name;
            _context.SaveChanges();
            _toastNotification.AddSuccessToastMessage("تم تعديل الصنف بنجاح");
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var item = await _context.Items.FindAsync(id);

            if (item == null)
                return NotFound();

            _context.Items.Remove(item);
            _context.SaveChanges();

            return Ok();
        }
    }
}
