using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationLogic.DataModel;
using DataAccess;
using ApplicationLogic.Abstractions;

namespace BankingApp.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAccountRepository _context;
        private readonly BankDbContext _contextBank;

        public AccountsController(IAccountRepository context, BankDbContext contextBank)
        {
            _context = context;
            _contextBank = contextBank;
        }

        public async Task<IActionResult> Index()
        {
            var accounts = from account in _context.GetAll()
                               select account;
            return View(accounts);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Account account = _context.GetAccountByAccountId(id);

            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Account account)
        {
            if (ModelState.IsValid)
            {
                account.AccountID = Guid.NewGuid();
                _context.Add(account);
                _context.Update(account);
                return RedirectToAction("Index");
            }
            return View(account);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Account account = _context.GetAccountByAccountId(id);

            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Account account)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Update(account);
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(account);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Account account = _context.GetAccountByAccountId(id);

            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            Account account = _context.GetAccountByAccountId(id);
            _context.Delete(account);
            return RedirectToAction("Index");
        }

        private bool AccountExists(Guid id)
        {
            return _contextBank.Accounts.Any(e => e.AccountID == id);
        }
    }
}
