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
    public class SalesRecordsController : Controller
    {
        private readonly SystemContext _context;
        private readonly IMapper _mapper;

        public SalesRecordsController(SystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: SalesRecords
        public async Task<IActionResult> Index()
        {
            var getContextData = await _context.SalesRecords.ToListAsync();
            var SalesEntityForViewModel = _mapper.Map<IEnumerable<SalesRecord>, IEnumerable<SalesRecordViewModel>>(getContextData);
            return View(SalesEntityForViewModel);
        }

        // GET: SalesRecords/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getContextData = await _context.SalesRecords
                .FirstOrDefaultAsync(m => m.Id == id);

            var SalesEntityForViewModel = _mapper.Map<SalesRecord, SalesRecordViewModel>(getContextData);
            if (getContextData == null)
            {
                return NotFound();
            }

            return View(SalesEntityForViewModel);
        }

        // GET: SalesRecords/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Amount,Status,Id,RegistrationDate")] SalesRecordViewModel salesRecordViewModel)
        {
            if (ModelState.IsValid)
            {
                var viewModelForSalesEntity = _mapper.Map<SalesRecordViewModel, SalesRecord>(salesRecordViewModel);
                var addSales = _context.Add(viewModelForSalesEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesRecordViewModel);
        }

        // GET: SalesRecords/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getContextData = await _context.SalesRecords.FirstOrDefaultAsync(prop => prop.Id == id);
            var SalesEntityForViewModel = _mapper.Map<SalesRecord, SalesRecordViewModel>(getContextData);
            if (getContextData == null)
            {
                return NotFound();
            }
            return View(SalesEntityForViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Amount,Status,Id,RegistrationDate")] SalesRecordViewModel salesRecordViewModel)
        {
            if (id != salesRecordViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var viewModelForSalesEntity = _mapper.Map<SalesRecordViewModel, SalesRecord>(salesRecordViewModel);
                    var updateSales = _context.Update(viewModelForSalesEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesRecordExists(salesRecordViewModel.Id))
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
            return View(salesRecordViewModel);
        }

        // GET: SalesRecords/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getContextData = await _context.SalesRecords
                .FirstOrDefaultAsync(m => m.Id == id);
            var salesEntityForViewModel = _mapper.Map<SalesRecord, SalesRecordViewModel>(getContextData);

            if (getContextData == null)
            {
                return NotFound();
            }

            return View(salesEntityForViewModel);
        }

        // POST: SalesRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var getContextData = await _context.SalesRecords
                .FirstOrDefaultAsync(prop => prop.Id == id);
            var deleteSales = _context.SalesRecords.Remove(getContextData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesRecordExists(int id)
        {
            return _context.SalesRecords.Any(e => e.Id == id);
        }
    }
}
