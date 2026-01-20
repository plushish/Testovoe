using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.CodeAnalysis.Differencing;

namespace WebApplication1.Controllers
{
    #region snippet
    public class CompaniesesController : Controller
    {
        private readonly CompaniesDbContext _context;

        public CompaniesesController(CompaniesDbContext context)
        {
            _context = context;
        }
        #endregion

        // GET: Company
        public async Task<IActionResult> Index()
        {
            return View(await _context.Companies.ToListAsync());
        }

        // GET: Company/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var BD = await _context.Companies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (BD == null)
            {
                return NotFound();
            }

            return View(BD);
        }

        // GET: Company/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NameFull,NameShort,Inn,Ogrn,CreationDate,ChangeDate")] Company company)
        {
            if (ModelState.IsValid)
            {
                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Company/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Company/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveDraft(int Id,string NameFull, string NameShort, int Inn, string Ogrn, DateOnly CreationDate, Company company) /*Edit(int id, [Bind("ID,NameFull,NameShort,Inn,Ogrn,CreationDate")] )*/ 
        {
            if (Id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Companies
                        .Where(u => u.Id == Id)
                        .ExecuteUpdateAsync(s => s
                        .SetProperty(u => u.NameFull, NameFull)
                        .SetProperty(u => u.NameShort, NameShort)
                        .SetProperty(u => u.Inn, Inn)
                        .SetProperty(u => u.Ogrn, Ogrn)
                        .SetProperty(u => u.CreationDate, CreationDate)
                        .SetProperty(u => u.ChangeDate, DateOnly.FromDateTime(DateTime.Now)));
                    //_context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
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
            return View(company);
        }

        // GET: Company/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
    }

}