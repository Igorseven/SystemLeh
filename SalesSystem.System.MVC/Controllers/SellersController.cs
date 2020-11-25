using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesSystem.System.MVC.Data.ORM;
using SalesSystem.System.MVC.Entities;
using SalesSystem.System.MVC.Models.ViewModels;


namespace SalesSystem.System.MVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SystemContext _context;
        private readonly IMapper _mapper;

        public SellersController(SystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        // GET: Sellers
        public async Task<IActionResult> Index()
        {
            var getContextData = await _context.Sellers.ToListAsync();
            var sellerEntityForViewModel = _mapper.Map<IEnumerable<Seller>, IEnumerable<SellerViewModel>>(getContextData);
            return View(sellerEntityForViewModel);
        }

        // GET: Sellers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getContextData = await _context.Sellers
                .FirstOrDefaultAsync(m => m.Id == id);
            var sellerEntityForViewModel = _mapper.Map<Seller, SellerViewModel>(getContextData);
            if (getContextData == null)
            {
                return NotFound();
            }

            return View(sellerEntityForViewModel);
        }

        // GET: Sellers/Create
        public IActionResult Create()
        {

            return View();
        }

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Email,BirthDate,BaseSalary,Department,DepartmentId,Id,RegistrationDate")] SellerViewModel sellerViewModel)
        {
            if (ModelState.IsValid)
            {
                var viewModelForSellerEntity = _mapper.Map<SellerViewModel, Seller>(sellerViewModel);
                var addNewSeller = _context.Add(viewModelForSellerEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sellerViewModel);
        }

        // GET: Sellers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getContextData = await _context.Sellers.FindAsync(id);
            var sellerEntityForViewModel = _mapper.Map<Seller, SellerViewModel>(getContextData);
            if (getContextData == null)
            {
                return NotFound();
            }
            return View(sellerEntityForViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Email,BirthDate,BaseSalary,Department,DepartmentId,Id,RegistrationDate")] SellerViewModel sellerViewModel)
        {
            if (id != sellerViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var viewModelForSellerEntity = _mapper.Map<SellerViewModel, Seller>(sellerViewModel);
                    var saveEdit = _context.Update(viewModelForSellerEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellerExists(sellerViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sellerViewModel);
        }

        // GET: Sellers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getContextData = await _context.Sellers
                .FirstOrDefaultAsync(m => m.Id == id);
            var sellerEntityForSelletEntity = _mapper.Map<Seller, SellerViewModel>(getContextData);
            if (getContextData == null)
            {
                return NotFound();
            }

            return View(sellerEntityForSelletEntity);
        }

        // POST: Sellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var getContextData = await _context.Sellers.FindAsync(id);
            var deleteSeller = _context.Sellers.Remove(getContextData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellerExists(int id)
        {
            return _context.Sellers.Any(e => e.Id == id);
        }
    }
}
